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
    {/*
        public void Display()
        {
            PrintHeader();

            while (true)
            {
                VendingMachine vm = new VendingMachine();
                Dictionary<string, List<VendingItem>> inventory = vm.Inventory; // Reference type variable
                

                Console.WriteLine();
                Console.WriteLine("(1) Display Vending Machine Items");
                Console.WriteLine("(2) Purchase");
                Console.WriteLine("What option do you want to select?");

                string input = Console.ReadLine();
                if (input == "1")
                {
                    foreach (KeyValuePair<string, List<VendingItem>> kvp in inventory)
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
                            Console.WriteLine("Product selection: ".PadRight(20) + kvp.Key.PadRight(5) + " " + name.PadRight(20) + " " + cost);
                        }
                    }
                }
                else if(input == "2")
                {
                    SubMenu submenu = new SubMenu(vm);
                    submenu.Display();
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
        }*/
    }
}
