using Bank_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_App
{
    internal interface IAccount
    {
        int AccountNumber { get; }
        string Name { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        //AccountType AccountType { get; set; }
        // void AddAccount(Account account);
        void AddAccount();
        Account GetAccount();
        void DisplayAccountDetails();
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void SetBalance(decimal balance);
        decimal GetBalance();
        void DeleteAccount();
    }
}
