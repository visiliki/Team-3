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
            OrderList.ItemsSource = Hi();

        }

        private void AddOrderButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                Product product = new Product();
                Order order = new Order();
                int x = int.Parse(txt3.Text);
                Products1 p2 = new Products1();

                p2 = Hi().FirstOrDefault(o => o.ProductId == x);

                MessageBox.Show(p2.Quantity.ToString());

                p2.Quantity = p2.Quantity + 1;

                show2();



                Hi().Add(p2);

                DB.SaveChanges();
                show2();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);


            }



        }


        public List<Products1> Hi()
        {

            Product p1 = new Product();
            Order order = new Order();
            List<Products1> ss = new List<Products1>();

            string size = DB.Products.ToList().Capacity.ToString();
            int size1 = int.Parse(size);



            for (int i = 1; i <= size1; i++)
            {

                p1 = DB.Products.FirstOrDefault(a => a.ProductId == i);

                if (p1 != null)
                {

                    order = DB.Orders.FirstOrDefault(d => d.ProductId == p1.ProductId);

                    if (order != null)
                    {


                        ss.Add(new Products1
                        {
                            OrderId = order.OrderId,
                            ProductId = p1.ProductId,
                            Quantity = order.Quantity,
                            Product = p1.ProductName

                        });


                    }

                }

            }

            return ss;

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



    public class Products1
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Product { get; set; }



    }
}
