using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SQLite_lab;

public partial class BooksDataContext : DbContext
{
    
    private static BooksDataContext? _context;

    public BooksDataContext()
    {
    }

    public BooksDataContext(DbContextOptions<BooksDataContext> options)
        : base(options)
    {
    }
    public static BooksDataContext GetContext()
    {
        if (_context == null) _context = new BooksDataContext();
        return _context;
    }

    public virtual DbSet<Auth> Auths { get; set; } = null!;
    public virtual DbSet<AuthBook> AuthBooks { get; set; } = null!;
    public virtual DbSet<Book> Books { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            optionsBuilder.UseSqlite(
                "Data Source=C:\\Users\\user\\Desktop\\labs\\04.01\\SQLite-lab\\SQLite-lab\\res\\Books.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auth>(entity =>
        {
            entity.ToTable("auth");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Age).HasColumnName("age");

            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<AuthBook>(entity =>
        {
            entity.HasKey(e => new {e.AuthId, e.BooksId});

            entity.ToTable("auth_book");

            entity.Property(e => e.AuthId).HasColumnName("auth_id");

            entity.Property(e => e.BooksId).HasColumnName("books_id");

            entity.HasOne(d => d.Auth)
                .WithMany(p => p.AuthBooks)
                .HasForeignKey(d => d.AuthId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.AuthNavigation)
                .WithMany(p => p.AuthBooks)
                .HasForeignKey(d => d.AuthId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("books");

            entity.Property(e => e.CountPage).HasColumnName("count_page");

            entity.Property(e => e.Price).HasColumnName("price");

            entity.Property(e => e.Title).HasColumnName("title");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}