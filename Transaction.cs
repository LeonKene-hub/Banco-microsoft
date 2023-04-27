using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_microsoft
{
    public class Transaction
    {
        public decimal Amount {get;}
        public DateTime Date {get;}
        public string Notes{get;}

        public Transaction(decimal amount, DateTime date, string note)
        {
            Amount = amount;
            Date = date;
            Notes = note;
        }
    }
}