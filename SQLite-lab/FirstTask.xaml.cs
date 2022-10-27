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
using Microsoft.EntityFrameworkCore;

namespace SQLite_lab;

/// <summary>
/// Interaction logic for FirstTask.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Load();
    }

    private void Load()
    {
        User user = new() {Name = "Вася", Age = 10, Id = 1};
        var db = ApplicationContext.GetContext();
        db.Database.EnsureCreated();
        db.Users.Add(user);
        db.SaveChanges();
        DataGrid.ItemsSource = db.Users.ToList();
    }
}