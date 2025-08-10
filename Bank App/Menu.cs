using Bank_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_App
{

    public class Menu
    {
        public static void MainMenu()
        {
            
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                PrintMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        SignUp();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        PrintAbout();
                        break;
                    case "0":
                        Exit();
                        isRunning = false;
                        break;
                    default:
                        Helpers.Color( ConsoleColor.Red, "Invalid choice. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }
        private static void SignUp()
        {
            Console.WriteLine("\n=====SIGN UP=====");
            AccountService.AddAccount();
            Console.WriteLine("Click any key to continue...");
            Console.ReadKey();
            /*Console.Write("Account type: \n 1. Current\n 2. Savings");
            string accountType = Console.ReadLine();
            switch (accountType)
            {
                case "1":
                    Console.WriteLine("You have chosen a Current Account.");

                    break;
                case "2":
                    Console.WriteLine("You have chosen a Savings Account.");
                    break;
                default:
                    Console.WriteLine("Invalid account type. Please try again.");
                    return; // Exit the method if invalid input
            }*/

        }
        private static void Login()
        {
            Console.WriteLine("\n=====LOGIN=====");
            Account account = AccountService.GetAccount();
            if (account == null)
            {
                Helpers.Color( ConsoleColor.Red, "Login failed. Please try again.");
                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
                return;
            }
            PrintLogin(account);
            Console.ReadLine();
            Console.WriteLine($"=====WELCOME BACK {account.Name.ToUpper()}=====");
        }
        private static void PrintMenu()
        {
            Console.WriteLine("\n=====BANK APP MENU=====");
            Console.WriteLine("1. Sign Up");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. About");
            Console.WriteLine("0. Exit");
            Console.Write("Please enter your choice: ");
        }
        private static void PrintLogin(Account account)
        {
            Console.WriteLine($"\nAccount Balance: {account.GetBalance():C}");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. View Account Details");
            Console.WriteLine("4. Transaction History");
            Console.WriteLine("5. Delete Account");
            Console.WriteLine("0. Logout");
            Console.Write("Please enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AccountService.Deposit(account);
                    PrintLogin(account);
                    break;
                case "2":
                    Console.Write("Enter amount to withdraw: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                    AccountService.Withdraw(withdrawAmount, account);
                    PrintLogin(account);
                    break;
                case "3":
                    AccountService.DisplayAccountDetails(account);
                    PrintLogin(account);
                    break;
                case "4":
                    AccountService.PrintTransactionHistory(account);
                    PrintLogin(account);
                    break;
                case "5":
                    AccountService.DeleteAccount();
                    break;
                case "0":
                    MainMenu();
                    break;
                default:
                    Helpers.Color(ConsoleColor.Red, "Invalid choice. Please try again.");
                    break;
            }
        }
        private static void PrintAbout()
        {
            Console.WriteLine("=====ABOUT=====");
            Console.WriteLine();
            Console.ReadLine();
        }
        private static void Exit()
        {
            Console.WriteLine("\nThank you for using Bank App. Goodbye!");
            Environment.Exit(0);
        }

    }
}
