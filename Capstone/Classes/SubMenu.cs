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

        private VendingMachine vm2;
        public VendingMachine Vm2
        {
            get { return vm2; }
        }

        public SubMenu(VendingMachine fromMainMenu)
        {
            vm2 = fromMainMenu;  // reference type variables are a thing
        }

        public void Display()
        {
            while (true)
            {

                Console.WriteLine();
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                Console.WriteLine("(Q) Back To Main Menu");
                Console.WriteLine("Current Money Provided: " + vm2.Balance);

                string userInput = Console.ReadLine();

                if (userInput == "1")
                {
                    Console.WriteLine("Please enter $1, $2, $5, or $10: ");
                    decimal cash = Decimal.Parse(Console.ReadLine());
                    if (cash == 1.00M || cash == 2.00M || cash == 5.00M || cash == 10.00M)
                    {
                        Console.WriteLine("Money Provided: $" + cash);
                        vm2.AddMoney(cash);
                        Console.WriteLine("Your new balance is: $" + vm2.Balance);
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

                    if (!vm2.Inventory.ContainsKey(input))
                    {
                        Console.WriteLine("Invalid product code. Please try again.");
                    }
                    else if (!vm2.isInStock(input))
                    {
                        Console.WriteLine("Sorry, item is sold out");
                    }

                    else
                    {
                        List<VendingItem> userDesiredProduct = (vm2.Inventory)[input];
                        decimal cost = userDesiredProduct[0].Cost;

                        if (vm2.Balance < cost)
                        {
                            Console.WriteLine("Please provide more cash");
                        }
                        else if (vm2.Inventory.ContainsKey(input))
                        {
                            vm2.BuyItem(input);
                            Console.WriteLine("Dispensing...");
                            Console.WriteLine("Current Balance: " + vm2.Balance);
                        }
                    }

                }
                else if (userInput == "3")
                {
                    Console.WriteLine("Current Balance: " + vm2.Balance);
                    Console.WriteLine("Your change is " + vm2.ReturnChange());
                    // Console.WriteLine("Item is being consumed: " + vm2.MakeEatNoises); // Need to add more code to VendingMachine first
                    // before writing the items consumed
                }
                else if (userInput == "Q" || userInput == "q")
                {
                    break;
                }
            }
        }
    }
}

