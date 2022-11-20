using Newtonsoft.Json;
using PROG7312_POE_ST10117020.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PROG7312_POE_ST10117020.TreeClasses
{
    public static class TreeHandeler
    {

        private static TreeNodeHandeler<DeweyDecimal_FindCallNo> tree = new TreeNodeHandeler<DeweyDecimal_FindCallNo>();
        private static Random rnd = new Random();// An object call from the random class to use throughout 


        public static void populateData()
        {
            try
            {
                var jsonText = File.ReadAllText("../deweyData.txt");

                var callNumbers = JsonConvert.DeserializeObject<IList<DeweyDecimal_FindCallNo>>(jsonText);

                tree.Root = new TreeNode<DeweyDecimal_FindCallNo>();

                foreach (DeweyDecimal_FindCallNo item in callNumbers)
                {
                    if (item.classes % 100 == 0 || item.classes == 0)
                    {
                        if (item.classes == 0)
                        {
                            tree.Root.Children = new List<TreeNode<DeweyDecimal_FindCallNo>>()//creates first child(Tier 1)
                        {
                            new TreeNode<DeweyDecimal_FindCallNo>() { Data = item, Parent = tree.Root }
                        };

                            tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))].Children = new List<TreeNode<DeweyDecimal_FindCallNo>>()//creates first child of child (tier 2 ) only 000,200...etc
                        {
                            new TreeNode<DeweyDecimal_FindCallNo>() { Data = item, Parent = tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))] }
                        };
                        }
                        else
                        {
                            tree.Root.Children.Add(new TreeNode<DeweyDecimal_FindCallNo>() { Data = item, Parent = tree.Root });

                            tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))].Children = new List<TreeNode<DeweyDecimal_FindCallNo>>()
                        {
                            new TreeNode<DeweyDecimal_FindCallNo>() { Data = item, Parent = tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))] }
                        };
                        }


                    }//tier 1 (000,100,200 etc)
                    else if (item.classes.ToString("000").Substring(2, 1).Equals("0"))
                    {
                        try
                        {
                            tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))].Children.Add(new TreeNode<DeweyDecimal_FindCallNo>() { Data = item, Parent = tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))] });
                        }
                        catch (Exception)
                        {
                            throw;
                        }

                    }//tier 2 (010,020,030 etc)
                    else
                    {
                        try
                        {
                            int test = item.classes;
                            if (item.classes.ToString("000").Substring(2, 1).Equals("1"))
                            {
                                tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))].
                                    Children[Convert.ToInt32(item.classes.ToString("000").Substring(1, 1))].
                                    Children = new List<TreeNode<DeweyDecimal_FindCallNo>>()
                                    {
                                    new TreeNode<DeweyDecimal_FindCallNo>() { Data = item, Parent = tree.Root.
                                    Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))].
                                    Children[Convert.ToInt32(item.classes.ToString("000").Substring(1, 1))] }
                                    };
                            }
                            else
                            {
                                tree.Root.Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))].
                                    Children[Convert.ToInt32(item.classes.ToString("000").Substring(1, 1))].
                                    Children.Add
                                    (new TreeNode<DeweyDecimal_FindCallNo>()
                                    {
                                        Data = item,
                                        Parent = tree.Root.
                                    Children[Convert.ToInt32(item.classes.ToString("000").Substring(0, 1))].
                                    Children[Convert.ToInt32(item.classes.ToString("000").Substring(1, 1))]
                                    });
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }//tier 3 (011,012,013 etc)
                }
                //MessageBox.Show("");
            }
            catch (Exception)
            {
                MessageBox.Show("It Died");
                throw;
            }
        }

        public static DeweyDecimal_FindCallNo_QuizQuestion GetQuestion()
        {
            string rand = "0";
            bool flag = false;
            DeweyDecimal_FindCallNo_QuizQuestion QQ = new DeweyDecimal_FindCallNo_QuizQuestion();
            DeweyDecimal_FindCallNo answerT1 = new DeweyDecimal_FindCallNo();
            DeweyDecimal_FindCallNo answerT2 = new DeweyDecimal_FindCallNo();
            DeweyDecimal_FindCallNo question = new DeweyDecimal_FindCallNo();

            while (flag == false)
            {
                rand = rnd.Next(1000).ToString("000");
                           
                if (!(rand.Substring(2, 1).Equals("0")))
                {
                    try
                    {
                        if (!tree.Root.Children[Convert.ToInt32(rand.Substring(0, 1))].Children[Convert.ToInt32(rand.Substring(1, 1))].Children[Convert.ToInt32(rand.Substring(2, 1))].Data.details.Equals("Unassigned"))
                        {
                            flag = true;
                        }
                    }
                    catch (Exception)
                    {
                        rand = rnd.Next(1000).ToString("000");
                    }                  
                }
                
            }
            try
            {
                answerT1 = tree.Root.Children[Convert.ToInt32(rand.Substring(0, 1))].Data;
                answerT2 = tree.Root.Children[Convert.ToInt32(rand.Substring(0, 1))].Children[Convert.ToInt32(rand.Substring(1, 1))].Data;
                question = tree.Root.Children[Convert.ToInt32(rand.Substring(0, 1))].Children[Convert.ToInt32(rand.Substring(1, 1))].Children[Convert.ToInt32(rand.Substring(2, 1))].Data;

                QQ.Question = question;
                QQ.AnswerTier1 = answerT1;
                QQ.AnswerTier2 = answerT2;
                return QQ;
            }
            catch (Exception)
            {
                return GetQuestion();

            }


            //TODO: check the details are not undefined 
        }

        public static DeweyDecimal_FindCallNo GetRandomValue_CallNumber_tier1()
        {
            int rand = rnd.Next(10);
            DeweyDecimal_FindCallNo answer = tree.Root.Children[rand].Data;
            return answer;
        }

        public static DeweyDecimal_FindCallNo GetRandomValue_CallNumber_tier2(int tier1)
        {
            int rand = rnd.Next(10);
            DeweyDecimal_FindCallNo answer = tree.Root.Children[tier1].Children[rand].Data;
            return answer;
        }

        public static DeweyDecimal_FindCallNo GetRandomValue_CallNumber_tier3(int tier1,int tier2)
        {
            int rand = rnd.Next(10);
            try 
            {

                DeweyDecimal_FindCallNo answer = tree.Root.Children[tier1].Children[tier2].Children[rand].Data;
                return answer;
            }
            catch
            {
                DeweyDecimal_FindCallNo answer = GetRandomValue_CallNumber_tier3(tier1, tier2);
                return answer;
            }

            

        }
    }
}
