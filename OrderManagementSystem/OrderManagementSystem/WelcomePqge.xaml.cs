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

namespace OrderManagementSystem
{
    /// <summary>
    /// Interaction logic for WelcomePqge.xaml
    /// </summary>
    public partial class WelcomePqge : Page
    {
        public WelcomePqge()
        {
            InitializeComponent();
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            this.NavigationService.Navigate(adminPage);
        }

        private void CustomerButton_Click(object sender, RoutedEventArgs e)
        {
            UserPage userPage = new UserPage();
            this.NavigationService.Navigate(userPage);
        }
    }
}
