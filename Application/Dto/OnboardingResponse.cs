using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class OnboardingResponse
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StateofResidence { get; set; }
        public string LGA { get; set; }
    }
}
