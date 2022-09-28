using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020.Utility
{
    public class RegexHandler
    {
        public static Regex ReLettersOnly = new Regex("/[^a-zA-Z' ']/g");

        public static Regex ReNumbersOnly = new Regex("^[0-9]+$");

        public static Regex UsableYears = new Regex("^20[1-9] [0-9]$");

        public static Regex ModuleCode = new Regex("^[^a-zA-Z] [^a-zA-Z] [^a-zA-Z] [^a-zA-Z] [1-9] [0-9] [1-9] [0-9] [1-9] [0-9] [1-9] [0-9]$");

       // public static Regex EmailCheck = new Regex("^[^@\s]+@[^@\s]+\.(com|net|org|gov)$")


    }
}
