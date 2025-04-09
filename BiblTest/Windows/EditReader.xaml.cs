using BiblTest.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
    /// Логика взаимодействия для EditReader.xaml
    /// </summary>
    public partial class EditReader : Window
    {
        public static Reader reader1= new Reader();
        public EditReader(Reader reader )
        {
            InitializeComponent();
            reader1=reader;
            LastNametxb.Text = reader1.LastName;
            Nametxb.Text = reader1.Name;
            Patronymictxb.Text = reader1.Patronymic;
            Bdaytxb.Text =reader1.Bday.ToString();
            Phonetxb.Text = reader1.Phone;
        }

        private void Savebtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult message = MessageBox.Show($"Вы действительно хотите удалить читателя {reader1.LastName} {reader1.Name}?", "удаление", MessageBoxButton.YesNo);
            if (message == MessageBoxResult.Yes)
            {
                reader1.LastName = LastNametxb.Text;
                reader1.Name = Nametxb.Text;
                reader1.Patronymic = Patronymictxb.Text;
                reader1.Phone = Phonetxb.Text;
                reader1.Bday = Bdaytxb.SelectedDate;
                Connection.libEntities.SaveChanges();                
               MessageBox.Show("читатель успешно изменен");
                Close();
            }
            else MessageBox.Show("Отмена изменений");
            Close();

        }
    }
}
