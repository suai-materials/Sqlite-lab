using Microsoft.EntityFrameworkCore;

namespace SQLite_lab;

public class ApplicationContext : DbContext
{
    private static ApplicationContext? _context;
    public DbSet<User> Users { get; set; } = null!;


    public static ApplicationContext GetContext()
    {
        if (_context == null) _context = new ApplicationContext();
        return _context;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=db.db");
    }
}