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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PROG7312_POE_ST10117020.ModelServer;
using PROG7312_POE_ST10117020.Utility;

namespace PROG7312_POE_ST10117020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly PROG_ST10117020Context CONTEXT = new PROG_ST10117020Context();


        public MainWindow()
        {
            InitializeComponent();
            ClearComponents();
            GrpReg.Visibility = Visibility.Hidden;
        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userEmail, userPassword;

            userEmail = TxbName.Text;
            userPassword = TxbPassword.Password;

            if (LoginMethods.CanLogIn(userEmail, userPassword) == true)//checks if the User can log in 
            {
                HubWindow HW = new HubWindow();
                this.Hide();
                HW.Show();//navigates to the Game Hub page to select the game they would like to play
            }
            else
            {
                MessageBox.Show("Please enter valid Details to continue \n\n or register ;)");
            }


        }

        private void BtnLoginReg_Click(object sender, RoutedEventArgs e)
        {
            GrpLogin.Visibility = Visibility.Hidden;
            GrpReg.Visibility = Visibility.Visible;
        }

        private void BtnRegLogin_Click(object sender, RoutedEventArgs e)
        {
            GrpReg.Visibility = Visibility.Hidden;
            GrpLogin.Visibility = Visibility.Visible;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {

            string UserName, UserEmail, UserPassword;

            UserName = TxbRegName.Text;
            UserEmail = TxbRegEmail.Text;
            UserPassword = TxbRegPassword.Text;



            //checking and getting error message if aplicable 
            string ValidationStr = ValidationHandeler.CheckUser(UserName, UserEmail, UserPassword);
            List<User> u = CONTEXT.Users.ToList();
            try
            {
                if (ValidationStr.Length == 0)
                {
                    string temp = LoginMethods.PassWordHash(UserPassword);
                    //creating an instance of student 
                    User U = new User(ValidationHandeler.GetID(), UserName, UserEmail, temp);


                    CONTEXT.Users.Add(U);
                    CONTEXT.SaveChanges();
                    CurrentUser.U = U;
                    HubWindow HW = new HubWindow();
                    this.Hide();
                    HW.Show();//navigates to the Game Hub page to select the game they would like to play

                }
                else
                {
                    MessageBox.Show("User already exists ");
                }

            }
            catch (Exception)
            {
                MessageBox.Show( "User already exists ");

                throw;
            }
        }

        public void ClearComponents()
        {
            TxbName.Text = "";
            TxbPassword.Password = "";
            TxbRegEmail.Text = "";
            TxbRegName.Text = "";
            TxbRegPassword.Text = "";

        }
    }
}
