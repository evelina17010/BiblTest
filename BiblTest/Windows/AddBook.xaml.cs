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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        public static List<Autor> autors { get; set; }
        public static List<Creat_Build> creat_s { get; set; }
        public static List<Janr> janrs{ get; set; }
        public static List<Shall> challs { get; set; }
        public AddBook()
        {
            InitializeComponent();
            autors = new List<Autor>(Connection.libEntities.Autor.ToList());
            creat_s = new List<Creat_Build>(Connection.libEntities.Creat_Build.ToList());
            janrs= new List<Janr>(Connection.libEntities.Janr.ToList());
            challs = new List<Shall>(Connection.libEntities.Shall.ToList());
            this.DataContext = this;

        }
        private void SaveBook_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();
            if(nametxb.Text!=null && Autor.SelectedItem != null && yearetxb.SelectedDate!= null && Redac.SelectedItem != null && CountPagetxb.Text != null && Shall.SelectedItem != null 
                && shelftxb.Text != null)
            book.Name= nametxb.Text.Trim();
            var autor = Autor.SelectedItem as Autor;
            book.ID_author = autor.ID;
            book.YearMade = yearetxb.SelectedDate;
            var creat= Redac.SelectedItem as Creat_Build;
            book.ID_creat_build =creat.ID;
            var janr = Janr.SelectedItem as Janr;
            book.ID_Janr = janr.ID;
            book.CountPage= int.Parse(CountPagetxb.Text);
            var shall = Shall.SelectedItem as Shall;
            book.IDShall = shall.ID;
            book.Shelf = int.Parse(shelftxb.Text);
            Connection.libEntities.Book.Add(book);
            Connection.libEntities.SaveChanges();
            MessageBox.Show("Новая книга добавлен");
            Close();
        }

        private void addAuhtor_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddAuhtor addAutor = new Windows.AddAuhtor();
            addAutor.Show();
        }

        private void shelftxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(Shall.SelectedItem != null)
            {
                if (Convert.ToInt32(shelftxb.Text) >= (Shall.SelectedItem as Shall).CountShelf)
                    MessageBox.Show("Такой полки нет");
            }
            else MessageBox.Show("Для начала выберите зал");
        }
    }
}
