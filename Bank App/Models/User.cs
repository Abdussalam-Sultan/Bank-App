using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_App.Models
{
    public class User
    {
        private static int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public User() {}
        public User(string name, string email, string password, string phoneNumber, string address)
        {
            Name = name;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            Address = address;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Email: {Email}, Phone: {PhoneNumber}, Address: {Address}";
        }
    }
}
