using System.Linq;
using System.Windows;

namespace SQLite_lab;

public partial class SecondTask : Window
{
    private AuthorsViewModel viewModel = new AuthorsViewModel();
    public SecondTask()
    {
        InitializeComponent();
        Load();
    }

    private void Load()
    {
        var db = BooksDataContext.GetContext();
        AuthorsGrid.ItemsSource = db.Auths.ToList();
        BooksGrid.ItemsSource = db.Books.ToList();
        AuthorsBooksGrid.ItemsSource = db.AuthBooks.ToList();
        DataContext = viewModel;
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        viewModel.Save();
        var db = BooksDataContext.GetContext();
        AuthorsGrid.ItemsSource = db.Auths.ToList();
    }
}