using Core.Useradministration;
using Core.Useradministration.entities;
using nopainnogain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// SiGN_UP takes the name, lastname, email and user password and saves the values for further use.
    /// </summary>
    public partial class SiGN_UP : Page
    {
        #region Variables
        public static string name;
        public static string lastname;
        public static string email = "";
        public static string password;
        #endregion

        #region Initialization 
        public SiGN_UP()
        { InitializeComponent(); }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void back_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("Welcome.xaml", UriKind.RelativeOrAbsolute)); }

        public void next_Click(object sender, RoutedEventArgs e)
        {
            if(nameInput.Text.Length < 3 || nameInput.Text.Length > 30)
            { MessageBox.Show("Please enter correct data for your first name." + Environment.NewLine + 
                                "It can contain between 3 and 30 letters."); }
            else
            {
                name = nameInput.Text;
                if (lastNameInput.Text.Length < 3 || lastNameInput.Text.Length > 30)
                { MessageBox.Show("Please enter correct data for your last name." + Environment.NewLine +
                                    "It can contain between 3 and 30 letters."); }
                else
                {
                    lastname = lastNameInput.Text;
                    IUserAdministration admin = new UserAdministrationImpl();
                    if (admin.GetUser(emailInput.Text) != null)
                    {
                        MessageBox.Show("There is already an account with this email address." + Environment.NewLine +
                                        "Please log in via Login with your password.");
                    }
                    else
                    {
                        if (emailInput.Text.Length > 9 && emailInput.Text.Length < 30 && emailInput.Text.Contains("@"))
                        {
                            email = emailInput.Text;
                            password = passwordInput.Password;
                            mainWindow.mainFrame.Navigate(new Uri("EDIT_PROFILE.xaml", UriKind.RelativeOrAbsolute));
                        }
                        else
                        { MessageBox.Show("Please enter correct data for your email address."); }
                    }
                }
            }           
        }
        #endregion
    }
}
