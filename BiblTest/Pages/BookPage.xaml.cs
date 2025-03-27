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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiblTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookPage.xaml
    /// </summary>
    public partial class BookPage : Page
    {
        public static List<Book> books {  get; set; }
        public static List<Autor> autors { get; set; }
        public BookPage()
        {
            InitializeComponent();
            books = new List<Book>(Connection.libEntities.Book.Where(i => i.IsDelete == false).ToList());
            autors= new List<Autor>(Connection.libEntities.Autor.ToList());
            autors.Insert(0, new Autor() { ID = -1, LastName = "Вывести всех" });
            this.DataContext = this;
        }

        private void BookSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = BookSearch.Text.Trim();
            if (search == "")
                lstBook.ItemsSource = books.ToList();
            else
                lstBook.ItemsSource = books.Where(i => i.ID.ToString() == search).ToList();
        }
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddBook addBook = new Windows.AddBook();
            addBook.Show();
        }

        private void Filter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = Filter.SelectedItem as Autor;
            if (a.ID != -1)
                lstBook.ItemsSource = books.Where(i => i.ID_author == a.ID).ToList();
            else
                lstBook.ItemsSource = books.ToList();
        }
    }
}
