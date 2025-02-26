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

namespace BiblTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authoresation.xaml
    /// </summary>
    public partial class Authoresation : Page
    {
        public Authoresation()
        {
            InitializeComponent();
        }

        private void btnVhod_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnVhodChit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorisationPage());
        }
    }
}
