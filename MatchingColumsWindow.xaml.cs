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
using System.Windows.Threading;
using PROG7312_POE_ST10117020.ModelServer;
using PROG7312_POE_ST10117020.Objects;
using PROG7312_POE_ST10117020.Utility;

namespace PROG7312_POE_ST10117020
{
    /// <summary>
    /// Interaction logic for MatchingColumsWindow.xaml
    /// </summary>
    
    //TODO: add to DB and add identify to leaderboard 
    //TODO: add timer 
    //TODO: Error handeling 


    public partial class MatchingColumsWindow : Window
    {


        // An object call from the random class to use throughout 
        public static Random rnd = new Random();



        //A variable to store the users points for the current game 
        public int points;


        private DispatcherTimer dispatcherTimer = new DispatcherTimer();//the timer
        private DateTime startTime;
        private DateTime endTime;
        private readonly PROG_ST10117020Context CONTEXT = new PROG_ST10117020Context();

        public MatchingColumsWindow()
        {
            InitializeComponent();
            WpnlQuestion.IsEnabled = false;
            ListHandeler.PopDictionary();

        }


        private void WpnlQuestion_Drop(object sender, DragEventArgs e)
        {

        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Updating the Label which displays the current second
            lblTimer.Content = (DateTime.Now - startTime).Hours.ToString("00") + ":" + (DateTime.Now - startTime).Minutes.ToString("00") + ":" + (DateTime.Now - startTime).Seconds.ToString("00"); //"mm:ss"

            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
            /*
            Code Atribution
            Author:WPF Tutorial
            Date:Nov 13, 2021
            URL:https://wpf-tutorial.com/misc/dispatchertimer/
            */
        }

