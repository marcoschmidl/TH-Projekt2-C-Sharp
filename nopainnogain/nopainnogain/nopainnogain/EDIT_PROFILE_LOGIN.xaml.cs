using Core.Useradministration;
using Core.Useradministration.entities;
using GUI;
using System;
using System.Windows;
using System.Windows.Controls;

namespace nopainnogain
{
    /// <summary>
    /// EDIT_PROFILE_LOGIN offers the possibility to edit the profile data. The saved data is recalled and can be reused.
    /// </summary>
    public partial class EDIT_PROFILE_LOGIN : Page
    {
        #region Variables
        public static int age;
        public static int bodysize;
        public static double activity = 1;
        public static double activityOverload;
        public static int weight;
        public static Sex sex;
        #endregion

        #region Initialization
        public EDIT_PROFILE_LOGIN()
        {
            InitializeComponent();
            string email = SiGN_UP.email;
            string email2 = LOGIN.email;

            if (email != "")
            {
                IUserAdministration admin = new UserAdministrationImpl();
                User user = admin.GetUser(email);
                ageInput.Text = user.Age.ToString();
                bodysizeInput.Text = user.BodySize.ToString();
                weightInput.Text = user.WeightToTrack.ToString();
                checkActivity(user);
                checkSex(user);
            }
            else
            {
                IUserAdministration admin2 = new UserAdministrationImpl();
                User user2 = admin2.GetUser(email2);
                ageInput.Text = user2.Age.ToString();
                bodysizeInput.Text = user2.BodySize.ToString();
                weightInput.Text = user2.WeightToTrack.ToString();
                checkActivity(user2);
                checkSex(user2);
            }
        }

        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void next_Click(object sender, RoutedEventArgs e)
        {
            if ((ageInput.Text == "") || (bodysizeInput.Text == "") || (weightInput.Text == ""))
            {
                MessageBox.Show("Please fill all fields with correct data.");
            }
            else
            {
                age = int.Parse(this.ageInput.Text);
                bodysize = int.Parse(this.bodysizeInput.Text);
                weight = int.Parse(this.weightInput.Text);
                activityOverload = activity;

                if (cbman.IsChecked == false && cbwoman.IsChecked == false)
                {
                    MessageBox.Show("Please select a gender.");
                }
                else
                {
                    mainWindow.mainFrame.Navigate(new Uri("SET_GOAL_LOGIN.xaml", UriKind.RelativeOrAbsolute));
                }
                    
            }
        }

        private void checkSex(User user)
        {
            Sex sex = user.Sex;
            if(sex == Sex.Female)
            { cbwoman.IsChecked = true; }
            else
            { cbman.IsChecked = true; }
        }

        private void checkActivity(User user)
        {
            if (user.testaktiv == 1.2)
            { cbActivity1.IsChecked = true; }
            else if (user.testaktiv == 1.4)
            { cbActivity2.IsChecked = true; }
            else if (user.testaktiv == 1.7)
            { cbActivity3.IsChecked = true; }
            else if (user.testaktiv == 1.7)
            { cbActivity4.IsChecked = true; }
            else
            { cbActivity5.IsChecked = true; }
        }

        private void cbActivity1_Checked(object sender, RoutedEventArgs e)
        {
            if (cbActivity1.IsChecked == true)
            {
                cbActivity2.IsChecked = false;
                cbActivity3.IsChecked = false;
                cbActivity4.IsChecked = false;
                cbActivity5.IsChecked = false;
                activity = 1.2;
            }
        }
        private void cbActivity2_Checked(object sender, RoutedEventArgs e)
        {
            if (cbActivity2.IsChecked == true)
            {
                cbActivity1.IsChecked = false;
                cbActivity3.IsChecked = false;
                cbActivity4.IsChecked = false;
                cbActivity5.IsChecked = false;
                activity = 1.4;
            }
        }
        private void cbActivity3_Checked(object sender, RoutedEventArgs e)
        {
            if (cbActivity3.IsChecked == true)
            {
                cbActivity1.IsChecked = false;
                cbActivity2.IsChecked = false;
                cbActivity4.IsChecked = false;
                cbActivity5.IsChecked = false;
                activity = 1.7;
            }
        }
        private void cbActivity4_Checked(object sender, RoutedEventArgs e)
        {
            if (cbActivity4.IsChecked == true)
            {
                cbActivity1.IsChecked = false;
                cbActivity2.IsChecked = false;
                cbActivity3.IsChecked = false;
                cbActivity5.IsChecked = false;
                activity = 1.9;
            }
        }
        private void cbActivity5_Checked(object sender, RoutedEventArgs e)
        {
            if (cbActivity5.IsChecked == true)
            {
                cbActivity1.IsChecked = false;
                cbActivity2.IsChecked = false;
                cbActivity3.IsChecked = false;
                cbActivity4.IsChecked = false;
                activity = 2.2;
            }
        }
        private void activity1_Click(object sender, RoutedEventArgs e)
        { cbActivity1.IsChecked = true; }

        private void activity2_Click(object sender, RoutedEventArgs e)
        { cbActivity2.IsChecked = true; }

        private void activity3_Click(object sender, RoutedEventArgs e)
        { cbActivity3.IsChecked = true; }

        private void activity4_Click(object sender, RoutedEventArgs e)
        { cbActivity4.IsChecked = true; }

        private void activity5_Click(object sender, RoutedEventArgs e)
        { cbActivity5.IsChecked = true; }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(" '1' = People with exclusively sedentary or lying lifestyle." + Environment.NewLine +
                            " '2' = People with primarily sedentary jobs and sparse recreational athletic activities." + Environment.NewLine +
                            " '3' = People with sedentary jobs but also with standing and walking activities." + Environment.NewLine +
                            " '4' = People with high standing and walking activities." + Environment.NewLine +
                            " '5' = People with physically demanding jobs.");
        }
        private void man_Click(object sender, RoutedEventArgs e)
        { cbman.IsChecked = true; }
        private void cbman_Checked(object sender, RoutedEventArgs e)
        {
            if (cbman.IsChecked == true)
            {
                cbwoman.IsChecked = false;
                sex = Sex.Male;
            }
        }
        private void woman_Click(object sender, RoutedEventArgs e)
        { cbwoman.IsChecked = true; }
        private void cbwoman_Checked(object sender, RoutedEventArgs e)
        {
            if (cbwoman.IsChecked == true)
            {
                cbman.IsChecked = false;
                sex = Sex.Female;
            }
        }
        #endregion
    }
}
