using BankManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace BankManagement.Infrastructure.Data
{
    public class BankContext : DbContext
    {
        public BankContext() { }

        public BankContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => new { c.AdhaarNumber, c.PANNumber });

            // Other configurations...

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<UPICreation> UPICreation { get; set; }
        public virtual DbSet<UPITransaction> UPITransaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=BankDetails;Integrated Security=True;TrustServerCertificate=True;");
    }
}
