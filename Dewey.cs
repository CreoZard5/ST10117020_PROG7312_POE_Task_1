using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020
{
    public class Dewey
    {
        private double number;
        private string letters;
        public Dewey()
        {

        }

        public Dewey(double number, string letters)
        {
            this.Number = number;
            this.Letters = letters;
        }

        public double Number { get => number; set => number = value; }
        public string Letters { get => letters; set => letters = value; }
    }
}
