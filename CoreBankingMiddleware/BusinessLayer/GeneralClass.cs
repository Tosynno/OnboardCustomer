using CoreBankingMiddleware.Models;
using Domain;
using Infrastructure.DataContext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreBankingMiddleware.BusinessLayer
{
    public class GeneralClass
    {
        //private readonly string connectionUrl;
        //private IConfiguration Configuration;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly AppDbContext _dbContext;
        private readonly ApiSettings _apiSettings;
        public GeneralClass(AppDbContext dbContext, IOptions<ApiSettings> apiSettings)
        {
            //connectionUrl = Configuration.GetValue<string>("ApiSettings:BankUrl");
            _dbContext = dbContext;
            _apiSettings = apiSettings.Value;
        }
        internal async Task<List<Result>> GetBank()
        {
            var alldto = new List<Result>();
            var dto = new Result();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _apiSettings.WemaAPISubscriptionKey);
            var response = await _httpClient.GetAsync(_apiSettings.BankUrl);
            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsAsync<GetBanksResponse>();
                if (res.hasError == false)
                {
                    tbl_Banks sa = new tbl_Banks();
                    foreach (var item in res.result)
                    {
                        dto = new Result();
                        dto.bankName = item.bankName;
                        dto.bankCode = item.bankCode;
                        alldto.Add(dto);
                        sa.BankCode = item.bankCode;
                        sa.BankName = item.bankName;
                        await _dbContext.tbl_banks.AddAsync(sa);
                    }
                   
                    await _dbContext.SaveChangesAsync();
                }
            }

            return alldto;
        }
    }
}
