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

namespace PROG7312_POE_ST10117020
{
    /// <summary>
    /// Interaction logic for HubWindow.xaml
    /// </summary>
    public partial class HubWindow : Window
    {
        private static PROG_ST10117020Context CONTEXT = new PROG_ST10117020Context();

        public HubWindow()
        {
            InitializeComponent();

        }
        private void BtnReplacingBooks_Click(object sender, RoutedEventArgs e)
        {
            OrderingPage OP = new OrderingPage();
            this.Hide();
            OP.Show();
        }

        private void BtnLeaderBoard_Click(object sender, RoutedEventArgs e)
        {
            LeaderBoardWindow LW = new LeaderBoardWindow();
            this.Hide();
            LW.Show();
        }

        private void BtnIdentifyingAreas_Click(object sender, RoutedEventArgs e)
        {
            MatchingColumsWindow MCW = new MatchingColumsWindow();
            this.Hide();
            MCW.Show();
        }

        private void BtnFindingCallNumbers_Click(object sender, RoutedEventArgs e)
        {
            FindingCallNumbers FCN = new FindingCallNumbers();
            this.Hide();
            FCN.Show();
        }
    }
}
