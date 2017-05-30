using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class MainMenu
    {
        public void Display()
        {
            PrintHeader();

            VendingMachine vm = new VendingMachine();
            Dictionary<string, List<VendingItem>> inventory = vm.Inventory; // Reference type variable

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("(Q) Quit");
                Console.WriteLine("What option do you want to select?");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Slot ID".PadRight(11) + "Product".PadRight(21) + "Price".PadRight(11) + "Quantity".PadRight(10));
                    Console.WriteLine();
                    foreach (KeyValuePair<string, List<VendingItem>> kvp in inventory) // Loop through items in inventory
                    {
                        if (kvp.Value.Count == 0)
                        {
                            Console.WriteLine("Sold out!");
                        }
                        else
                        {
                            VendingItem product = kvp.Value[0];
                            decimal cost = 10000000;
                            string name = "";
                            if (product is Chip)
                            {
                                Chip temp = (Chip)product;
                                cost = temp.Cost;
                                name = temp.Name;
                            }
                            else if (product is Candy)
                            {
                                Candy temp = (Candy)product;
                                cost = temp.Cost;
                                name = temp.Name;
                            }
                            else if (product is Drink)
                            {
                                Drink temp = (Drink)product;
                                cost = temp.Cost;
                                name = temp.Name;
                            }
                            else // (Product is Gum)
                            {
                                Gum temp = (Gum)product;
                                cost = temp.Cost;
                                name = temp.Name;
                            }
                            string slotId = kvp.Key.PadRight(10) + " ";
                            string item = name.PadRight(20) + " ";
                            string price = cost.ToString().PadRight(10) + " ";
                            int quantity = kvp.Value.Count;

                            Console.WriteLine(slotId + item + price + quantity); // Displays vending items with quantity remaining
                        }
                    }
                }
                else if (input == "2")
                {
                    SubMenu submenu = new SubMenu(vm);
                    submenu.Display();
                }

                else if (input == "Q" || input == "q")
                    return;
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }

        }

        private void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE VENDO-MATIC 500!!!");
        }
    }
}
