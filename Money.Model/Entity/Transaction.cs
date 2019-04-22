using System;
using System.Collections.Generic;
using System.Text;

namespace Money.Model.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public virtual Account Account { get; set; }
    }
}
