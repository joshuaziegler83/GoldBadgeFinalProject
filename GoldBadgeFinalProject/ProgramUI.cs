using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeFinalProject
{
    public class ProgramUI
    {
        private readonly MenuRepository _repo = new MenuRepository();
        bool isProgramRunning = true;
        public void Run()
        {
            while (isProgramRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Cafe. Please choose a number.\n" +
                                    "1) Add an Item to the Menu\n" +
                                    "2) Delete an Item from the Menu\n" +
                                    "3) View the Menu\n" +
                                    "4) Exit");
                switch (Console.ReadLine())
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        DeleteMenuItem();
                        break;
                    case "3":
                        ViewMenu();
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

        private void CreateMenuItem()
        {
            Console.Clear();
            Console.WriteLine("What is the Meal Number? ");
            int mealNum = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the Meal Name? ");
            string mealName = Console.ReadLine();

            Console.WriteLine("What is a brief description of the menu item? ");
            string description = Console.ReadLine();

            bool moreIngredients = true;
            List<string> ingredients = new List<string>();
            
            do
            {
                Console.WriteLine("Enter an ingredient. Type 'done' when finished.");
                string ingredient = Console.ReadLine();
                if (ingredient.ToLower() != "done")
                {
                    ingredients.Add(ingredient);
                }
                else
                {
                    moreIngredients = false;
                }
            }
            while (moreIngredients);

            Console.WriteLine("What is the price? ");
            double price = double.Parse(Console.ReadLine());

            Menu menuItem = new Menu(mealNum, mealName, description, ingredients, price);

            _repo.AddItemToMenu(menuItem);
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Which meal number do you want to delete? ");
            DisplayMenuItemByNumber();
            int chosenNumber = int.Parse(Console.ReadLine());
            if (_repo.DeleteItemFromMenu(_repo.GetMenuItemByNumber(chosenNumber)))
            {
                Console.WriteLine("Your item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("Couldn't find that item number.");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
        }

        private void DisplayMenuItemByNumber()
        {
            var menuItems = _repo.GetAllMenuItems();
            foreach(var item in menuItems)
            {
                Console.WriteLine($"Meal Number: {item.MealNum} | Meal Name: {item.MealName}");
            }
        }

        private void ViewMenu()
        {
            Console.Clear();
            var menuItems = _repo.GetAllMenuItems();

            foreach(var item in menuItems)
            {
                Console.WriteLine($"Meal Number: {item.MealNum}\n" +
                                  $"Meal Name: {item.MealName}\n" +
                                  $"Description: {item.Description}\n" +
                                  $"Price: {item.Price.ToString("C2")}\n" +
                                   "List of Ingredients: ");
                foreach(string ingredient in item.Ingredients)
                {
                    Console.WriteLine($"\t\t\t{ingredient}");
                }          
            }
            Console.ReadLine();
        }
    }
}
