using Core.Useradministration;
using Core.Useradministration.entities;
using nopainnogain;
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

namespace GUI
{
    /// <summary>
    /// LOGIN checks the email address and password and executes the login
    /// </summary>
    public partial class LOGIN : Page
    {
        #region Variables
        public static string email = "";
        #endregion

        #region Initialization
        public LOGIN()
        { InitializeComponent(); }

        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void loginB_Click(object sender, RoutedEventArgs e)
        {
            email = emailInput.Text;
            string password = passwordInput.Password;

            IUserAdministration admin = new UserAdministrationImpl();
            if (admin.GetUser(email) == null)

            { MessageBox.Show("The email address does not exist. Check your input or register for CAL"); }
            else
            {
                bool pwChecked = admin.LoginUser(email, password);

                if (pwChecked == false)
                { MessageBox.Show("The password is wrong. Check your input!"); }
                else
                { mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute)); }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("Welcome.xaml", UriKind.RelativeOrAbsolute));
        }
        #endregion
    }
}
