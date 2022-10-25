using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020.Objects
{
    public class DeweyDecimal_MatchingColoums
    {
        public DeweyDecimal_MatchingColoums(string description, int code)
        {
            this.description = description;
            this.code = code;
        }

        public string description { get; set; }
        public int code { get; set; }
    }
}
