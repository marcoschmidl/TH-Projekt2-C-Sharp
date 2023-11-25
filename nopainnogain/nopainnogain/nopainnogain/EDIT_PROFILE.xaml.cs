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
    /// EDIT_PROFILE takes age, height, weight, gender and physical activity and stores the values for later use.
    /// </summary>
    public partial class EDIT_PROFILE : Page
    {
        #region Variables
        public static int age = 0;
        public static int bodysize = 0;
        public static int weight = 0;
        public static double activity = 1;
        public static Sex sex;
        #endregion

        #region Initialization
        public EDIT_PROFILE()
        { InitializeComponent(); }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void back_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.mainFrame.Navigate(new Uri("SiGN_UP.xaml", UriKind.RelativeOrAbsolute));
            ageInput.Text = ageInput.Text;
            bodysizeInput.Text = bodysizeInput.Text;
            weightInput.Text = weightInput.Text;
        }
        public void next_Click(object sender, RoutedEventArgs e)
        {
            if((ageInput.Text == "")||(bodysizeInput.Text == "")|| (weightInput.Text == ""))
            {
                MessageBox.Show("Please fill all fields with correct data.");
            }
            else
            {
                age = int.Parse(this.ageInput.Text);
                bodysize = int.Parse(this.bodysizeInput.Text);
                weight = int.Parse(this.weightInput.Text);
            }
            
            if ((age <= 15 || age >= 90) || (bodysize <= 140 || bodysize >= 220) || (weight <= 40 || weight >=200) || (activity == 0))
            { MessageBox.Show("Please fill in the fields with correct data."); }
            else
            {
                if (cbman.IsChecked == false && cbwoman.IsChecked == false)
                {
                    MessageBox.Show("Please select a gender.");
                }
                else
                { mainWindow.mainFrame.Navigate(new Uri("SET_GOAL.xaml", UriKind.RelativeOrAbsolute)); }
            }
            
        }

        private void cbActivity1_Checked(object sender, RoutedEventArgs e)
        {
            if(cbActivity1.IsChecked == true)
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
            if(cbActivity2.IsChecked == true)
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
            if(cbman.IsChecked == true)
            {
                cbwoman.IsChecked = false;
                sex = Sex.Male;
            }
        }

        private void woman_Click(object sender, RoutedEventArgs e)
        { cbwoman.IsChecked = true; }

        private void cbwoman_Checked(object sender, RoutedEventArgs e)
        {
            if(cbwoman.IsChecked == true)
            {
                cbman.IsChecked = false;
                sex = Sex.Female;
            }
        }
        #endregion
    }
}
