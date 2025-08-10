using Bank_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace Bank_App
{
    class AccountService : Account
    {

        private static List<Account> accounts = new List<Account>
        {
            new Account{Name = "ADMIN", Email = "a", Password = "a"},
            new Account{Name = "Sultan Abdussalam", Email = "q", Password = "q"},
        };
        public static void AddAccount()
        {
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Email: ");
            string email = Console.ReadLine();
            if (accounts.Any(a => a.Email == email))
            {
                Helpers.Color(ConsoleColor.Red, "An account with this email already exists. Please try again.");
                return;
            }
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Helpers.Color(ConsoleColor.Red, "All fields are required. Please try again.");
                return;
            }
            Account newAccount = new Account();
            newAccount.Name = name;
            newAccount.Email = email;
            newAccount.Password = password;
            accounts.Add(newAccount);
            Console.WriteLine("Account created successfully!");
        }
        public static Account GetAccount()
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            Account account = accounts.FirstOrDefault(a => a.Email == email & a.Password == password);
            if (account == null)
            {
                Helpers.Color(ConsoleColor.Red, "Invalid email or password. Please try again.");
                return null;
            }
            Console.WriteLine($"Login successful for {account.Name}.");
            /*if (account != null)
            {
                return account;
            }
            else { Console.WriteLine("No account found"); }*/
            return account;
        }

        public static void DisplayAccountDetails(Account account)
        {
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Email: {account.Email}");
            Console.WriteLine($"Account Type: {account.AccountType}");
        }
        public static void Deposit( Account account)
        {
            try
            {
                Console.Write("Enter amount to deposit: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                account.AddBalance(amount);
                Console.WriteLine($"Deposited {amount:C} to {account.Name}'s account.");
                Models.Transaction transaction = new Models.Transaction(amount, "Deposit");
                transactions.Add(transaction);
            }
            catch (FormatException ex) { Helpers.Color( ConsoleColor.Red, ex.Message); }
            catch (Exception ex) { }
        }
        public static void Withdraw(decimal amount,Account account)
        {
            if (amount > account.GetBalance())
            {
                Helpers.Color(ConsoleColor.Red, "Insufficient funds for withdrawal.");
                return;
            }
            if (amount <= 0)
            {
                Helpers.Color(ConsoleColor.Red, "Withdrawal amount must be greater than 0.");
                if(account.AccountType == AccountType.Current)
                {
                    Console.WriteLine("Would you like to take a loan");
                    string result = Console.ReadLine().ToLower();
                    if (result == "yes")
                    {
                        LoanAccount(account);
                    }
                    else if (result == "no") { Console.WriteLine("Loan Request cancelled"); }
                }
                return;
            }
            account.SubtractBalance(amount);
            Console.WriteLine($"Withdrew {amount:C} from {account.Name}'s account.");
            Models.Transaction  transaction = new Models.Transaction(amount,"Withdraw");
            transactions.Add(transaction);
        }
        public static void DeleteAccount()
        {
            Console.WriteLine("Enter your password to delete your account: ");
            string password = Console.ReadLine();

            Account accountToDelete = accounts.FirstOrDefault(x => x.Password == password);
            Console.WriteLine("Are you sure you want to delete this account (Yes or No)");
            string result = Console.ReadLine().ToLower();
            if (result == "yes")
            {
                accounts.Remove(accountToDelete);
                Console.WriteLine($"Account for {accountToDelete.Name} has been deleted.");
            }
            else if (result == "no") { Console.WriteLine("Delete Request cancelled"); }
        }
        public static Account FindAccountByEmail(string email)
        {
            return accounts.FirstOrDefault(a => a.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
        }
        public static void PrintAllAccounts()
        {
            Console.WriteLine("List of all accounts:");
            foreach (var account in accounts)
            {
                DisplayAccountDetails(account);
                Console.WriteLine("-------------------------");
            }
        }
        public static void ClearAccounts()
        {
            accounts.Clear();
            Console.WriteLine("All accounts have been cleared.");
        }
        private static void LoanAccount(Account account)
        {

        }
        public static void PrintTransactionHistory(Account account)
        {
            Console.WriteLine($"\nTransaction history for {account.Name} ({account.Email}):");
            foreach (var tx in transactions)
            {
                Console.WriteLine(tx.ToString());
            }
        }
    }
}
