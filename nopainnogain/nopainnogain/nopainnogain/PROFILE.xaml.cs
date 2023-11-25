using Core.Useradministration;
using Core.Useradministration.entities;
using nopainnogain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// PROFILE shows the user the most relevant data of his profile.
    /// </summary>
    public partial class PROFILE : Page
    {
        #region Variables
        string email = SiGN_UP.email;
        string email2 = LOGIN.email;
        #endregion

        #region Initialization
        public PROFILE()
        {
            InitializeComponent();
            if (email != "")
            {
                IUserAdministration admin = new UserAdministrationImpl();
                User user = admin.GetUser(email);
                nameProfile.Text = user.Name.ToString();
                emailProfile.Text = user.Email.ToString();
                bodysizeProfile.Text = user.BodySize.ToString();
                goalweightProfile.Text = user.WeightGoal.ToString();
                activityProfile.Text = user.testaktiv.ToString();
                goalProfile.Text = user.Goal.ToString();
            }
            else
            {
                IUserAdministration admin2 = new UserAdministrationImpl();
                User user2 = admin2.GetUser(email2);
                nameProfile.Text = user2.Name.ToString();
                emailProfile.Text = user2.Email.ToString();
                bodysizeProfile.Text = user2.BodySize.ToString();
                goalweightProfile.Text = user2.WeightGoal.ToString();
                activityProfile.Text = user2.testaktiv.ToString();
                goalProfile.Text = user2.Goal.ToString();
            }
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("HOME.XAML", UriKind.RelativeOrAbsolute));
        }
        #endregion
    }
}
