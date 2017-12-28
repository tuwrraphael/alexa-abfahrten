using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AbfahrtSkill.Models;
using Microsoft.Extensions.Options;
using AbfahrtSkill.Service;
using System.Linq;

namespace AbfahrtSkill.WienerLinien
{
    public class WienerLinienService : IAbfahrtService
    {
        private WienerLinienOptions options;

        public WienerLinienService(IOptions<WienerLinienOptions> optionsAccessor)
        {
            options = optionsAccessor.Value;
        }

        public async Task<AbfahrtenLinine[]> GetAsync(string rbl)
        {
            var client = new HttpClient();
            var resText = await client.GetStringAsync($"https://www.wienerlinien.at/ogd_realtime/monitor?rbl={rbl}&sender={options.WL_KEY}");
            var result = JsonConvert.DeserializeObject<MonitorResult>(resText);
            var l = new List<AbfahrtenLinine>();
            foreach (var monitor in result.data.monitors)
            {
                foreach(var line in monitor.lines)
                {
                    var countDowns = line.departures.departure.Take(2).Select(v => v.departureTime.countdown).ToArray();
                    var abfahrt = new AbfahrtenLinine()
                    {
                        Countdowns = countDowns,
                        Linie = line.name,
                        Richtung = line.towards
                    };
                    l.Add(abfahrt);
                }
            }
            return l.ToArray();
        }
    }
}