using System;
using System.Collections.Generic;

namespace SQLite_lab;

public partial class Auth
{
    public Auth()
    {
        AuthBooks = new HashSet<AuthBook>();
    }

    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public long? Age { get; set; }

    public virtual ICollection<AuthBook> AuthBooks { get; set; }
}