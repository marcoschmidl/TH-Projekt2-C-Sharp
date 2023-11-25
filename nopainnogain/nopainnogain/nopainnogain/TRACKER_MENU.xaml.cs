using Core.Useradministration.entities;
using nopainnogain;
using System;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// TRACKER_MENU shows the user the consumed products of today.
    /// </summary>
    public partial class TRACKER_MENU : Page
    {
        #region Initialization
        public TRACKER_MENU()
        {
            InitializeComponent();
            Consumption cadmin = new Consumption();
            productGrid.ItemsSource = cadmin.otherConsumptionList(LOGIN.email);
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void back_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute)); }

        private void add_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("TRACKER_ADD_PRODUCT.xaml", UriKind.RelativeOrAbsolute)); }
        #endregion
    }
}
