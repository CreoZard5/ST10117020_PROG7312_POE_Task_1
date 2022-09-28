using System;
using System.Collections.Generic;
using System.Linq;
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

            //check if the User Name is valid 
            if (UserName.Length <= 0 || UserName.Length > 20)
            {
                review += "please enter a Valid Username, the Name must contain Morethan 0 and less than 20 characters";
            }

            //check if the User email is valid 
            if (UserEmail.Length == 0 || UserEmail.Length > 50)
            {
                review += "please enter a Valid Email, the Email must contain Morethan 0 and less than 20 characters";
            }



            //Returning the errors if any is applicable
            return review;
        }

        public static bool Checker(string ID)
        {
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
        {
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
        {
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
    }
}
