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
using PROG7312_POE_ST10117020.ModelServer;
using PROG7312_POE_ST10117020.Utility;

namespace PROG7312_POE_ST10117020
{
    /// <summary>
    /// Interaction logic for LeaderBoardWindow.xaml
    /// </summary>
    public partial class LeaderBoardWindow : Window
    {

        private static PROG_ST10117020Context CONTEXT = new PROG_ST10117020Context();

        public LeaderBoardWindow()
        {
            InitializeComponent();
        }

        public void DisplayLeaderboard(string filter)
        {
            LstAnswer.Items.Clear();
            List<LeaderboardItem> leaderboardItems = CONTEXT.LeaderboardItems.OrderByDescending(x => x.LeaderboardScore).ToList(); //odering the Leaderboard items and adding them to a temp list 
            LstAnswer.Items.Add("Rank\tGame\t\tUsername\t\t\tScore");//adding a "header" to the list box 
            int counter = 0;
            foreach (LeaderboardItem item in leaderboardItems) //looping through the list and populating the list box 
            {
                if (item.LeaderboardGameType.Equals(filter))//specifying the Game to Ordering for now 
                {
                    string user = CONTEXT.Users.Where(x => x.UserId.Equals(item.UserId)).FirstOrDefault().UserUsername.ToString();//getting the User's username 
                    if (user.Length >12)
                    {
                        LstAnswer.Items.Add((counter + 1) + "\t" + item.LeaderboardGameType + "\t" + user + "\t\t" + item.LeaderboardScore);
                    }
                    else if (user.Length < 7)
                    {
                        LstAnswer.Items.Add((counter + 1) + "\t" + item.LeaderboardGameType + "\t" + user + "\t\t\t\t" + item.LeaderboardScore);
                    }
                    else
                    {
                        LstAnswer.Items.Add((counter + 1) + "\t" + item.LeaderboardGameType + "\t" + user + "\t\t\t" + item.LeaderboardScore);
                    }

                    
                    counter++;
                }
            }
        }

        public void DisplayLeaderboardAll()
        {
            LstAnswer.Items.Clear();
            List<LeaderboardItem> leaderboardItems = CONTEXT.LeaderboardItems.OrderByDescending(x => x.LeaderboardScore).ToList(); //odering the Leaderboard items and adding them to a temp list 
            LstAnswer.Items.Add("Rank\tGame\t\tUsername\t\t\tScore");//adding a "header" to the list box 
            int counter = 0;
            foreach (LeaderboardItem item in leaderboardItems) //looping through the list and populating the list box 
            {

                    string user = CONTEXT.Users.Where(x => x.UserId.Equals(item.UserId)).FirstOrDefault().UserUsername.ToString();//getting the User's username 
                    if (user.Length > 12)
                    {
                        LstAnswer.Items.Add((counter + 1) + "\t" + item.LeaderboardGameType + "\t" + user + "\t\t" + item.LeaderboardScore);
                    }
                    else if (user.Length < 7)
                    {
                        LstAnswer.Items.Add((counter + 1) + "\t" + item.LeaderboardGameType + "\t" + user + "\t\t\t\t" + item.LeaderboardScore);
                    }
                    else
                    {
                        LstAnswer.Items.Add((counter + 1) + "\t" + item.LeaderboardGameType + "\t" + user + "\t\t\t" + item.LeaderboardScore);
                    }


                    counter++;
                
            }
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            HubWindow HW = new HubWindow();
            this.Hide();
            HW.Show();
        }

        private void RbnModeOrder_Checked(object sender, RoutedEventArgs e)
        {
            DisplayLeaderboard("Ordering");
        }

        private void RbnModeMatching_Checked(object sender, RoutedEventArgs e)
        {
            DisplayLeaderboard("Matching");
        }

        private void RbnModeAll_Checked(object sender, RoutedEventArgs e)
        {
            DisplayLeaderboardAll();
        }

        private void RbnModeQuiz_Checked(object sender, RoutedEventArgs e)
        {
            DisplayLeaderboard("");
        }
    }
}
