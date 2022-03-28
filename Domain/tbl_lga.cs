using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class tbl_lga
    {
        public int Id { get; set; }
        public string LgaName { get; set; }
        public int StateId { get; set; }
        public tbl_State tblStates { get; set; }
    }
}
