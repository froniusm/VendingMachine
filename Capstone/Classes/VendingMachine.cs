using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        private Dictionary<string, List<VendingItem>> inventory;
        public Dictionary<string, List<VendingItem>> Inventory
        {
            get { return this.inventory; }
        }

        private decimal balance;
        public decimal Balance
        {
            get { return this.balance; }
        }

        public VendingMachine() // construct a vending machine with a full stock of inventory
        {
            balance = 0.00M;
            VendingReader fullInventory = new VendingReader();
            string directory = Directory.GetCurrentDirectory();
            string filename = "vendingmachine.csv";
            string filePath = Path.Combine(directory, filename);

            Dictionary<string, List<VendingItem>> newStock = fullInventory.StockNewVendingMachine(filePath);
            inventory = newStock;
        }

        public void AddMoney(decimal cash) // adds cash to the balance
        {
            // Writer code goes here
            balance = balance + cash;
        }
        public string ReturnChange() // Return change sets the vending machine's balance field to 0, and returns a string
                                     // containing the coins they should receive back
        {
            Change c = new Change(balance);
            string coins = c.ToString();
            VendingWriter vr = new VendingWriter();
            // Writer code goes here
            balance = 0.00M;
            return coins;
        }
        public bool isInStock(string userSelection) // returns true if the user can buy the item, false otherwise.
                                                     // checks the inventory to see if the item with the key userselection is in stock, and if they have enough balance
        {

            if (inventory[userSelection].Count <= 0) // If the item is out of stock, they can't buy it
                return false;
            return true;

        }
        public void BuyItem(string userSelection)  // buys the item, reducing balance by the item's cost and 
        {                                      // reducing the relevant inventory item by one.  
            VendingItem product = inventory[userSelection][0];
            decimal productCost = product.Cost;

            if (balance >= productCost)
            {
                balance -= productCost;
                // Writer Code Goes Here
                inventory[userSelection].RemoveAt(0);
            }


        }



    }
}
