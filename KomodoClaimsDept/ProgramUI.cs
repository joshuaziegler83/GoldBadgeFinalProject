using KomodoClaimsDeptRepo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDept
{
    public class ProgramUI
    {
        private readonly ClaimRepository _repo = new ClaimRepository();

        bool isProgramRunning = true;

        public void Run()
        {
            _repo.InitializeDataTable();
            while (isProgramRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Claims. Please choose a number.\n" +
                                    "1) See All Claims\n" +
                                    "2) Take Care of Next Claim\n" +
                                    "3) Add a Claim to the Queue\n" +
                                    "4) Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        ViewClaimsInQueue();
                        break;
                    case "2":
                        TakeCareOfClaim();
                        break;
                    case "3":
                        AddANewClaim();
                        break;
                    case "4":
                        isProgramRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option. Press any key to continue.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private void ViewClaimsInQueue()
        {
            _repo.DisplayAllClaims();
        }

        private void AddANewClaim()
        {
            Claim claim = new Claim();
            Console.Clear();
            Console.WriteLine("What is the Claim ID? ");
            claim.ClaimID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the Claim Type? Car is 1, Home is 2, Theft is 3");
            int claimTypeInt = int.Parse(Console.ReadLine());
            claim.ClaimType = (ClaimType)claimTypeInt;

            Console.WriteLine("What is a brief description of the claim? ");
            claim.Description = Console.ReadLine();

            Console.WriteLine("What is the claim amount? ");
            claim.ClaimAmount = double.Parse(Console.ReadLine());

            Console.WriteLine("When was the date of the Incident? Please use MM/DD/YYYY format ");

            DateTime DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("When was the date of the claim? Please use MM/DD/YYYY format ");

            DateTime DateOfClaim = Convert.ToDateTime(Console.ReadLine());

            claim.IsValid = ((DateOfClaim.Date - DateOfIncident.Date).Days <= 30);
            claim.DateOfClaim = DateOfClaim.ToShortDateString();
            claim.DateOfIncident = DateOfIncident.ToShortDateString();

            _repo.AddClaimToQueue(claim);
        }

        private void TakeCareOfClaim()
        {
            Console.Clear();
            Console.WriteLine("Do you want to take care of the first claim in the queue (y or n)? ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "y")
            {
                _repo.DeleteClaimFromQueue();
            }
        }
    }
}

