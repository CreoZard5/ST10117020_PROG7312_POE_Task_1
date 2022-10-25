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
        public static Regex ReLettersOnly = new Regex("/[^a-zA-Z' ']/g");//regex for letters only 

        public static Regex ReNumbersOnly = new Regex("^[0-9]+$");//regex for numbers only 

        public static Regex UsableYears = new Regex("^20[1-9] [0-9]$");//regex for proper years 

        /* check if password contains atleast :
         * 8 characters length 
         * 2 letters in Upper Case 
         * 1 Special Character(!@#$&*) 
         * 2 numerals (0-9) 
         * 3 letters in Lower Case*/

        public static Regex PasswordCheck = new Regex("^(?=(.*[a-z]){3,})(?=(.*[A-Z]){2,})(?=(.*[0-9]){2,})(?=(.*[!@#$%/^&*()-__+.]){1,}).{8,}$");



    }
}
