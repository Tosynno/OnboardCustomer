using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class tbl_Onboarding
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StateofResidence { get; set; }
        public string LGA { get; set; }
        public string HashPassword { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
