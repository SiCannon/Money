using System.Collections.Generic;
using Money.Domain.Interface;
using Money.Domain.Lib;
using Money.Model.Entity;
using Money.Model.Persist;

namespace Money.Domain.Service
{
    public class AccountService : IAccountService
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
            return moneyContext.Accounts;
        }

        public void Save(Account account)
        {
            entityPersister.Save(account);
        }
    }
}
