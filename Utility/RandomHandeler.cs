using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020.Utility
{
    internal class RandomHandeler
    {
        public static Random rnd = new Random();// An object call from the random class to use throughout 

        public static double RandomNumber()
        {
            //Calling the random class the 3 digits before the point 
            double rand = rnd.Next(0, 1000);
            //Calling the random class the 2 digits after the point 
            double rand2 = rnd.Next(0, 100);
            //adding the number to form a complete double 
            double randomNumber = rand + (rand2 / 100);

            return randomNumber;
        }
        public static string RandomStrings()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());

            /*
             Code Atribution
            Author:dtb , Wai Ha Lee
            Date:Nov 13, 2021
            URL:https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
            */
        }
    }
}
