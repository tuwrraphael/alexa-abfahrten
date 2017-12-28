using AbfahrtSkill.Models;
using System.Threading.Tasks;

namespace AbfahrtSkill.Service
{
    public interface IAbfahrtService
    {
        Task<AbfahrtenLinine[]> GetAsync(string rbl);
    }
}
