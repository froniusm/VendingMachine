using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;

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

        public VendingMachine()
        {
            balance = 0.00M;
            VendingReader fullInventory = new VendingReader();
            string filePath = @"C:\Users\Kevin Ye\Documents\team3-c-module1-capstone\etc\vendingmachine.csv";

            Dictionary<string, List<VendingItem>> newStock = fullInventory.StockNewVendingMachine(filePath);
            inventory = newStock;
        }
        public void AddMoney(decimal cash)
        {
            // Writer code goes here
            balance = balance + cash;
        }
        public string ReturnChange()
        {
            Change c = new Change(balance);
            string coins = c.ToString();
            //Writer Code goes here
            balance = 0.00M;
            return coins;
        }
        public bool canBuyItem(string userSelection)
        {
            if (!inventory.ContainsKey(userSelection))
                throw new Exception("That is not a valid product selection.  Please make sure the user can't enter invalid products.");
            if (inventory[userSelection].Count == 0) // If the item is out of stock, they can't buy it
                return false;

            List<VendingItem> productList = inventory[userSelection];
            VendingItem product = productList[0];
            decimal cost = 100000;
            if (product is Chip)
            {
                Chip temp = (Chip)product;
                cost = temp.Cost;
            }
            else if (product is Candy)
            {
                Candy temp = (Candy)product;
                cost = temp.Cost;
            }
            else if (product is Drink)
            {
                Drink temp = (Drink)product;
                cost = temp.Cost;
            }
            else // (Product is Gum)
            {
                Gum temp = (Gum)product;
                cost = temp.Cost;
            }

            if (balance < cost) // If they can't afford the item in question, they can't buy it
                return false;

            return true;
        }
        public void buyItem(string userSelection)
        {
            VendingItem product = inventory[userSelection][0];
            decimal productCost = 100000;

            if (product is Chip)
            {
                Chip temp = (Chip)product;
                productCost = temp.Cost;
            }
            else if (product is Candy)
            {
                Candy temp = (Candy)product;
                productCost = temp.Cost;
            }
            else if (product is Drink)
            {
                Drink temp = (Drink)product;
                productCost = temp.Cost;
            }
            else // (Product is Gum)
            {
                Gum temp = (Gum)product;
                productCost = temp.Cost;
            }

            balance -= productCost;
            // Writer Code Goes Here
            inventory[userSelection].RemoveAt(0);
        }



    }
}
