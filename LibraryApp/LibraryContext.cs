using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    public class LibraryContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LibraryApp;Integrated Security=True;Connect Timeout=30;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(e =>
            {
                e.HasKey(a => a.AccountNumber)
                 .HasName("PK_Accounts");

                e.ToTable("Accounts");

                e.Property(a => a.AccountNumber).ValueGeneratedOnAdd();

                e.Property(a => a.EmailId).IsRequired().HasMaxLength(100);

                e.Property(a => a.AccountType).IsRequired();
            });

            modelBuilder.Entity<Activity>(e =>
            {
                e.ToTable("Activities");

                e.HasKey(t => t.ActivityId).HasName("PK_Activities");

                e.Property(t => t.ActivityId).ValueGeneratedOnAdd();

                e.Property(t => t.BookCount).IsRequired();

                e.HasOne(t => t.Account).WithMany().HasForeignKey(t => t.AccountNumber);
            });
        }
    }
}
