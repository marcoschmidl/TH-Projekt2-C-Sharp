using Core.Persistence;
using Core.Persistence.impl;
using Core.Productadministration;
using Core.Productadministration.impl;
using Core.Useradministration;
using Core.Useradministration.entities;
using nopainnogain;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace GUI
{
    /// <summary>
    /// Interaktionslogik für TRACKER_ADD_PRODUCT.xaml
    /// </summary>
    public partial class TRACKER_ADD_PRODUCT : Page
    {
        #region Variables
        public static string email1 = SiGN_UP.email;
        public static string email2 = LOGIN.email;
        public static Product product = new Product();
        #endregion

        #region Initialization
        public TRACKER_ADD_PRODUCT()
        {
            InitializeComponent();
            IProductAdministration padmin = new ProductAdministrationImpl();
            Products.ItemsSource = padmin.GetAllProduct().ToList();
        }
        MainWindow mainWindow { get => Application.Current.MainWindow as MainWindow; }
        #endregion

        #region Methods
        private void back_Click(object sender, RoutedEventArgs e)
        { mainWindow.mainFrame.Navigate(new Uri("HOME.xaml", UriKind.RelativeOrAbsolute)); }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            if (product_added.IsChecked == true)
            {
                MessageBox.Show("The product is already included in the database.");
            }
            else
            {
                if((pNameInput.Text == "") || (kcalInput.Text == "") || (proteinInput.Text == "") || (carbsInput.Text == "") || (fatInput.Text == "") || (amountInput.Text == ""))
                {
                    MessageBox.Show("Please fill in all fields with valid values.");
                }
                else
                {
                    string name = pNameInput.Text;
                    int kcal = int.Parse(this.kcalInput.Text);
                    int protein = int.Parse(this.proteinInput.Text);
                    int carbs = int.Parse(this.carbsInput.Text);
                    int fat = int.Parse(this.fatInput.Text);
                    int amount = int.Parse(this.amountInput.Text);

                    IProductAdministration admin = new ProductAdministrationImpl();
                    product.Name = name;
                    product.Kcal = kcal;
                    product.Protein = protein;
                    product.Carbs = carbs;
                    product.Fat = fat;
                    product.Amount = amount;
                    admin.CreateProduct(product);
                    MessageBox.Show("The product was added successfully.");
                    product_added.IsChecked = true;
                }
                
            }
        }

        private void addtoConsumption_Click(object sender, RoutedEventArgs e)
        {
            if (product_added.IsChecked == true)
            {
                if (SiGN_UP.email != "")
                {
                    IUserAdministration admin = new UserAdministrationImpl();
                    User user = admin.GetUser(email1);
                    DateTimeOffset datetime = DateTimeOffset.Now;
                    int quantity = int.Parse(quantityInput.Text);
                    if (quantity == 0)
                    {
                        MessageBox.Show("Enter a valid value for the quantity consumed.");
                    }
                    else
                    {
                        Consumption cons = new Consumption(datetime, quantity, product, user);
                        IConsumptionPersistence cadmin = new ConsumptionPersistenceImpl();
                        cadmin.CreateConsumption(cons);
                        resetData();
                        product_added.IsChecked = false;
                    }
                }
                else
                {
                    IUserAdministration admin = new UserAdministrationImpl();
                    User user = admin.GetUser(email2);
                    DateTimeOffset datetime = DateTimeOffset.Now;
                    int quantity = int.Parse(quantityInput.Text);
                    if(quantity == 0)
                    {
                        MessageBox.Show("Enter a valid value for the quantity consumed.");
                    }
                    else
                    {
                        Consumption cons = new Consumption(datetime, quantity, product, user);
                        IConsumptionPersistence cadmin = new ConsumptionPersistenceImpl();
                        cadmin.CreateConsumption(cons);
                        resetData();
                        product_added.IsChecked = false;
                    }
                    
                }
            }
            else
            { MessageBox.Show("Add a product first."); }
        }
        private void showProduct_Click(object sender, RoutedEventArgs e)
        {
            if (Products.SelectedItem == null)
            {
                MessageBox.Show("No product selected.");
            }
            else
            {
                product = (Product)Products.SelectedItem;
                string nameP = ((Product)Products.SelectedItem).Name;
                int kcalP = ((Product)Products.SelectedItem).Kcal;
                int proteinP = ((Product)Products.SelectedItem).Protein;
                int carbsP = ((Product)Products.SelectedItem).Carbs;
                int fatP = ((Product)Products.SelectedItem).Fat;
                int amountP = ((Product)Products.SelectedItem).Amount;

                pNameInput.Text = nameP;
                kcalInput.Text = kcalP.ToString();
                proteinInput.Text = proteinP.ToString();
                carbsInput.Text = carbsP.ToString();
                fatInput.Text = fatP.ToString();
                amountInput.Text = amountP.ToString();

                product_added.IsChecked = true;
            }
        }
        private void product_added_Checked(object sender, RoutedEventArgs e)
        {
        }
        private void resetData()
        {
            pNameInput.Text = "Product name";
            kcalInput.Text = "kcal per 100g";
            proteinInput.Text = "Proteins per 100g";
            carbsInput.Text = "Carbs per 100g";
            fatInput.Text = "Fat per 100g";
            amountInput.Text = "Reference value kcal";
            quantityInput.Text = "Quantity consumed";
        }
        #endregion
    }
}
