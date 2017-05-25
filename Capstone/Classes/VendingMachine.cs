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
            balance = 0.0M;
            VendingReader fullInventory = new VendingReader();
            string filePath = @"C:\Users\Molly Fronius\team3-c-module1-capstone\etc\vendingmachine.csv";

            Dictionary<string, List<VendingItem>> newStock =  fullInventory.StockNewVendingMachine(filePath);
            inventory = newStock;
        }

        public void AddMoney(decimal cash)
        {
            balance = balance + cash;
        }

        public string ReturnChange()
        {
            Change c = new Change(balance);
            string coins = c.ToString();
            return coins;
        }
      
    }
}
