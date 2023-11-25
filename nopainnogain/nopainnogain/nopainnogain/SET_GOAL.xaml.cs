using Core.Useradministration;
using Core.Useradministration.entities;
using nopainnogain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// SET_GOAL takes a goal and weightgoal and creates a new user.
    /// </summary>
    public partial class SET_GOAL : Page
    {
        #region Variables
        public static string goal = "";
        public static int weightgoal = 0;
        #endregion

        #region Initialization
        public SET_GOAL()
        { InitializeComponent(); }
        #endregion

        #region Methods
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        private void back_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("EDIT_PROFILE.xaml", UriKind.RelativeOrAbsolute)); }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            Sex sex = EDIT_PROFILE.sex;
            string name = SiGN_UP.name;
            string lastname = SiGN_UP.lastname;
            string email = SiGN_UP.email;
            string password = SiGN_UP.password;
            int age = EDIT_PROFILE.age;
            int bodysize = EDIT_PROFILE.bodysize;
            double activity = EDIT_PROFILE.activity;
            int weight = EDIT_PROFILE.weight;
            DateTimeOffset dateTime = DateTimeOffset.Now;

            weightgoal = int.Parse(this.weightGoalInput.Text);

            IUserAdministration admin = new UserAdministrationImpl();
            if ((weightgoal >= 40 && weightgoal <=200) || ((lose.IsChecked == true) || (gain.IsChecked == true) || (maintain.IsChecked == true)))
            {
                admin.CreateUser(new User(email, password, name, lastname, age, sex, bodysize, weightgoal, activity, goal,weight));

                User userWeight = admin.GetUser(email);
                IUserAdministration userAdmin = new UserAdministrationImpl();
                userAdmin.AddWeight(email, new Weight(weight, dateTime));
                mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute));
            }
            else
            { MessageBox.Show("Please enter correct data and make sure that a goal has been selected."); }
        }

        private void lose_Checked(object sender, RoutedEventArgs e)
        {
            if(lose.IsChecked == true)
            {
                gain.IsChecked = false;
                maintain.IsChecked = false;
                goal = "lose";
            }
        }

        private void gain_Checked(object sender, RoutedEventArgs e)
        {
            if(gain.IsChecked == true)
            {
                lose.IsChecked = false;
                maintain.IsChecked = false;
                goal = "gain";
            }
        }

        private void maintain_Checked(object sender, RoutedEventArgs e)
        {
            if(maintain.IsChecked == true)
            {
                lose.IsChecked = false;
                gain.IsChecked = false;
                goal = "maintain";
            }   
        }

        private void glose_Click(object sender, RoutedEventArgs e)
        { lose.IsChecked = true; }

        private void ggain_Click(object sender, RoutedEventArgs e)
        { gain.IsChecked = true; }

        private void gmaintain_Click(object sender, RoutedEventArgs e)
        { maintain.IsChecked = true; }
        #endregion
    }
}
