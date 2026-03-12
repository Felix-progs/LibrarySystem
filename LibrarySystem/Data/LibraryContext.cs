using LibrarySystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Data
{

    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=library.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                .HasOne(L => L.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(L => L.BookId);


            modelBuilder.Entity<Loan>()
                .HasOne(L => L.Member)
                .WithMany(b => b.Loans)
                .HasForeignKey(L => L.MemberId);
        }
    }
}