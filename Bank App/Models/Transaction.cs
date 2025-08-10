using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bank_App.Models
{
    public class Transaction
    {
        private string Id { get; set; }
        private string Name { get; set; }
        private decimal Amount { get; set; }
        public string Type { get; set; }
        private DateTime createdAt { get; set; }
        public Transaction ( decimal amount, string type)
        {
            Amount = amount;
            Type = type;
            createdAt = DateTime.Now;
        }
        public override string ToString()
        {
            return $"{Type}: {Amount:C} - {createdAt}";
        }
    }
}
