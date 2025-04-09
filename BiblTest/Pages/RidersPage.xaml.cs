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
using BiblTest.Windows;

namespace BiblTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для RidersPage.xaml
    /// </summary>
    public partial class RidersPage : Page
    {
        public static List <Employee1> employees {  get; set; }
        public static List <Reader_Ticket> reader_tic {  get; set; }
        public RidersPage()
        {
            InitializeComponent();
            reader_tic=new List<Reader_Ticket>(Connection.libEntities.Reader_Ticket.Where( i=>i.Reader.IsDelete==false && i.IsDelete==false).ToList());
            employees=new List<Employee1> (Connection.libEntities.Employee1.Where(i =>i.IsDelete == false).ToList()); 
            employees.Insert(0, new Employee1() { ID = -1, LastName = "Вывести всех" });
            this.DataContext = this;  
        }

        private void TicketSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search =TicketSearch.Text.Trim();
            if(search=="")
                lstReader.ItemsSource=reader_tic.ToList();
            else
            lstReader.ItemsSource=reader_tic.Where(i=>i.ID_Reader.ToString()==search).ToList();
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  var t= lstReader.SelectedItem as Employee1;               
            if(t.ID!=-1)
            lstReader.ItemsSource = reader_tic.Where(i => i.ID_Emp == t.ID).ToList();
            else
                lstReader.ItemsSource = reader_tic.ToList() ;
        }

        private void RegChit_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddRiderTic addRiderTic = new Windows.AddRiderTic();
            addRiderTic.Show();
              
        }

        private void RegReader_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddReader addReader = new Windows.AddReader();
            addReader.Show();
        }

        private void Readersbtn_Click(object sender, RoutedEventArgs e)
        {
            ReadersList readersList = new ReadersList();
            readersList.Show();
        }
    }
}
