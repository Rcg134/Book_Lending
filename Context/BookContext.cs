using System;
using System.Collections.Generic;
using Book_Lending.Models.Book;
using Microsoft.EntityFrameworkCore;

namespace Book_Lending.Context;

public partial class BookContext : DbContext
{
    public BookContext()
    {
    }

    public BookContext(DbContextOptions<BookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
   
        modelBuilder.Entity<Book>(entity =>
        {
            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("Book_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_Date");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Transaction");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BokkId).HasColumnName("Bokk_id");
            entity.Property(e => e.BorrowedDate)
                .HasColumnType("datetime")
                .HasColumnName("Borrowed_Date");
            entity.Property(e => e.IcountBorrowedItems).HasColumnName("Icount_Borrowed_items");
            entity.Property(e => e.IsReturn).HasColumnName("isReturn");
            entity.Property(e => e.ReturnDate)
                .HasColumnType("datetime")
                .HasColumnName("Return_Date");
            entity.Property(e => e.UserId).HasColumnName("User_id");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId).HasColumnName("User_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("created_Date");
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
