using System.Collections.Generic;
using Money.Model.Entity;

namespace Money.Domain.Interface
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAll();
        void Save(Account account);
    }
}
