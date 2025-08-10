using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_App.Models
{
    public class Account 
    {
        public int AccountNumber {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public AccountType AccountType { get; set; }
        protected decimal Balance { get; set; }
        public Account() { }
        public Account(string name, string email, string password, AccountType accountType)
        {
            Name = name;
            Email = email;
            Password = password;
            AccountType = accountType;
        }
        public static List<Transaction> transactions = new List<Transaction>();
        public void SetBalance(decimal value)
        {
            Balance = value;
        }

        public void AddBalance(decimal amount)
        {
            Balance += amount;
        }
        public decimal GetBalance()
        {
            return Balance;
        }

        public void SubtractBalance(decimal amount)
        {
            Balance -= amount;
        }

    }
}
