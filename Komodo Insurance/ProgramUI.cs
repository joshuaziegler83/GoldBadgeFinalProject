using Komodo_Insurance_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Insurance
{
    public class ProgramUI
    {
        private readonly BadgeRepo _repo = new BadgeRepo();
        bool isProgramRunning = true;
        public void Run()
        {
            while (isProgramRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Insurance. Please choose a number.\n" +
                                    "1) Add a New Badge\n" +
                                    "2) Edit Badge\n" +
                                    "3) Delete all Doors from a Badge\n" +
                                    "4) View All Badges\n" +
                                    "5) Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateNewBadge();
                        break;
                    case "2":
                        UpdateDoorsByBadgeID();
                        break;
                    case "3":
                        DeleteAllDoors();
                        break;
                    case "4":
                        ViewBadges();
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

        private void CreateNewBadge()
        {
            Console.Clear();
            Console.WriteLine("What is the Badge ID? ");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the Badge Name? ");
            string badgeName = Console.ReadLine();

            bool moreDoors = true;
            List<string> doorNames = new List<string>();
            do
            {
                Console.WriteLine("Enter a door. Type 'done' when finished.");
                string door = Console.ReadLine();
                if (door.ToLower() != "done")
                {
                    doorNames.Add(door);
                }
                else
                {
                    moreDoors = false;
                }
            }
            while (moreDoors);

            Badge badge = new Badge(badgeID, badgeName, doorNames);

            _repo.AddNewBadge(badge);
        }

        private void DeleteAllDoors()
        {
            Console.Clear();
            Console.WriteLine("Which badge ID do you want to clear the doors from? ");
            int chosenNumber = int.Parse(Console.ReadLine());
            if (_repo.DeleteAllDoorsFromBadge(_repo.GetBadgeByBadgeID(chosenNumber)))
            {
                Console.WriteLine("The doors were successfully deleted.");
            }
            else
            {
                Console.WriteLine("Couldn't find that badge number.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        private void DisplayBadgeByBadgeID(int badgeID)
        {
            var badge = _repo.GetBadgeByBadgeID(badgeID);
        }

        private void ViewBadges()
        {
            Console.Clear();
            var badges = _repo.GetAllBadges();

            foreach (var badge in badges)
            {
                Console.WriteLine($"Badge ID: {badge.BadgeID}\n" +
                                  $"Badge Name: {badge.BadgeName}\n" +
                                   "List of Doors: ");
                foreach (string door in badge.DoorNames)
                {
                    Console.WriteLine($"\t\t\t{door}");
                }
            }
            Console.ReadLine();
        }
        private void UpdateDoorsByBadgeID()
        {
            Console.Clear();
            Console.WriteLine("Which badge ID do you want to edit? ");
            int chosenNumber = int.Parse(Console.ReadLine());
            Badge badge = _repo.GetBadgeByBadgeID(chosenNumber);
            bool moreDoors = true;

            while (moreDoors)
            {
                Console.WriteLine("Do you want to Add a Door, Delete a Door, or Finished (A, D, F)?");

                string choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "A":
                        Console.WriteLine("Which door do you want to add?");
                        string doorAdd = Console.ReadLine();
                        badge.DoorNames.Add(doorAdd);
                        break;
                    case "D":
                        Console.WriteLine("Which door do you want to delete?");
                        string doorDelete = Console.ReadLine();
                        badge.DoorNames.Remove(doorDelete);
                        break;
                    case "F":
                        moreDoors = false;
                        break;
                    default:
                        break;
                }

            }
        }
    }
}

