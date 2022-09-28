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
            DisplayLeaderboard();


        }

        public void DisplayLeaderboard()
        {
            List<LeaderboardItem> leaderboardItems = CONTEXT.LeaderboardItems.OrderByDescending(x => x.LeaderboardScore).ToList();
            LstAnswer.Items.Add("Rank\tGame\t\tUsername\t\t\tScore");
            int counter = 0;
            foreach (LeaderboardItem item in leaderboardItems)
            {
                if (item.LeaderboardGameType.Equals("Ordering"))
                {
                    string user = CONTEXT.Users.Where(x => x.UserId.Equals(item.UserId)).FirstOrDefault().UserUsername.ToString();
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

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            HubWindow HW = new HubWindow();
            this.Hide();
            HW.Show();
        }
    }
}
