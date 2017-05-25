using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Capstone.Classes;
using System.Collections.Generic;

namespace CapstoneTests
{
    [TestClass]
    public class VendingReaderTesting
    {

        [TestMethod]
        public void VendingReadering_ChipTesting()
        {
            VendingReader chipA = new VendingReader();
            string filePath = @"C:\Users\Kevin Ye\Documents\team3-c-module1-capstone\etc\vendingmachine.csv";
            Dictionary<string, List<VendingItem>> results = chipA.StockNewVendingMachine(filePath);

            string a1 = "A1";
            List<VendingItem> potatoCrispsRow = results[a1];

            //A1 is Potato Crisps, which cost $3.05.

            Assert.AreEqual("Crunch Crunch, Yum!", ((Chip)potatoCrispsRow[0]).MakeEatNoise());
            Assert.AreEqual(3.05M, ((Chip)potatoCrispsRow[0]).Cost);

            // Make sure it created 5 of all the items
            Assert.AreEqual(5, potatoCrispsRow.Count);
        }

        [TestMethod]
        public void VendingReader_CandyTesting()
        {
            VendingReader candyB = new VendingReader();
            string filePath = @"C:\Users\Kevin Ye\Documents\team3-c-module1-capstone\etc\vendingmachine.csv";
            Dictionary<string, List<VendingItem>> results = candyB.StockNewVendingMachine(filePath);


            string b1 = "B1";    
            List<VendingItem> moonpies = results[b1];

            // In the sample file, B1 corresponds to the candy Moonpie, which costs $1.80.
            // It should return Munch Munch Yum

            Assert.AreEqual("Munch Munch, Yum!", ((Candy)moonpies[0]).MakeEatNoise());
            Assert.AreEqual("Moonpie", ((Candy)moonpies[0]).Name);

            Assert.AreEqual(5, moonpies.Count);
        }

        [TestMethod]
        public void VendingReader_DrinkTesting()
        {
            VendingReader drinkC = new VendingReader();
            string filePath = @"C:\Users\Kevin Ye\Documents\team3-c-module1-capstone\etc\vendingmachine.csv";
            Dictionary<string, List<VendingItem>> results = drinkC.StockNewVendingMachine(filePath);


            string c3 = "C3";
            List<VendingItem> mountainMelters = results[c3];

            Assert.AreEqual("Glug Glug, Yum!", ((Drink)mountainMelters[0]).MakeEatNoise());
            Assert.AreEqual(1.50M, ((Drink)mountainMelters[0]).Cost);
            Assert.AreEqual(5, mountainMelters.Count);
        }

        [TestMethod]
        public void VendingReader_GumTesting()
        {
            VendingReader gumD = new VendingReader();
            string filePath = @"C:\Users\Kevin Ye\Documents\team3-c-module1-capstone\etc\vendingmachine.csv";
            Dictionary<string, List<VendingItem>> results = gumD.StockNewVendingMachine(filePath);

            string d1 = "D1";
            List<VendingItem> uChews = results[d1];

            Assert.AreEqual("Chew Chew, Yum!", ((Gum)uChews[0]).MakeEatNoise());
            Assert.AreEqual("U-Chews", ((Gum)uChews[0]).Name);
            Assert.AreEqual(0.85M, ((Gum)uChews[0]).Cost);
            Assert.AreEqual(5, uChews.Count);
        }

        [TestMethod]
        public void VendingReader_CreatedAll16Items()
        {
            VendingReader vr = new VendingReader();
            string filePath = @"C:\Users\Kevin Ye\Documents\team3-c-module1-capstone\etc\vendingmachine.csv";
            Dictionary<string, List<VendingItem>> results = vr.StockNewVendingMachine(filePath);

            Assert.AreEqual(true, results.ContainsKey("A1"));
            Assert.AreEqual(true, results.ContainsKey("A2"));
            Assert.AreEqual(true, results.ContainsKey("A3"));
            Assert.AreEqual(true, results.ContainsKey("A4"));
            Assert.AreEqual(true, results.ContainsKey("B1"));
            Assert.AreEqual(true, results.ContainsKey("B4"));
            Assert.AreEqual(true, results.ContainsKey("D4"));
            Assert.AreEqual(false, results.ContainsKey("A5"));

            Assert.AreEqual(16, results.Count);

        }
    }
}
