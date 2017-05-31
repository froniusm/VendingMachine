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
                    foreach (string slot in vm.Slots) // Loop through items in inventory
                    {
                        VendingItem product = vm.GetItemAtSlot(slot);
                        if (product == null)
                        {
                            Console.WriteLine("Sold out!");
                        }
                        else
                        {
                            string item = product.Name.PadRight(20) + " ";
                            string price = product.Cost.ToString().PadRight(10) + " ";

                            Console.WriteLine(slot.PadRight(10) + " " + item + price + "in stock"); // Displays vending items with quantity remaining
                        }
                    }
                }
                else if (input == "2")
                {
                    SubMenu submenu = new SubMenu(vm);
                    submenu.Display();
                }
                else if (input == "Q" || input == "q")
                {
                    return;
                }
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