        private void WpnlUAnswer_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (WpnlUAnswer.Children.Contains(e.Data.GetData(typeof(Answer_MatchColoums)) as Answer_MatchColoums))
                {
                    return;
                }
                else
                {
                    if (WpnlUAnswer.Children.Count < 4)//only 4 answers are allowed
                    {
                        //getting the User control object selected 
                        var obj = e.Data.GetData(typeof(Answer_MatchColoums)) as Answer_MatchColoums;

                        //removes the object from one wrap panel 
                        WpnlAnswers.Children.Remove(obj);

                        //adds the object to the desired wrap panel
                        WpnlUAnswer.Children.Add(obj);
                    }
                    else
                    {
                        MessageBox.Show("you are only allowed 4 answers");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
           


        }

        private void WpnlAnswers_Drop(object sender, DragEventArgs e)
        {
            try
            {
                if (WpnlAnswers.Children.Contains(e.Data.GetData(typeof(Answer_MatchColoums)) as Answer_MatchColoums))
                {
                    return;
                }
                else
                {
                    var obj = e.Data.GetData(typeof(Answer_MatchColoums)) as Answer_MatchColoums;

                    if (!(WpnlAnswers.Children.Contains(obj)))
                    {
                        //removes the object from one wrap panel
                        WpnlUAnswer.Children.Remove(obj);

                        //adds the object to the desired wrap panel
                        WpnlAnswers.Children.Add(obj);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        public void PopulateGame()
        {
            //clearing all wrap panels
            WpnlAnswers.Children.Clear();
            WpnlQuestion.Children.Clear();
            WpnlUAnswer.Children.Clear();
            List<string> TemplistAns = ListHandeler.RandomAnswers();
            List<string> TemplistQ = ListHandeler.RandomQuestions();
            //populating data 
            for (int i = 0; i < ListHandeler.Questions.Count; i++)
            {

                //creating an instance of the User control class Answer_MatchColoums
                Answer_MatchColoums Ans = new Answer_MatchColoums();

                //Populating the user control text 
                Ans.Text = TemplistQ.ElementAt(i);

                //adding the user control component to the wraap panlel
                WpnlQuestion.Children.Add(Ans);
            }

            for (int i = 0; i < ListHandeler.Answers.Count; i++)
            {
                //creating an instance of the User control class Answer_MatchColoums
                Answer_MatchColoums Ans = new Answer_MatchColoums();

                //Populating the user control text
                Ans.Text = TemplistAns.ElementAt(i);

                //adding the user control component to the wraap panlel
                WpnlAnswers.Children.Add(Ans);
            }

        }

        public void GetScore()
        {
            points = 0;
            string value;
            string key;

            if (RbnModeCode.IsChecked == true)
            {
                if (WpnlUAnswer.Children.Count == 4)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        //getting key value 
                        key = ((Answer_MatchColoums)WpnlQuestion.Children[i]).Text.ToString();
                        //getting value stored in dictionary 
                        value = ((Answer_MatchColoums)WpnlUAnswer.Children[i]).Text.ToString();


                        //adding points only if the anwer and value corrosponds 
                        if (ListHandeler.DeweyInformation1.ContainsKey(Convert.ToInt32(key)) && ListHandeler.DeweyInformation1[Convert.ToInt32(key)].Equals(value))
                        {
                            points++;
                        }

                    }
                    //MessageBox.Show("Points are :" + points);
                }
                else
                {
                    MessageBox.Show("Please complete game before submitting answers");
                }
            }
            else
            {
                if (WpnlUAnswer.Children.Count == 4)
                {

                    for (int i = 0; i < 4; i++)
                    {
                        //getting key value 
                        key = ((Answer_MatchColoums)WpnlUAnswer.Children[i]).Text.ToString();

                        //getting value stored in dictionary 
                        value = ((Answer_MatchColoums)WpnlQuestion.Children[i]).Text.ToString();

                        //adding points only if the anwer and value corrosponds 
                        if (ListHandeler.DeweyInformation1.ContainsKey(Convert.ToInt32(key)) && ListHandeler.DeweyInformation1[Convert.ToInt32(key)].Equals(value))
                        {
                            points++;
                        }

                    }
                    MessageBox.Show("Points are :" + points);
                }
                else
                {
                    MessageBox.Show("Please complete game before submitting answers");
                }
            }

            
        }

        private void BtnCode1_Click(object sender, RoutedEventArgs e)
        {
           
            dispatcherTimer.Stop();
            endTime = DateTime.Now;
            GetScore();
            double timeMultiplier = (endTime.TimeOfDay - startTime.TimeOfDay).TotalSeconds;

            if (timeMultiplier / 60 <= 1)
            {
                LblPoints.Content = (points * 25).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Matching", (points * 25), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }
            else if (timeMultiplier / 60 > 1 && timeMultiplier / 60 <= 7)

            {
                LblPoints.Content = (points * 20).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Matching", (points * 20), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }
            else if (timeMultiplier / 60 > 7 && timeMultiplier / 60 <= 13)
            {
                LblPoints.Content = (points * 15).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Matching", (points * 15), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }
            else
            {
                LblPoints.Content = (points * 10).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Matching", (points * 10), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }

        }


        private void RbnModeDesc_Checked(object sender, RoutedEventArgs e)
        {
            ListHandeler.GameRefreshCodes();
            PopulateGame();
            TimerStart();
        }

        private void RbnModeCode_Checked(object sender, RoutedEventArgs e)
        {
            ListHandeler.GameRefreshDesc();
            PopulateGame();
            TimerStart();
        }

        public void TimerStart()
        {
            startTime = DateTime.Now;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);//setting the timer to every second 

            dispatcherTimer.Start();
            /*
            Code Atribution
            Author:WPF Tutorial
            Date:Nov 13, 2021
            URL:https://wpf-tutorial.com/misc/dispatchertimer/
            */
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            //navigation to the hub window 
            HubWindow HW = new HubWindow();
            this.Hide();
            HW.Show();
        }

        private void BtnInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To play first select a mode i.e matching numbers to descriptions or descriptions to numbers,\n" +
                            "then you will drag from your possible answers to the 'place answers here' \n" +
                            "then click submit to proceed and get you score ","Grimoire Catcher");
        }
    }
}
