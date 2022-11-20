using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PROG7312_POE_ST10117020.ModelServer;
using PROG7312_POE_ST10117020.Objects;
using PROG7312_POE_ST10117020.TreeClasses;
using PROG7312_POE_ST10117020.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PROG7312_POE_ST10117020
{
    /// <summary>
    /// Interaction logic for FindingCallNumbers.xaml
    /// </summary>
    public partial class FindingCallNumbers : Window
    {

        public FindingCallNumbers()
        {
            InitializeComponent();
            TreeHandeler.populateData();
            PopulateGame();

        }

        private static DeweyDecimal_FindCallNo_QuizQuestion QuizQAndA;//= TreeHandeler.GetQuestion()
        private static bool tier1, tier2, tier3;
        private static int points=0,count=0;
        private readonly PROG_ST10117020Context CONTEXT = new PROG_ST10117020Context();

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            //navigation to the hub window 
            HubWindow HW = new HubWindow();
            this.Hide();
            HW.Show();
            CalculateScore();
        }

        public void PopulateGame()
        {
            List<DeweyDecimal_FindCallNo> Answers = new List<DeweyDecimal_FindCallNo>();
            QuizQAndA = TreeHandeler.GetQuestion();
            Answers.Add(QuizQAndA.AnswerTier1);
            tier1 = true;
            tier2 = false;
            tier3 = false;
            while (Answers.Count() != 4)
            {
                DeweyDecimal_FindCallNo D = TreeHandeler.GetRandomValue_CallNumber_tier1();
                if (!Answers.Contains(D))
                {
                    Answers.Add(D);
                }
            }
            
            LblDescription.Text = QuizQAndA.Question.details;
            Answers = Answers.OrderBy(x => x.classes).ToList();
            AddPossibleAnswers(Answers);
        }

        public void PopulateGameTier2()
        {
            List<DeweyDecimal_FindCallNo> Answers = new List<DeweyDecimal_FindCallNo>();
            Answers.Add(QuizQAndA.AnswerTier2);
            tier1 = false;
            tier2 = true;
            tier3 = false;
            while (Answers.Count() != 4)
            {
                DeweyDecimal_FindCallNo D = TreeHandeler.GetRandomValue_CallNumber_tier2(Convert.ToInt32(QuizQAndA.Question.classes.ToString("000").Substring(0, 1)));
                if (!Answers.Contains(D))
                {
                    Answers.Add(D);
                }
            }

            LblDescription.Text = QuizQAndA.Question.details;
            Answers = Answers.OrderBy(x => x.classes).ToList();
            AddPossibleAnswers(Answers);
        }

        public void PopulateGameTier3()
        {
            List<DeweyDecimal_FindCallNo> Answers = new List<DeweyDecimal_FindCallNo>();
            Answers.Add(QuizQAndA.Question);
            tier1 = false;
            tier2 = false;
            tier3 = true;

            while (Answers.Count() != 4)
            {
                DeweyDecimal_FindCallNo D = TreeHandeler.GetRandomValue_CallNumber_tier3(Convert.ToInt32(QuizQAndA.Question.classes.ToString("000").Substring(0, 1)), Convert.ToInt32(QuizQAndA.Question.classes.ToString("000").Substring(1, 1)));
                if (!Answers.Contains(D))
                {
                    Answers.Add(D);
                }
            }

            LblDescription.Text = QuizQAndA.Question.details;
            Answers = Answers.OrderBy(x => x.classes).ToList();
            AddPossibleAnswers(Answers);
        }

        public void AddPossibleAnswers(List<DeweyDecimal_FindCallNo> PossibleAnswers)
        {
            if (tier3)
            {
                Txb1.Text = PossibleAnswers[0].classes.ToString("000");
                Txb2.Text = PossibleAnswers[1].classes.ToString("000");
                Txb3.Text = PossibleAnswers[2].classes.ToString("000");
                Txb4.Text = PossibleAnswers[3].classes.ToString("000");
            }
            else
            {

                Txb1.Text = PossibleAnswers[0].details + " " + PossibleAnswers[0].classes.ToString("000");
                Txb2.Text = PossibleAnswers[1].details + " " + PossibleAnswers[1].classes.ToString("000");
                Txb3.Text = PossibleAnswers[2].details + " " + PossibleAnswers[2].classes.ToString("000");
                Txb4.Text = PossibleAnswers[3].details + " " + PossibleAnswers[3].classes.ToString("000");

            }


        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        public void ResetRadioButtons()
        {
            Rbn1.IsChecked = false;
            Rbn2.IsChecked = false;
            Rbn3.IsChecked = false;
            Rbn4.IsChecked = false;
        }

        private void BtnProceed_Click(object sender, RoutedEventArgs e)
        {
            if (tier1)
            {
                if (Rbn1.IsChecked == true)
                {
                    string Userans = Txb1.Text.Substring(Txb1.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 1);

                    if (Userans.Equals(ans + "00"))
                    {
                        PopulateGameTier2();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }

                }
                if (Rbn2.IsChecked == true)
                {
                    string Userans = Txb2.Text.Substring(Txb2.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 1);

                    if (Userans.Equals(ans + "00"))
                    {
                        PopulateGameTier2();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
                if (Rbn3.IsChecked == true)
                {
                    string Userans = Txb3.Text.Substring(Txb3.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 1);

                    if (Userans.Equals(ans + "00"))
                    {
                        PopulateGameTier2();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
                if (Rbn4.IsChecked == true)
                {
                    string Userans = Txb4.Text.Substring(Txb4.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 1);

                    if (Userans.Equals(ans + "00"))
                    {
                        PopulateGameTier2();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count= count + 1;
                        updateScore();


                    }
                }
            }
            if (tier2)
            {
                if (Rbn1.IsChecked == true)
                {
                    string Userans = Txb1.Text.Substring(Txb1.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 2);

                    if (Userans.Equals(ans + "0"))
                    {
                        PopulateGameTier3();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }

                }
                if (Rbn2.IsChecked == true)
                {
                    string Userans = Txb2.Text.Substring(Txb2.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 2);

                    if (Userans.Equals(ans + "0"))
                    {
                        PopulateGameTier3();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
                if (Rbn3.IsChecked == true)
                {
                    string Userans = Txb3.Text.Substring(Txb3.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 2);

                    if (Userans.Equals(ans + "0"))
                    {
                        PopulateGameTier3();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
                if (Rbn4.IsChecked == true)
                {
                    string Userans = Txb4.Text.Substring(Txb4.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000").Substring(0, 2);

                    if (Userans.Equals(ans + "0"))
                    {
                        PopulateGameTier3();
                        ResetRadioButtons();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
            }
            if (tier3)
            {
                if (Rbn1.IsChecked == true)
                {
                    string Userans = Txb1.Text.Substring(Txb1.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000");

                    if (Userans.Equals(ans))
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        points = points + 1;
                        count = count + 1;
                        updateScore();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }

                }
                if (Rbn2.IsChecked == true)
                {
                    string Userans = Txb2.Text.Substring(Txb2.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000");

                    if (Userans.Equals(ans))
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        points = points + 1;
                        count = count + 1;
                        updateScore();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
                if (Rbn3.IsChecked == true)
                {
                    string Userans = Txb3.Text.Substring(Txb3.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000");

                    if (Userans.Equals(ans))
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        points = points + 1;
                        count = count + 1;
                        updateScore();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
                if (Rbn4.IsChecked == true)
                {
                    string Userans = Txb4.Text.Substring(Txb4.Text.Length - 3, 3);
                    string ans = QuizQAndA.Question.classes.ToString("000");

                    if (Userans.Equals(ans))
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        points = points + 1;
                        count = count + 1;
                        updateScore();
                    }
                    else
                    {
                        PopulateGame();
                        ResetRadioButtons();
                        count = count + 1;
                        updateScore();
                    }
                }
            }
        }

        private void CalculateScore()
        {
            double Score;
            if (count != 0)
            {
                double test = (double)points / (double)count;
                Score = Math.Round(test * 100);
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "FindCallNumber", Convert.ToInt32(Math.Round(Score)), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();
            }
            else
            {
                Score = 0;
            }
            points = 0;
            count = 0;
        }

        public void updateScore()
        {
            lblscore.Content = "Score: " + points + "/" + count;
        }
    }
}
