using Microsoft.EntityFrameworkCore;
using Money.Model.Entity;

namespace Money.Model.Persist
{
    public class MoneyContext : DbContext
    {
        public MoneyContext(DbContextOptions<MoneyContext> options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(eb =>
            {
                eb.Property(b => b.Amount).HasColumnType("decimal(10,2)");
            });
        }
    }
}
