using System.Collections.Generic;
using Money.Model.Lib;

namespace Money.Model.Entity
{
    public class Account : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
