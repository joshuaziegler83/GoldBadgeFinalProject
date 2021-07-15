using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Problem_Repo
{
    public enum CustomerType
    {
        Potential = 1,
        Current,
        Past
    }
    public class Customer
    {
        public Customer(string firstName, string lastName, CustomerType typeOfCustomer, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            TypeOfCustomer = typeOfCustomer;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType TypeOfCustomer { get; set; }
        public string Email { get; set; }
    }
}
