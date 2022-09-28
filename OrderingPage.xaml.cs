using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
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
using PROG7312_POE_ST10117020.Utility;

namespace PROG7312_POE_ST10117020
{
    /// <summary>
    /// Interaction logic for OrderingPage.xaml
    /// </summary>
    public partial class OrderingPage : Window
    {
        public static Random rnd = new Random();// An object call from the random class to use throughout 
        private List<Dewey> deweys = new List<Dewey>();//A list of Dewey objects
        private List<string> StringRandomList = new List<string>();//A list of strings that have the same data as above to use for display 
        private ObservableCollection<string> StringObvRandomList = new ObservableCollection<string>();//An Observable list of strings that will be minipulted by the user 
        private List<string> StringSorted = new List<string>();//A sorted lst of strings that is used for camparison 
        public DispatcherTimer dispatcherTimer = new DispatcherTimer();//the timer
        public int Points;
        private DateTime startTime ;
        private DateTime endTime ;
        private readonly PROG_ST10117020Context CONTEXT = new PROG_ST10117020Context();

        public OrderingPage()
        {
            InitializeComponent();
            PopulateArray();
            PopulateButtons();
            TimerStart();
            SortArray(deweys);
            GrpAnswer.Visibility = Visibility.Hidden;

        }

        private void BtnCode1_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode1.Background == Brushes.White)
            {
                
                BtnCode1.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode1.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode1.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode1.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode1.Background = Brushes.White;
                BtnCode1.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode2_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode2.Background == Brushes.White)
            {
                BtnCode2.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode2.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode2.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode2.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode2.Background = Brushes.White;
                BtnCode2.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode3_Click(object sender, RoutedEventArgs e)
        {


            if (BtnCode3.Background == Brushes.White)
            {
                BtnCode3.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode3.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode3.Content.ToString());
                //LstDeweys.Items.Remove(BtnCode1.Content);
                LstDeweys.ItemsSource = this.StringObvRandomList;
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode3.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode3.Background = Brushes.White;
                BtnCode3.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode4_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode4.Background == Brushes.White)
            {
                BtnCode4.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode4.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode4.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode4.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode4.Background = Brushes.White;
                BtnCode4.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode5_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode5.Background == Brushes.White)
            {
                BtnCode5.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode5.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode5.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;

                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode5.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode5.Background = Brushes.White;
                BtnCode5.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode6_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode6.Background == Brushes.White)
            {
                BtnCode6.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode6.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode6.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode6.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode6.Background = Brushes.White;
                BtnCode6.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode7_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode7.Background == Brushes.White)
            {
                BtnCode7.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode7.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode7.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode7.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode7.Background = Brushes.White;
                BtnCode7.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode8_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode8.Background == Brushes.White)
            {
                BtnCode8.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode8.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode8.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode8.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode8.Background = Brushes.White;
                BtnCode8.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode9_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode9.Background == Brushes.White)
            {
                BtnCode9.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode9.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode9.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode9.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode9.Background = Brushes.White;
                BtnCode9.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnCode10_Click(object sender, RoutedEventArgs e)
        {

            if (BtnCode10.Background == Brushes.White)
            {
                BtnCode10.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
                BtnCode10.Foreground = Brushes.White;
                StringObvRandomList.Remove(BtnCode10.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                //LstDeweys.Items.Remove(BtnCode1.Content);
            }
            else
            {
                //LstDeweys.Items.Add(BtnCode1.Content);
                StringObvRandomList.Add(BtnCode10.Content.ToString());
                LstDeweys.ItemsSource = this.StringObvRandomList;
                BtnCode10.Background = Brushes.White;
                BtnCode10.Foreground = (SolidColorBrush)new BrushConverter().ConvertFrom("#2E003E");
            }
        }
        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            dispatcherTimer.Stop();
            endTime = DateTime.Now;
            CompareList();
            double timeMultiplier = ( endTime.TimeOfDay - startTime.TimeOfDay).TotalSeconds;
            //double timeInMinutes = timeMultiplier / 60;
            // TODO: FIX and test 
            if (timeMultiplier/60 <= 1 )
            {
                LblPoints.Content = (Points * 10).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Ordering", (Points * 10), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }
            else if (timeMultiplier/60 > 1 && timeMultiplier / 60 <= 4)

            {
                LblPoints.Content = (Points * 8).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Ordering", (Points * 8), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }
            else if (timeMultiplier / 60 >4 && timeMultiplier / 60 <= 7)
            {
                LblPoints.Content = (Points * 6).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Ordering", (Points * 6), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }
            else if (timeMultiplier / 60 >7 && timeMultiplier / 60 <= 10)
            {
                LblPoints.Content = (Points * 4).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Ordering", (Points * 4), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }
            else if (timeMultiplier / 60 >10 && timeMultiplier / 60 <= 13)
            {
                LblPoints.Content = (Points * 2).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Ordering", (Points * 2), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();
            }
            else
            {
                LblPoints.Content = (Points).ToString() + "/100";
                LeaderboardItem L = new LeaderboardItem(ValidationHandeler.GetLeaderBoardID(), "Ordering", (Points), CurrentUser.U.UserId);
                CONTEXT.LeaderboardItems.Add(L);
                CONTEXT.SaveChangesAsync();

            }



            DisplayCorrectList();
            if (CompareList() == true)
            {
                MessageBox.Show("Congratulations!!! \n you got all right", "Grimore Catcher");
            }
            else
            {
                MessageBox.Show("Unlucky try again \n You can get all correct eventually ", "Grimore Catcher");
            }
            BtnCode1.IsEnabled = false;
            BtnCode2.IsEnabled = false;
            BtnCode3.IsEnabled = false;
            BtnCode4.IsEnabled = false;
            BtnCode5.IsEnabled = false;
            BtnCode6.IsEnabled = false;
            BtnCode7.IsEnabled = false;
            BtnCode8.IsEnabled = false;
            BtnCode9.IsEnabled = false;
            BtnCode10.IsEnabled = false;
            BtnUp.IsEnabled = false;
            BtnDown.IsEnabled = false;
            BtnEnter.IsEnabled = false;
            GrpAnswer.Visibility = Visibility.Visible;

        }
        private double RandomNumber()
        {
            //Calling the random class the 3 digits before the point 
            double rand = rnd.Next(0, 1000);
            //Calling the random class the 2 digits after the point 
            double rand2 = rnd.Next(0, 100);
            //adding the number to form a complete double 
            double randomNumber = rand + (rand2 / 100);

            return randomNumber;
        }
        public static string RandomStrings()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, 3)
                .Select(s => s[rnd.Next(s.Length)]).ToArray());

            /*
             Code Atribution
            Author:dtb , Wai Ha Lee
            Date:Nov 13, 2021
            URL:https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
            */
        }
        public List<Dewey> SortArray(List<Dewey> list)
        {
            List<Dewey> SortedList = list.OrderBy(o => o.Letters).OrderBy(o => o.Number).ToList();//sorting the Lists 
            StringSorted.Clear();
            foreach (Dewey item in SortedList)
            {
                StringSorted.Add(item.Number.ToString("000.00") + " " + item.Letters);//getting the string sorted list to compare 
            }

            return SortedList;
        }
        public void DisplayCorrectList()
        {
            LstAnswer.Items.Clear();
            foreach (string item in StringSorted)
            {
                LstAnswer.Items.Add(item);
            }
        }
        public void PopulateArray()
        {
            deweys.Clear();
            for (int i = 0; i < 10; i++)
            {
                Dewey d = new Dewey(RandomNumber(), RandomStrings());
                deweys.Add(d);
                StringRandomList.Add(d.Number.ToString("000.00") + " " + d.Letters);

            }

        }
        public void PopulateButtons()
        {

            BtnCode1.Content = StringRandomList.ElementAt(0);
            BtnCode2.Content = StringRandomList.ElementAt(1);
            BtnCode3.Content = StringRandomList.ElementAt(2);
            BtnCode4.Content = StringRandomList.ElementAt(3);
            BtnCode5.Content = StringRandomList.ElementAt(4);
            BtnCode6.Content = StringRandomList.ElementAt(5);
            BtnCode7.Content = StringRandomList.ElementAt(6);
            BtnCode8.Content = StringRandomList.ElementAt(7);
            BtnCode9.Content = StringRandomList.ElementAt(8);
            BtnCode10.Content = StringRandomList.ElementAt(9);

        }
        public bool CompareList()
        {
            bool flag = false;
            Points = 0;

            if (BtnCode1.Background == Brushes.White && BtnCode2.Background == Brushes.White && BtnCode3.Background == Brushes.White && BtnCode4.Background == Brushes.White &&
                BtnCode5.Background == Brushes.White && BtnCode6.Background == Brushes.White && BtnCode7.Background == Brushes.White && BtnCode8.Background == Brushes.White &&
                BtnCode9.Background == Brushes.White && BtnCode10.Background == Brushes.White)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (LstDeweys.Items.GetItemAt(i).Equals(StringSorted.ElementAt(i)))
                    {
                        Points++;
                    }
                }
                if (Points == 10)
                {
                    flag = true;

                }
                else
                {
                    flag = false;
                }
            }
            else
            {
                MessageBox.Show("Please ensure you have sorted all available codes ","Grimoire Catcher");
            }

            return flag;
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

        private void BtnUp_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = LstDeweys.SelectedIndex;

            if (selectedIndex > 0)
            {
                //here i swop the item and the item above
                var itemToMoveUp = LstDeweys.Items[selectedIndex];
                StringObvRandomList.RemoveAt(selectedIndex);
                StringObvRandomList.Insert(selectedIndex - 1, (string)itemToMoveUp);
                LstDeweys.SelectedIndex = selectedIndex - 1;
            }


            /*
            Code Atribution
            Author: Peter Hansen
            Date:Nov 15, 2021
            URL:https://stackoverflow.com/questions/12540457/moving-an-item-up-and-down-in-a-wpf-list-box
            */
        }

        private void BtnDown_Click(object sender, RoutedEventArgs e)
        {
            var selectedIndex = LstDeweys.SelectedIndex;
            if (selectedIndex + 1 < StringObvRandomList.Count)
            {
                //here i swop the item and the item below
                var itemToMoveDown = LstDeweys.Items[selectedIndex];
                StringObvRandomList.RemoveAt(selectedIndex);
                StringObvRandomList.Insert(selectedIndex + 1, (string)itemToMoveDown);
                LstDeweys.SelectedIndex = selectedIndex + 1;
            }
        /*
        Code Atribution
        Author: Peter Hansen
        Date:Nov 15, 2021
        URL:https://stackoverflow.com/questions/12540457/moving-an-item-up-and-down-in-a-wpf-list-box
        */
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            //navigation to the hub window 
            HubWindow HW = new HubWindow();
            this.Hide();
            HW.Show();
        }
    }

}
