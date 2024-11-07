using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {

        cashierEntities DB = new cashierEntities();

        public UserPage()
        {
            InitializeComponent();
            show();
            show2();
        }

        public void show()
        {
            ProductList.ItemsSource = DB.Products.ToList();

        }

        public void show2()
        {
            OrderList.ItemsSource = DB.Orders.ToList();

        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Product product = new Product();
                Order order = new Order();
                int x = int.Parse(txt3.Text);
                
                product = DB.Products.FirstOrDefault(o => o.ProductId == x);

                if (x == order.ProductId)
                {
                    order.Quantity = order.Quantity +  1;
                    DB.SaveChanges();
                    show2();

                }
                else
                {

                    order.ProductId = product.ProductId;
                    order.Quantity = order.Quantity + 1;


                    DB.Orders.Add(order);

                    DB.SaveChanges();
                    show2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }
            


        }

        private void DeleteOrderBut_Click(object sender, RoutedEventArgs e)
        {

            Order order = new Order();
            var seleted = OrderList.SelectedItem as Order;

            order = DB.Orders.Remove(seleted);

            DB.SaveChanges();
            show2();
        }
    }
}
