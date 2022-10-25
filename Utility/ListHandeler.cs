using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE_ST10117020.Utility
{
    public class ListHandeler
    {

        private static List<Dewey> deweys = new List<Dewey>();//A list of Dewey objects
        private static List<string> StringRandomList = new List<string>();//A list of strings that have the same data as above to use for display 
        private static List<string> StringSorted = new List<string>();//A sorted lst of strings that is used for camparison 
        private static List<string> answers = new List<string>(); //temp list to store the answers
        private static List<string> questions = new List<string>();//Temp list to store the answers
        private static Dictionary<int, string> deweyInformation = new Dictionary<int, string>();//dictionary to stor the Questions with thier answers        

        public static List<Dewey> Deweys { get => deweys; set => deweys = value; }
        public static List<string> StringRandomList1 { get => StringRandomList; set => StringRandomList = value; }
        public static List<string> StringSorted1 { get => StringSorted; set => StringSorted = value; }
        public static List<string> Answers { get => answers; set => answers = value; }
        public static List<string> Questions { get => questions; set => questions = value; }
        public static Dictionary<int, string> DeweyInformation1 { get => deweyInformation; set => deweyInformation = value; }

        public static List<string> RandomizeList(List<string> lst)
        {
            /*
            Code Atribution
            Author:techiedelight
            Date:23/10/2022
            URL:https://www.techiedelight.com/randomize-a-list-in-csharp/
            */
            return lst.OrderBy(c => RandomHandeler.rnd.Next()).ToList();
        }

        public static List<string> RandomAnswers()
        {
            return RandomizeList(answers);
        }

        public static List<string> RandomQuestions()
        {
            return RandomizeList(questions);
        }

        public static void PopulateArray()
        {
            Deweys.Clear();
            for (int i = 0; i < 10; i++)
            {
                Dewey d = new Dewey(RandomHandeler.RandomNumber(), RandomHandeler.RandomStrings());
                Deweys.Add(d);
                StringRandomList1.Add(d.Number.ToString("000.00") + " " + d.Letters);

            }

        }

        public static void SortArray()
        {
            List<Dewey> SortedList = Deweys.OrderBy(o => o.Letters).OrderBy(o => o.Number).ToList();//sorting the Lists 
            StringSorted1.Clear();
            foreach (Dewey item in SortedList)
            {
                StringSorted1.Add(item.Number.ToString("000.00") + " " + item.Letters);//getting the string sorted list to compare 
            }

   
        }

        public static void answerClear()
        {
            answers.Clear();
        }

        public static void questionsClear()
        {
            questions.Clear();
        }

        public static void Clear()
        {
            answers.Clear();
        }

        public static void PopDictionary()
        {
            //method for populating the dictionary 
            DeweyInformation1.Clear();
            DeweyInformation1.Add(000, "General Knowledge");
            DeweyInformation1.Add(100, "Philosophy & Psychology");
            DeweyInformation1.Add(200, "Religion");
            DeweyInformation1.Add(300, "Social Sciences");
            DeweyInformation1.Add(400, "Language");
            DeweyInformation1.Add(500, "Science");
            DeweyInformation1.Add(600, "Technology");
            DeweyInformation1.Add(700, "Arts & Recreation ");
            DeweyInformation1.Add(800, "Literature");
            DeweyInformation1.Add(900, "History and Geography");
        }

        public static void GameRefreshCodes()
        {
            //creating a variable to use for storing the random value 
            int rand2;

            //clearing the Lists 
            answers.Clear();
            questions.Clear();

            //populating the questions and answers
            while (answers.Count < 4)
            {
                rand2 = RandomHandeler.rnd.Next(10);

                if (!answers.Contains(deweyInformation.ElementAt(rand2).Key.ToString("000")))
                {
                    answers.Add(deweyInformation.ElementAt(rand2).Key.ToString("000"));
                    questions.Add(deweyInformation.ElementAt(rand2).Value.ToString());
                }
            }

            //adding 3 random answers to confuse the user 
            while (Answers.Count < 7)
            {
                rand2 = RandomHandeler.rnd.Next(10);

                if (!Answers.Contains(deweyInformation.ElementAt(rand2).Key.ToString("000")))
                {
                    Answers.Add(deweyInformation.ElementAt(rand2).Key.ToString("000"));
                }
            }

        }

        public static void GameRefreshDesc()
        {
            //Calling the random class the number
            int rand2;
            answers.Clear();
            questions.Clear();

            //populating the questions and answers
            while (answers.Count < 4)
            {
                rand2 = RandomHandeler.rnd.Next(9);

                if (!answers.Contains(deweyInformation.ElementAt(rand2).Value.ToString()))
                {
                    answers.Add(deweyInformation.ElementAt(rand2).Value.ToString());
                    questions.Add(deweyInformation.ElementAt(rand2).Key.ToString("000"));
                }
            }

            //adding 3 random answers to confuse the user
            while (answers.Count < 7)
            {
                rand2 = RandomHandeler.rnd.Next(9);

                if (!answers.Contains(deweyInformation.ElementAt(rand2).Value.ToString()))
                {
                    answers.Add(deweyInformation.ElementAt(rand2).Value.ToString());
                }
            }

        }
    }
}
