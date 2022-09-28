using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020
{
    public class Dewey
    {//an object to split the call number to numbeers and letters for easier sorting 
        private double number;
        private string letters;

        //an empty constructor 
        public Dewey()
        {

        }

        //a regular constructor 
        public Dewey(double number, string letters)
        {
            this.Number = number;
            this.Letters = letters;
        }

        public double Number { get => number; set => number = value; }
        public string Letters { get => letters; set => letters = value; }
    }
}
