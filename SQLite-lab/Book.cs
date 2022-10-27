using System;
using System.Collections.Generic;

namespace SQLite_lab;

public partial class Book
{
    public Book()
    {
        AuthBooks = new HashSet<AuthBook>();
    }

    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public long CountPage { get; set; }
    public double? Price { get; set; }

    public virtual ICollection<AuthBook> AuthBooks { get; set; }
}