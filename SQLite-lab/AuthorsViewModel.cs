using System;
using System.Windows;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace SQLite_lab;

public class AuthorsViewModel
{
    public Auth NewAuthor { get; set; } = new Auth();

    public void Save()
    {
        var dbContext = BooksDataContext.GetContext();
        dbContext.Auths.Add(NewAuthor);
        try
        {
            dbContext.SaveChanges();

        }
        catch (DbUpdateException e)
        {
            if ((e.InnerException as SqliteException).SqliteExtendedErrorCode == 275)
                MessageBox.Show("Возраст слишком маленький.");
            else
                MessageBox.Show("Имя у вас дурацкое.");

        }
    }
}