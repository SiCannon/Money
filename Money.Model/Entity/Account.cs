using System;
using System.Collections.Generic;
using System.Text;

namespace Money.Model.Entity
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
