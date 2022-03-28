using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class tbl_State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public List<tbl_lga> tbllgas { get; set; } = new List<tbl_lga>();
    }
}
