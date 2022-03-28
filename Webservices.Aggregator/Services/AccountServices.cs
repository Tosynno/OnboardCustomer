using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Webservices.Aggregator.Extensions;
using Webservices.Aggregator.Interface;
using Webservices.Aggregator.Models;

namespace Webservices.Aggregator.Services
{
    public class AccountServices : IAccountRepo
    {
        private readonly HttpClient _client;

        public AccountServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<AccountModel>> GetOnboardingByEmail(string Email)
        {
            var response = await _client.GetAsync($"/api/v1/Account/GetOnboardingByEmail/{Email}");
            return await response.ReadContentAs<List<AccountModel>>();
        }

        public async Task<IEnumerable<AccountModel>> GetOnboarding()
        {
            var response = await _client.GetAsync("/api/v1/GetOnboarding");
            return await response.ReadContentAs<List<AccountModel>>();
        }

        public async Task<string> GetToken(string token)
        {
            var response = await _client.GetAsync($"/api/v1/Account/GetToken/{token}");
            return await response.ReadContentAs<string>();
        }
    }
}
