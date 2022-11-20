using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020.Objects
{
    public class DeweyDecimal_FindCallNo
    {
        public DeweyDecimal_FindCallNo()
        {

        }

        public DeweyDecimal_FindCallNo(int classes, string details)
        {
            this.classes = classes;
            this.details = details;
        }

        public int classes { get; set; }
        public string details { get; set; }
    }
}
