using System;
using System.Linq;
using System.Threading.Tasks;
using AbfahrtSkill.Service;
using AbfahrtSkill.WienerLinien;
using Alexa.NET;
using Alexa.NET.Request;
using Alexa.NET.Response;
using Microsoft.AspNetCore.Mvc;

namespace AbfahrtSkill.Controllers
{
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly IAbfahrtService abfahrtService;

        public SkillController(IAbfahrtService abfahrtService)
        {
            this.abfahrtService = abfahrtService;
        }


        private string Und<T>(T[] arr, Func<T, string> func, string und = "und")
        {
            if (arr.Length == 1)
            {
                return func(arr[0]);
            }
            else
            {
                return $"{string.Join(", ", arr.Take(arr.Length - 1).Select(func))} {und} {func(arr[arr.Length - 1])}";
            }
        }

        [HttpPost]
        public async Task<SkillResponse> Post([FromBody]SkillRequest input, string rbl)
        {

            var tasks = (rbl.Split('-')).Select(abfahrtService.GetAsync);
            var abfahrten = (await Task.WhenAll(tasks)).SelectMany(a => a);
            var abfFormat = string.Join(", ", abfahrten.Select(v => $"{v.Linie} in Richtung {v.Richtung} in {Und(v.Countdowns, s => s.ToString())}"));
            return ResponseBuilder.Tell($"Die aktuellen Abfahrten: {abfFormat}.");
        }


    }
}