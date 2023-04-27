using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banco_microsoft
{
    public class bankAccounts
    {
        //contrutor
        public bankAccounts(string name, decimal initialBalance)
        {
            Numero = accountNumberSeed.ToString();
            accountNumberSeed++;

            Dono = name;
            FazerDeposito(initialBalance, DateTime.Now, "Primeiro deposito");
        }
        private List<Transaction> allTrancactions = new List<Transaction>();


        private static int accountNumberSeed = 1234567890;
        //propriedades
        public string Numero {get;}
        public string Dono {get; set;}
        public decimal Balance {
            get
            {
                decimal balance = 0;
                foreach (var item in allTrancactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        //metodos
        public void FazerDeposito(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor deve ser positivo");
            }
            var deposit = new Transaction(amount, date, note);
            allTrancactions.Add(deposit);
        }
        public void FazerSaque(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "O valor deve ser positivo");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Saldo insuficiente para realizar saque");
            }
            var fazerSaque = new  Transaction(-amount, date, note);
            allTrancactions.Add(fazerSaque);
        }
        public string HistoricoDaConta()
        {
            var reporte = new System.Text.StringBuilder();

            decimal balance = 0;
            reporte.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTrancactions)
            {
                balance += item.Amount;
                reporte.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            return reporte.ToString();
        }
    }
}