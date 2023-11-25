using Core.Useradministration;
using Core.Useradministration.entities;
using GUI;
using System;
using System.Windows;
using System.Windows.Controls;



namespace nopainnogain
{
    /// <summary>
    /// SET_GOAL_LOGIN offers the possibility to edit the profile data. The saved data is recalled and can be reused.
    /// After the data has been entered completely, the user is updated.
    /// </summary>
    public partial class SET_GOAL_LOGIN : Page
    {
        #region Variables
        public static string goal = "";
        public static int weightgoal = 0;
        public static Sex sex;
        string email = SiGN_UP.email;
        string email2 = LOGIN.email;
        #endregion

        #region Initialization
        public SET_GOAL_LOGIN()
        {
            InitializeComponent();
            if (email != "")
            {
                IUserAdministration admin = new UserAdministrationImpl();
                User user = admin.GetUser(email);
                checkGoal(user);
                weightInput.Text = user.WeightGoal.ToString();
            }
            else
            {
                IUserAdministration admin = new UserAdministrationImpl();
                User user = admin.GetUser(email2);
                checkGoal(user);
                weightInput.Text = user.WeightGoal.ToString();
            }
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void checkGoal(User user)
        {
            if (user.Goal == "lose")
            { lose.IsChecked = true; }
            else if (user.Goal == "gain")
            { gain.IsChecked = true; }
            else
            { maintain.IsChecked = true; }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("EDIT_PROFILE_LOGIN.xaml", UriKind.RelativeOrAbsolute));
        }
        private void next_Click(object sender, RoutedEventArgs e)
        {

            if (email != "")
            {
                weightgoal = int.Parse(this.weightInput.Text);
                int age = EDIT_PROFILE_LOGIN.age;
                int bodysize = EDIT_PROFILE_LOGIN.bodysize;
                double activity = EDIT_PROFILE_LOGIN.activityOverload;
                int weight = EDIT_PROFILE_LOGIN.weight;
                sex = EDIT_PROFILE_LOGIN.sex;
                IUserAdministration admin = new UserAdministrationImpl();
                User userUpdate = admin.GetUser(email);
                if ((weightgoal >= 40 && weightgoal <= 200) || ((lose.IsChecked == true) || (gain.IsChecked == true) || (maintain.IsChecked == true)))
                {
                    admin.UpdateUser(email, new User(email, SiGN_UP.password, SiGN_UP.name, SiGN_UP.lastname, age, sex, bodysize, weightgoal, activity, goal, weight));
                    mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute));
                }
                else { MessageBox.Show("Please enter correct data and make sure that a goal has been selected."); }

            }
            else
            {
                weightgoal = int.Parse(this.weightInput.Text);
                int age = EDIT_PROFILE_LOGIN.age;
                int bodysize = EDIT_PROFILE_LOGIN.bodysize;
                double activity = EDIT_PROFILE_LOGIN.activityOverload;
                int weight = EDIT_PROFILE_LOGIN.weight;
                sex = EDIT_PROFILE_LOGIN.sex;
                IUserAdministration admin = new UserAdministrationImpl();
                User userUpdate = admin.GetUser(email2);
                if ((weightgoal >= 40 && weightgoal <= 200) || ((lose.IsChecked == true) || (gain.IsChecked == true) || (maintain.IsChecked == true)))
                {
                    admin.UpdateUser(email2, new User(email2, userUpdate.Password, userUpdate.Name, userUpdate.LastName, age, sex, bodysize, weightgoal, activity, goal, weight));
                    mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute));
                }
                else { MessageBox.Show("Please enter correct data and make sure that a goal has been selected."); }
            }
        }

        private void lose_Checked(object sender, RoutedEventArgs e)
        {
            if (lose.IsChecked == true)
            {
                gain.IsChecked = false;
                maintain.IsChecked = false;
                goal = "lose";
            }
        }

        private void gain_Checked(object sender, RoutedEventArgs e)
        {
            if (gain.IsChecked == true)
            {
                lose.IsChecked = false;
                maintain.IsChecked = false;
                goal = "gain";
            }
        }

        private void maintain_Checked(object sender, RoutedEventArgs e)
        {
            if (maintain.IsChecked == true)
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

