using Microsoft.EntityFrameworkCore;
using Money.Model.Entity;

namespace Money.Model.Persist
{
    public interface IMoneyContext
    {
        DbSet<Account> Accounts { get; set; }
        DbSet<Transaction> Transactions { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        void ShallowCopy<TEntity>(TEntity source, TEntity target) where TEntity : class;
    }
}
