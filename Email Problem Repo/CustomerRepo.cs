using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Problem_Repo
{
    public class CustomerRepo
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public bool AddCustomerToList(Customer customer)
        {
            var count = _customers.Count;
            _customers.Add(customer);
            if (count < _customers.Count)
            {
                return true;
            }
            return false;
        }

        public bool DeleteCustomerFromList(Customer customer)
        {
            if (_customers.Contains(customer))
            {
                return _customers.Remove(customer);
            }
            return false;
        }

        public List<Customer> GetAllCustomers()
        {
            return _customers;
        }

        public Customer GetCustomerByName(string fullName)
        {
            foreach (var item in _customers)
            {
                if (fullName == item.FirstName + item.LastName)
                {
                    return item;
                }
                continue;
            }
            return null;
        }

        public void CustomerUpdate(Customer customerOld, Customer customerNew)
        {
            customerOld.FirstName = customerNew.FirstName;
            customerOld.LastName = customerNew.LastName;
            customerOld.TypeOfCustomer = customerNew.TypeOfCustomer;
            customerOld.Email = customerNew.Email;
        }
    }
}
