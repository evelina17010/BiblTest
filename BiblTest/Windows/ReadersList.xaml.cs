using BiblTest.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для ReadersList.xaml
    /// </summary>
    public partial class ReadersList : Window
    {
        public static List<Reader> readers { get; set; }
        public ReadersList()
        {
            InitializeComponent();
            readers = new List<Reader>(Connection.libEntities.Reader.Where(i => i.IsDelete == false).ToList());
            this.DataContext = this;
        }

        private void BirthDateUp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var date = BirthDateUp.SelectedDate;          
            lstReaders.ItemsSource = new List<Reader>(Connection.libEntities.Reader.Where(i => i.Bday >= date && i.IsDelete == false).ToList());

        }

        private void EditReaderbtn_Click(object sender, RoutedEventArgs e)
        {
            var reader= lstReaders.SelectedItem as Reader;
            if (reader != null)
            {
                EditReader editReader = new EditReader(reader);
                editReader.Show();
            }
            else MessageBox.Show("выберите читателя");
        }

        private void DelReaderbtn_Click(object sender, RoutedEventArgs e)
        {
            var reader = lstReaders.SelectedItem as Reader;
            if (reader != null)
            {
                MessageBoxResult message = MessageBox.Show($"Вы действительно хотите удалить читателя {reader.LastName} {reader.Name}?", "удаление", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    reader.IsDelete = true;
                    Connection.libEntities.SaveChanges();
                    lstReaders.ItemsSource = new List<Reader>(Connection.libEntities.Reader.Where(i => i.IsDelete == false).ToList());
                }
            }
            else MessageBox.Show("Вы никого не выбрали");
        }

        private void SearchReadersTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var phone=SearchReadersTb.Text;
            if(phone==" ")
            {
                lstReaders.ItemsSource= new List<Reader>(Connection.libEntities.Reader.Where(i => i.IsDelete==false).ToList());
            }
            lstReaders.ItemsSource=new List <Reader>(Connection.libEntities.Reader.Where(i=>i.Phone == phone && i.IsDelete == false).ToList());    

        }
    }
}
