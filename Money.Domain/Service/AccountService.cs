using System.Collections.Generic;
using System.Linq;
using Money.Domain.Lib;
using Money.Model.Entity;
using Money.Model.Lib;
using Money.Model.Persist;

namespace Money.Domain.Service
{
    public class AccountService
    {
        readonly MoneyContext moneyContext;
        readonly IEntityPersister entityPersister;

        public AccountService(MoneyContext moneyContext, IEntityPersister entityPersister)
        {
            this.moneyContext = moneyContext;
            this.entityPersister = entityPersister;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return null;
        }

        public void Save(Account account)
        {
            entityPersister.Save(account);
        }
    }
}
