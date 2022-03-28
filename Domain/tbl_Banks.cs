using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class tbl_Banks
    {
        public long Id { get; set; }
        public string BankName { get; set; }
        public string BankCode { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
