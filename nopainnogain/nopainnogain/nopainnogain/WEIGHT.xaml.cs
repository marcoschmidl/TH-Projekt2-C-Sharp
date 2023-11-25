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
    /// WEIGHT lets the user enter a new weight and updates it in the user relation.
    /// </summary>
    public partial class WEIGHT : Page
    {
        #region Initialization
        public WEIGHT()
        { InitializeComponent(); }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void back_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute)); }

        private void progress_Click(object sender, RoutedEventArgs e)
        {
            string email1 = SiGN_UP.email;
            string email2 = LOGIN.email;

            if (email1 != "")
            {
                DateTimeOffset dateTime = DateTimeOffset.Now;
                if (weightInput.Text == "")
                {
                    MessageBox.Show("Please insert a valid value.");
                }
                else
                {
                    int weight = int.Parse(this.weightInput.Text);
                    IUserAdministration admin = new UserAdministrationImpl();
                    User userWeight = admin.GetUser(email1);
                    IWeightsPersistence adminWeight = new WeightsPersistenceImpl();
                    adminWeight.CreateWeight(new Weight(weight, dateTime, userWeight));
                    double activity = userWeight.testaktiv;
                    admin.UpdateUser(email1, new User(SiGN_UP.email, SiGN_UP.password, SiGN_UP.name, SiGN_UP.lastname, EDIT_PROFILE.age, EDIT_PROFILE.sex, EDIT_PROFILE.bodysize, SET_GOAL.weightgoal, activity, SET_GOAL.goal, weight));
                    mainWindow.mainFrame.Navigate(new Uri("REPORT.xaml", UriKind.RelativeOrAbsolute));
                }

            }
            else
            {
                DateTimeOffset dateTime = DateTimeOffset.Now;
                if (weightInput.Text == "")
                {
                    MessageBox.Show("Please insert a valid value.");
                }
                else
                {
                    int weight = int.Parse(this.weightInput.Text);
                    IUserPersistence admin = new UserPersistenceImpl();
                    User userWeight = admin.GetUser(email2);
                    IWeightsPersistence adminWeight = new WeightsPersistenceImpl();
                    adminWeight.CreateWeight(new Weight(weight, dateTime, userWeight));
                    double activity = userWeight.testaktiv;
                    admin.UpdateUser(email2, new User(userWeight.Email, userWeight.Password, userWeight.Name, userWeight.LastName, userWeight.Age, userWeight.Sex, userWeight.BodySize, userWeight.WeightGoal, activity, userWeight.Goal, weight));
                    mainWindow.mainFrame.Navigate(new Uri("REPORT.xaml", UriKind.RelativeOrAbsolute));
                }
            }
        }
        private void confirmweight_Click(object sender, RoutedEventArgs e)
        {
            string email1 = SiGN_UP.email;
            string email2 = LOGIN.email;

            if (email1 != "")
            {
                DateTimeOffset dateTime = DateTimeOffset.Now;
                if (weightInput.Text == "")
                {
                    MessageBox.Show("Please insert a valid value.");
                }
                else
                {
                    int weight = int.Parse(this.weightInput.Text);
                    IUserAdministration admin = new UserAdministrationImpl();
                    User userWeight = admin.GetUser(email1);
                    IWeightsPersistence adminWeight = new WeightsPersistenceImpl();
                    adminWeight.CreateWeight(new Weight(weight, dateTime, userWeight));
                    double activity = userWeight.testaktiv;
                    admin.UpdateUser(email1, new User(SiGN_UP.email, SiGN_UP.password, SiGN_UP.name, SiGN_UP.lastname, EDIT_PROFILE.age, EDIT_PROFILE.sex, EDIT_PROFILE.bodysize, SET_GOAL.weightgoal, activity, SET_GOAL.goal, weight));
                    mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute));
                }

            }
            else
            {
                DateTimeOffset dateTime = DateTimeOffset.Now;
                if (weightInput.Text == "")
                {
                    MessageBox.Show("Please insert a valid value.");
                }
                else
                {
                    int weight = int.Parse(this.weightInput.Text);
                    IUserPersistence admin = new UserPersistenceImpl();
                    User userWeight = admin.GetUser(email2);
                    IWeightsPersistence adminWeight = new WeightsPersistenceImpl();
                    adminWeight.CreateWeight(new Weight(weight, dateTime, userWeight));
                    double activity = userWeight.testaktiv;
                    admin.UpdateUser(email2, new User(userWeight.Email, userWeight.Password, userWeight.Name, userWeight.LastName, userWeight.Age, userWeight.Sex, userWeight.BodySize, userWeight.WeightGoal, activity, userWeight.Goal, weight));
                    mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute));
                }
            }

        }
        #endregion

    }
}
