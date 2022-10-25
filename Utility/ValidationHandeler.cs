using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PROG7312_POE_ST10117020.ModelServer;

namespace PROG7312_POE_ST10117020.Utility
{
    public class ValidationHandeler
    {

        public static string CheckUser(string UserName, string UserEmail, string UserPassword)
        {
            string review = "";

            if (IsValidPassword(UserPassword) == false || (UserPassword.Length <= 0 || UserPassword.Length > 20) == true)
            {
                review += "\nplease enter a Valid password,\n the password must atleast :\n 8 characters length,\n 2 letters in Upper Case,\n 1 Special Character(!@#$&*),\n 2 numerals (0-9),\n 3 letters in Lower Case";
            }
            else
            {

            }

            //check if the User Name is valid             
            if ((UserName.Length <= 0 || UserName.Length > 20) == true)
            {
                review += "\nplease enter a Valid Username,\n the Name must contain Morethan 0 and less than 20 characters\n";
            }
            else
            {

            }

            //check if the User email is valid 
            if (IsValidEmail(UserEmail) == false || (UserEmail.Length <= 0 || UserEmail.Length > 50) == true)
            { 
                review += "\nplease enter a Valid Email,\n in the format Valid@email.com\n";
            }
            else
            {

            }
            //Returning the errors if any is applicable
            return review;
        }

        public static bool Checker(string ID)
        {//a method to check if the user ID i exists 
            PROG_ST10117020Context context = new PROG_ST10117020Context();
            bool result = true;

            foreach (User item in context.Users)
            {
                if (ID == item.UserId)
                {
                    result = false;

                }
            }
            return result;
        }

        public static bool CheckerLeaderboard(string ID)
        {//a method to check is the Leaderboard ID exists 
            PROG_ST10117020Context context = new PROG_ST10117020Context();
            bool result = true;

            foreach (LeaderboardItem item in context.LeaderboardItems)
            {
                if (ID == item.LeaderboardId)
                {
                    result = false;

                }
            }
            return result;
        }

        public static string GetID()
        {//generate a user ID 
            string ID;
            int extra = 1;
            string temp = "";
            string sub = "U";

            if (extra.ToString().Length == 1)
            {
                temp = "0" + extra.ToString();
                ID = sub + temp;
            }
            else
            {
                ID = sub + extra.ToString();
            }

            while (Checker(ID) == false)
            {
                if (extra.ToString().Length == 1)
                {
                    temp = "0" + extra.ToString();
                    ID = sub + temp;
                }
                else if (extra.ToString().Length >= 3)
                {
                    break;
                }
                else
                {
                    ID = sub + extra.ToString();
                }
                extra++;

            }
            return ID;
        }

        public static string GetLeaderBoardID()
        {
            //generate a Leaderboard ID 
            string ID;
            int extra = 1;
            string temp = "";
            string sub = "L";

            if (extra.ToString().Length == 1)
            {
                temp = "0" + extra.ToString();
                ID = sub + temp;
            }
            else
            {
                ID = sub + extra.ToString();
            }

            while (CheckerLeaderboard(ID) == false)
            {
                if (extra.ToString().Length == 1)
                {
                    temp = "0" + extra.ToString();
                    ID = sub + temp;
                }
                else if (extra.ToString().Length >= 3)
                {
                    break;
                }
                else
                {
                    ID = sub + extra.ToString();
                }
                extra++;

            }
            return ID;
        }

        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            if (RegexHandler.PasswordCheck.IsMatch(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
