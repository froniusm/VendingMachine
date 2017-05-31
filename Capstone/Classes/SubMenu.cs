using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

namespace Capstone.Classes
{
    public class SubMenu
    {
        private VendingMachine vm;

        private List<VendingItem> boughtItems = new List<VendingItem>();

        public SubMenu(VendingMachine fromMainMenu)
        {
            vm = fromMainMenu;  // reference type variables are a thing
        }

        public void Display()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("Current Money Provided: $" + vm.Balance);

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Please enter $1, $2, $5, or $10: "); //How to handle if entered with $?
                    Decimal.TryParse(Console.ReadLine(), out decimal cash);
                    if (cash == 1.00M || cash == 2.00M || cash == 5.00M || cash == 10.00M)
                    {
                        Console.WriteLine("Money Provided: $" + cash);
                        vm.AddMoney(cash);
                        Console.WriteLine("Your new balance is: $" + vm.Balance);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that's an invalid amount.");
                    }
                }
                else if (userInput == "2")
                {
                    Console.WriteLine("Please enter your selection: ");
                    string input = (Console.ReadLine()).ToUpper();

                    if (!vm.IsValidSlot(input))
                    {
                        Console.WriteLine("Invalid product code. Please try again.");
                    }
                    else if (!vm.IsInStock(input))
                    {
                        Console.WriteLine("Sorry, item is sold out");
                    }

                    else
                    {
                        VendingItem userDesiredProduct = vm.GetItemAtSlot(input);
                        decimal cost = userDesiredProduct.Cost;

                        if (vm.Balance < cost)
                        {
                            Console.WriteLine("Please provide more cash");
                        }
                        else
                        {
                            boughtItems.Add(vm.BuyItem(input));
                            Console.WriteLine("Dispensing...");
                            Console.WriteLine("Current Balance: $" + vm.Balance);
                        }
                    }

                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Current Balance: $" + vm.Balance);
                    Console.WriteLine("Your change is " + vm.ReturnChange());
                    foreach (VendingItem item in boughtItems)
                    {
                        Console.WriteLine("Consuming item(s): " + item.MakeEatNoise());
                    }
                    boughtItems.Clear();
                }
                else
                {
                    Console.WriteLine("Please try again.");
                }
            }
        }
    }
}

