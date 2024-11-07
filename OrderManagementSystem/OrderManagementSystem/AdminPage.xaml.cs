using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

namespace OrderManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        cashierEntities DB = new cashierEntities();
        public AdminPage()
        {
            InitializeComponent();
            show();
        }

        public void show()
        {
            ProductsGrid.ItemsSource = DB.Products.ToList();

        }

        private void add_btn(object sender, RoutedEventArgs e)
        {
            Product product = new Product();

            product.ProductName = txt1.Text;
            product.Price = int.Parse(txt2.Text);

            DB.Products.Add(product);
            DB.SaveChanges();
            show();

        }

        private void delete_btn(object sender, RoutedEventArgs e)
        {
            try
            {


                Product product = new Product();
                var seleted = ProductsGrid.SelectedItem as Product;

                product = DB.Products.Remove(seleted);

                DB.SaveChanges();
                show();


            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);


            }

        }

        private void selected1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
