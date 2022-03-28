using System;
using System.Collections.Generic;

namespace CoreBankingMiddleware.Models
{
    public class GetBanksResponse
    {
        public List<Result> result { get; set; }
        public string errorMessage { get; set; }
        public List<string> errorMessages { get; set; }
        public bool hasError { get; set; }
        public DateTime timeGenerated { get; set; }
    }
    public class Result
    {
        public string bankName { get; set; }
        public string bankCode { get; set; }
    }
}
