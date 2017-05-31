using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendingMachineTest
    {
        [TestMethod]
        public void VendingMachineTest_Returns()
        {
            VendingMachine classToTest = new VendingMachine();
            classToTest.AddMoney(1.00M);
            Assert.AreEqual(1.00M, classToTest.Balance);
        }

        [TestMethod]
        public void VendingMachineTest_AddAndReturnChange()
        {
            VendingMachine giveMeCash = new VendingMachine();
            giveMeCash.AddMoney(5.00M);

            VendingMachine giveMeADime = new VendingMachine();
            giveMeADime.AddMoney(0.10M);

            Assert.AreEqual("20 Quarters, 0 Dimes, 0 Nickels.", giveMeCash.ReturnChange());
            Assert.AreEqual("0 Quarters, 1 Dimes, 0 Nickels.", giveMeADime.ReturnChange());
            
        }

        [TestMethod]
        public void VendingMachineTest_DoesNotGiveChangeTwice()
            // This test ensures that the balance is reset to 0 whenever ReturnChange() is called.
            // Otherwise, the console could give the machine $1, then call ReturnChange() twice and get $2 (2* $1) back
        {
            VendingMachine giveMeChangeTwice = new VendingMachine();
            giveMeChangeTwice.AddMoney(1.00M);

            Assert.AreEqual("4 Quarters, 0 Dimes, 0 Nickels.", giveMeChangeTwice.ReturnChange());
            Assert.AreEqual("0 Quarters, 0 Dimes, 0 Nickels.", giveMeChangeTwice.ReturnChange());
            Assert.AreEqual("0 Quarters, 0 Dimes, 0 Nickels.", giveMeChangeTwice.ReturnChange());
        }

        [TestMethod]
        public void VendingMachine_CantBuyOutOfStockItems()
        {
            VendingMachine wantsToBuyOneCrisp = new VendingMachine(); // Potato Crisps = A1
            wantsToBuyOneCrisp.AddMoney(10000.00M);
            string a1 = "A1";

            VendingMachine buyAllTheCrisps = new VendingMachine(); // This vendingmachine will sell 5 crisps, then run out
            buyAllTheCrisps.AddMoney(10000m);
            for (int i = 0; i < 5; i++)
            {
                buyAllTheCrisps.BuyItem(a1);
            }

            Assert.AreEqual(true, wantsToBuyOneCrisp.IsInStock(a1));
            Assert.AreEqual(false, buyAllTheCrisps.IsInStock(a1));
        }

        [TestMethod]
        public void VendingMachine_CantBuyItemsWithoutEnoughCash()
        {
            string a1 = "A1";

            VendingMachine giveFreeStuffPls = new VendingMachine();
            giveFreeStuffPls.BuyItem(a1);

            VendingMachine notQuiteEnoughCash = new VendingMachine();
            notQuiteEnoughCash.AddMoney(0.7M);
            notQuiteEnoughCash.BuyItem(a1);

            VendingMachine onlyEnoughForGum = new VendingMachine();
            onlyEnoughForGum.AddMoney(1.00m);
            onlyEnoughForGum.BuyItem(a1);
            onlyEnoughForGum.BuyItem("D1");

            VendingMachine canBuyOneButNotTwo = new VendingMachine();
            canBuyOneButNotTwo.AddMoney(1.00m);
            canBuyOneButNotTwo.BuyItem("D1");
            canBuyOneButNotTwo.BuyItem("D1");

            Assert.AreEqual(5, (giveFreeStuffPls.Inventory)[a1].Count);
            Assert.AreEqual(5, (notQuiteEnoughCash.Inventory)[a1].Count);
            Assert.AreEqual(5, (onlyEnoughForGum.Inventory)[a1].Count);
            Assert.AreEqual(4, (onlyEnoughForGum.Inventory)["D1"].Count);
            Assert.AreEqual(4, (canBuyOneButNotTwo.Inventory)["D1"].Count);
        }
    }
}
