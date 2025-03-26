using BiblTest.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace BiblTest.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddRiderTic.xaml
    /// </summary>
    public partial class AddRiderTic : Window
    {
        public static List<Reader> readers {  get; set; }
        public static List<Employee1> employees { get; set; }
        public AddRiderTic()
        {
            InitializeComponent();
            readers= new List<Reader>(Connection.libEntities.Reader.Where(i => i.IsDelete == false).ToList());
            employees = new List<Employee1>(Connection.libEntities.Employee1.Where(i => i.IsDelete == false).ToList());
            this.DataContext = this;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Reader_Ticket reader_Ticket = new Reader_Ticket();
            reader_Ticket.IsDelete = false;
            reader_Ticket.DateReg = DateTime.Now;
            var reader=Chit.SelectedItem as Reader;
            reader_Ticket.ID_Reader = reader.ID;
            var employee=Sotr.SelectedItem as Employee1;
            reader_Ticket.ID_Emp=employee.ID;
            Connection.libEntities.Reader_Ticket.Add(reader_Ticket);
            Connection.libEntities.SaveChanges();
            MessageBox.Show("Новый билет добавлен");
            Close();
        }


        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Chit.ItemsSource=new List<Reader> (Connection.libEntities.Reader.Where(i=>i.IsDelete == false).ToList());
        }
    }
}
