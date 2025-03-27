using BiblTest.db;
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

namespace BiblTest.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddReader.xaml
    /// </summary>
    public partial class AddReader : Window
    {
        public AddReader()
        {
            InitializeComponent();
        }

        private void SaveReader_Click(object sender, RoutedEventArgs e)
        { 
            Reader reader = new Reader();
            if (lastnametxb.Text != null && nametxb.Text!=null && pattxb.Text!=null && bday.SelectedDate!=null && phonetxb.Text!=null)
                reader.LastName= lastnametxb.Text.Trim();
            reader.Name= nametxb.Text.Trim();
            reader.Patronymic= pattxb.Text.Trim();
            reader.Bday= bday.SelectedDate;
            reader.Phone= phonetxb.Text.Trim();
            reader.IsDelete = false;
            Connection.libEntities.Reader.Add(reader);
            Connection.libEntities.SaveChanges();
            MessageBox.Show("Новый читатель добавлен");
            Close();
        }
    }
}
