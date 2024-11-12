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
using System.Data.Entity.Migrations;


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
                int productId = int.Parse(txt3.Text);

                Product p1 = new Product();
                Order o1 = new Order();

                p1 = DB.Products.FirstOrDefault(p => p.ProductId == productId);

                if (p1 == null)
                {
                    MessageBox.Show("product isn't here.");
                    return;
                }



                o1 = DB.Orders.FirstOrDefault(o => o.ProductId == productId);

                if (o1 != null)
                {
                    o1.Quantity += 1;
                    DB.Orders.AddOrUpdate(o1);
                }

                else
                {
                    Order o2 = new Order();
                    o2.ProductId = productId; 
                    o2.Quantity = 1;

                    DB.Orders.Add(o2);

                    Product p2 = new Product();
                    p2.ProductName = p1.ProductName;

                    DB.Products.Add(p2);
                }

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
                            ProductId = p1.ProductId,
                            Product = p1.ProductName,
                            Quantity = order.Quantity,
                            OrderId = order.OrderId

                        });


                    }

                }

            }

            return ss;

        }

        private void DeleteOrderBut_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int productId = int.Parse(txt3.Text);

                Product p1 = new Product();
                Order o1 = new Order();

                p1 = DB.Products.FirstOrDefault(p => p.ProductId == productId);

                if (p1 == null)
                {
                    MessageBox.Show("product isn't here.");
                    return;
                }
                else if (p1 != null)
                {


                    o1 = DB.Orders.FirstOrDefault(o => o.ProductId == p1.ProductId);

                    if (o1 != null)
                    {
                        DB.Orders.Remove(o1);
                        DB.Products.Remove(p1);
                        DB.SaveChanges();
                        show2();

                    }
                }


            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }



    public class Products1
    {

        public int ProductId { get; set; }
        public string Product { get; set; }

        public int Quantity { get; set; }
        public int OrderId { get; set; }


    }
}
