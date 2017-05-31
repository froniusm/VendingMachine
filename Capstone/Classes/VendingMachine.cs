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

        public string[] Slots
        {
            get { return inventory.Keys.ToArray(); }
        }

        public VendingMachine() // construct a vending machine with a full stock of inventory
        {
            balance = 0.00M;
            VendingReader fullInventory = new VendingReader();
            string directory = Directory.GetCurrentDirectory();
            string filename = "vendingmachine.csv";
            string filePath = Path.Combine(directory, filename);

            inventory = fullInventory.StockNewVendingMachine(filePath);
        }

        public VendingItem GetItemAtSlot(string slotID)
        {
            List<VendingItem> items = inventory[slotID];
            if(items.Count > 0)
            {
                return items[0];
            }
            else
            {
                return null;
            }
        }

        public bool IsValidSlot(string slotID)
        {
            return inventory.ContainsKey(slotID);
        }

        public void AddMoney(decimal cash) // adds cash to the balance
        {
            VendingWriter logWriter = new VendingWriter();
            string transactionString = " FEED MONEY:  $";
            transactionString += cash;

            balance = balance + cash;

            transactionString = transactionString + " $" + balance;
            logWriter.WritingAFile(transactionString);
        }
        public string ReturnChange() // Return change sets the vending machine's balance field to 0, and returns a string
                                     // containing the coins they should receive back
        {
            VendingWriter vr = new VendingWriter();
            string recordTransaction = ("GIVE CHANGE: $" +balance.ToString());

            Change coins = new Change(balance);
            balance = 0.00M;

            recordTransaction += " $0.00";
            vr.WritingAFile(recordTransaction);

            return coins.ToString();
        }
        public bool IsInStock(string userSelection) // returns true if the user can buy the item, false otherwise.
                                                     // checks the inventory to see if the item with the key userselection is in stock, and if they have enough balance
        {
            return inventory[userSelection].Count <= 0;
        }
        public VendingItem BuyItem(string userSelection)  // buys the item, reducing balance by the item's cost and 
        {                                      // reducing the relevant inventory item by one.  
            VendingItem product = inventory[userSelection][0];
            decimal productCost = product.Cost;

            if (balance >= productCost)
            {
                VendingWriter vr = new VendingWriter(); // writing to/formatting log
                string recordTransaction = (inventory[userSelection][0].Name + " "); 
                recordTransaction += userSelection + "  $" + balance + " ";
                balance -= productCost;  
                recordTransaction += "$" + balance; // more writing to the log
                vr.WritingAFile(recordTransaction);

                
                inventory[userSelection].RemoveAt(0);
                return product;                
            }
            return null;
        }
    }
}
