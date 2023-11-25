using Core.Persistence;
using Core.Persistence.impl;
using Core.Useradministration;
using Core.Useradministration.entities;
using nopainnogain;
using System;
using System.Windows;
using System.Windows.Controls;


namespace GUI
{
    /// <summary>
    /// HOME is the main navigation of the application. 
    /// The user has access to the tracker, the report of the last seven days. 
    /// The user can edit and view his profile and update his weight.
    /// </summary>
    public partial class HOME : Page
    {
        #region Variables
        string email = SiGN_UP.email;
        string email2 = LOGIN.email;
        #endregion

        #region Initialization
        public HOME()
        {
            InitializeComponent();
            if (email != "")
            {
                IUserAdministration uadmin = new UserAdministrationImpl();
                User user = uadmin.GetUser(email);
                Consumption cadmin = new Consumption();
                int calText = cadmin.AuswertungConsumptonList(user, email);
                kcal.Text = calText.ToString();
                string feed = checkGoalAchievement(user, calText);
                feedBlock.Text = feed.ToString();

            } else
            {
                IUserPersistence uadmin2 = new UserPersistenceImpl();
                User user2 = new User();
                user2 = uadmin2.GetUser(email2);
                Consumption cadmin2 = new Consumption();
                int calText2 = cadmin2.AuswertungConsumptonList(user2, email2);
                kcal.Text = calText2.ToString();
                string feed = checkGoalAchievement(user2, calText2);
                feedBlock.Text = feed.ToString();
            }
           
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void edit_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("EDIT_PROFILE_LOGIN.xaml", UriKind.RelativeOrAbsolute)); }

        private void tracking_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("TRACKER_MENU.xaml", UriKind.RelativeOrAbsolute)); }

        private void report_Click(object sender, RoutedEventArgs e)
        {  mainWindow.mainFrame.Navigate(new Uri("REPORT.xaml", UriKind.RelativeOrAbsolute)); }

        private void weight_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("WEIGHT.xaml", UriKind.RelativeOrAbsolute)); }

        private void open_profile_Click(object sender, RoutedEventArgs e)
        {  mainWindow.mainFrame.Navigate(new Uri("PROFILE.xaml", UriKind.RelativeOrAbsolute)); }

        private string checkGoalAchievement(User user, int calText)
        {
            string feed = "";
            if (user.Goal == "maintain")
            {
                if (calText > 0)
                {
                    feed = "You are in a calorie deficit." + "\n" +
                            "You will not reach your calorie goal.";
                }
                else if (calText < 0)
                {
                    feed = "You have a calorie surplus." + "\n" +
                            "You did not reach your goal for the day.";
                }
                else
                {
                    feed = "You have reached your goal for the day.";
                }

            }
            else if (user.Goal == "lose")
            {
                if (calText > 0)
                {
                    feed = "You are in a calorie deficit." + "\n" +
                            "You will reach your calorie goal.";
                }
                else if (calText < 0)
                {
                    feed = "You have a calorie surplus." + "\n" +
                            "You did not reach your goal for the day.";
                }
                else
                {
                    feed = "You have reached your goal for the day.";
                }

            }
            else 
            {
                if (calText > 0)
                {
                    feed = "You have a calorie deficit." + "\n" +
                            "You will not reach your calorie goal.";
                }
                else if (calText < 0)
                {
                    feed = "You have a calorie surplus." + "\n" +
                           "At this point, you have already reached your goal." + "\n" +
                           "You will gain more weight than desired.";
                }
                else
                {
                    feed = "You have reached your goal for the day.";
                }
            }

            return feed;
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        #endregion


    }
}

