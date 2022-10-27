using System;
using System.Collections.Generic;

namespace SQLite_lab;

public partial class AuthBook
{
    public long AuthId { get; set; }
    public long BooksId { get; set; }

    public virtual Auth Auth { get; set; } = null!;
    public virtual Book AuthNavigation { get; set; } = null!;
}