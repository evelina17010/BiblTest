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
using BiblTest.db;

namespace BiblTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для RidersPage.xaml
    /// </summary>
    public partial class RidersPage : Page
    {
        public static List <Reader_Ticket> reader_tic {  get; set; }
        public RidersPage()
        {
            InitializeComponent();
            reader_tic=new List<Reader_Ticket>(Connection.libEntities.Reader_Ticket.Where( i=>i.Reader.IsDelete==false && i.IsDelete==false).ToList());
            this.DataContext = this;  
        }
    }
}
