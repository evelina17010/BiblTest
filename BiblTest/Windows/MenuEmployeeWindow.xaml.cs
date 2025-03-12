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
using System.Windows.Shapes;
using BiblTest.db;
using BiblTest.Pages;

namespace BiblTest.Windows
{
    /// <summary>
    /// Логика взаимодействия для MenuEmployeeWindow.xaml
    /// </summary>
    public partial class MenuEmployeeWindow : Window
    {
        public MenuEmployeeWindow()
        {
            InitializeComponent();
        }

        private void readerBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuFr.NavigationService.Navigate(new RidersPage());
        }

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reportBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
