using Microsoft.EntityFrameworkCore;
using PaymentPortal.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Xml;

namespace PaymentPortal.Data
{
    public class PaymentsDbContext : DbContext
    {
        public PaymentsDbContext(DbContextOptions<PaymentsDbContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Id).ValueGeneratedOnAdd();
            });

        }


        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountBalance> AccountBalances { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
