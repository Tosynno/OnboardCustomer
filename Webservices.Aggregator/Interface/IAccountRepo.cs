using System.Collections.Generic;
using System.Threading.Tasks;
using Webservices.Aggregator.Models;

namespace Webservices.Aggregator.Interface
{
    public interface IAccountRepo
    {
        Task<IEnumerable<AccountModel>> GetOnboarding();
        Task<IEnumerable<AccountModel>> GetOnboardingByEmail(string Email);
        Task<string> GetToken(string token);
    }
}
