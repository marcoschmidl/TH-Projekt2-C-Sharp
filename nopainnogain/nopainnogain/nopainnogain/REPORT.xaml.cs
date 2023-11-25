using Core.Calculations;
using Core.Useradministration;
using Core.Useradministration.entities;
using nopainnogain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// REPORT shows the user the calorie consumption and the progress of his weight in the last seven days.
    /// </summary>
    public partial class REPORT : Page
    {
        #region Initialization
        public REPORT()
        {
            InitializeComponent();
            if(SiGN_UP.email != "")
            {
                ICalculations cadmin = new Calculations();
                IUserAdministration admin = new UserAdministrationImpl();
                User user = admin.GetUser(SiGN_UP.email);
                reportData.ItemsSource = cadmin.GetReport(user, SiGN_UP.email);
            }
            else
            {
                ICalculations cadmin = new Calculations();
                IUserAdministration admin = new UserAdministrationImpl();
                User user = admin.GetUser(LOGIN.email);
                reportData.ItemsSource = cadmin.GetReport(user, LOGIN.email);
            }
             
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void back_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute)); }
        #endregion
    }
}
