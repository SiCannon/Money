using Microsoft.EntityFrameworkCore;
using Money.Model.Entity;

namespace Money.Model.Persist
{
    public class MoneyContext : DbContext, IMoneyContext
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

        public void ShallowCopy<TEntity>(TEntity source, TEntity target) where TEntity : class
        {
            Entry(target).CurrentValues.SetValues(source);
        }
    }
}
