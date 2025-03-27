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


namespace BiblTest.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAuhtor.xaml
    /// </summary>
    public partial class AddAuhtor : Window
    {

        public AddAuhtor()
        {
            InitializeComponent();
        }

        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            Autor autor = new Autor();
            if(lastnametxb.Text!=null && nametxb.Text != null && pattxb.Text != null )
            autor.LastName = lastnametxb.Text.Trim();
            autor.Name = nametxb.Text.Trim();
            autor.Patronymic = pattxb.Text.Trim();
            Connection.libEntities.Autor.Add(autor);
            Connection.libEntities.SaveChanges();
            MessageBox.Show("Новый автор добавлен");
            Close();
        }
    }
}
