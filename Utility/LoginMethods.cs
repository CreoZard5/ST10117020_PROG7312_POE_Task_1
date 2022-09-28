using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PROG7312_POE_ST10117020.ModelServer;

namespace PROG7312_POE_ST10117020.Utility
{
    public class LoginMethods
    {
       // private static readonly PROG_ST10117020Context CONTEXT = new PROG_ST10117020Context();


        //method to check if the user can log in 
        public static bool CanLogIn(string UserEmail, string UserPassword)
        {
            PROG_ST10117020Context _context = new PROG_ST10117020Context();

            string temp = PassWordHash(UserPassword);
            //SQL code to check if this user can check in 
            var q = (from s in _context.Users where s.UserEmail.Equals(UserEmail) && s.UserPassword.Equals(temp) select s);

            //if statement to chek if the found student has any values 
            if (q.Any() == true)
            {
                User user = (from s in _context.Users where s.UserEmail.Equals(UserEmail) && s.UserPassword.Equals(temp) select s).FirstOrDefault();
                CurrentUser.U = user;
                return true;
            }
            else
            {
                return false;
            }

        }

        //method to had the password 
        public static string PassWordHash(string Password)
        {//https://www.c-sharpcorner.com/article/hashing-passwords-in-net-core-with-tips/
         //Hashing Passwords In .NET Core With Tips
         //2021/10/17
            using (var sha256 = SHA256.Create())//making the hash sytle sha256
            {
                //hashing the password to a Byte[]
                var Hashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                //converting the Hash code to string to be readable
                string PasswordHash = BitConverter.ToString(Hashed).Replace("-", "").ToLower();

                return PasswordHash;
            }

        }
    }
}
