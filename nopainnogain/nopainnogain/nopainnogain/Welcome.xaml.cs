using nopainnogain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// Welcome lets the user choose between SIGN_UP and LOGIN
    /// </summary>
    public partial class Welcome : Page
    {
        #region Initialization
        public Welcome()
        { InitializeComponent(); }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void SignUp_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("SiGN_UP.xaml", UriKind.RelativeOrAbsolute)); }

        private void Login_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("LOGIN.xaml", UriKind.RelativeOrAbsolute)); }
        #endregion
    }
}
