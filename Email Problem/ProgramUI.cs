using Email_Problem_Repo;
using KomodoClaimsDeptRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email_Problem
{
    public class ProgramUI
    {
        private readonly CustomerRepo _repo = new CustomerRepo();
        bool isProgramRunning = true;
        public void Run()
        {
            while (isProgramRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Insurance Customer Database Please choose a number.\n" +
                                    "1) Add an Customer to the Database\n" +
                                    "2) Delete a Customer from the Database\n" +
                                    "3) Update a Customer from the Database\n" +
                                    "4) View all Customers\n" +
                                    "5) Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        DeleteCustomer();
                        break;
                    case "3":
                        UpdateCustomer();
                        break;
                    case "4":
                        ViewCustomers();
                        break;
                    case "5":
                        isProgramRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option. Press any key to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void UpdateCustomer()
        {
            Console.Clear();
            Console.WriteLine("What is the first name of the customer you want to update? ");
            string firstNameUpdate = Console.ReadLine();
            Console.WriteLine("What is the last name of the customer you want to update? ");
            string lastNameUpdate = Console.ReadLine();
            string fullName = firstNameUpdate + lastNameUpdate;
            Customer customerOld = _repo.GetCustomerByName(fullName);
            Customer customerNew = EnterCustomerDetails();
            _repo.CustomerUpdate(customerOld, customerNew);
        }

        private void CreateCustomer()
        {
            _repo.AddCustomerToList(EnterCustomerDetails());
        }

        private void DeleteCustomer()
        {
            Console.Clear();
            Console.WriteLine("What is the first name of the customer you want to delete? ");
            string firstNameDelete = Console.ReadLine();
            Console.WriteLine("What is the last name of the customer you want to delete? ");
            string lastNameDelete = Console.ReadLine();
            string fullName = firstNameDelete + lastNameDelete;
            Customer customer = _repo.GetCustomerByName(fullName);

            if (_repo.DeleteCustomerFromList(customer))
            {
                Console.WriteLine("Your item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Couldn't find that customer.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        private void ViewCustomers()
        {
            Console.Clear();
            var objListCustomers = _repo.GetAllCustomers();
            var sortedList = objListCustomers.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
            Console.WriteLine("{0,-15}{1,-15}{2,-17}{3}", "First Name", "Last Name", "Customer Type", "Email");
            foreach (var customer in sortedList)
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-17}{3}", customer.FirstName, customer.LastName, customer.TypeOfCustomer, customer.Email);
            }
            Console.ReadLine();
        }

        private Customer EnterCustomerDetails()
        {
            Console.Clear();
            Console.WriteLine("What is the Customer's First Name? ");
            string firstName = Console.ReadLine();

            Console.WriteLine("What is the Customer's Last Name? ");
            string lastName = Console.ReadLine();

            Console.WriteLine("What is the Customer Type? Potential is 1, Current is 2, Past is 3");
            int customerTypeInt = int.Parse(Console.ReadLine());
            CustomerType typeOfCustomer = (CustomerType)customerTypeInt;

            string email;
            switch ((CustomerType)typeOfCustomer)
            {
                case CustomerType.Potential:
                    email = "We currently have the lowest rates on Helicopter Insurance!";
                    break;
                case CustomerType.Current:
                    email = "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
                    break;
                case CustomerType.Past:
                    email = "It's been a long time since we've heard from you, we want you back.";
                    break;
                default:
                    email = "";
                    break;
            }
            Customer customer = new Customer(firstName, lastName, typeOfCustomer, email);
            return customer;
        }
    }
}

