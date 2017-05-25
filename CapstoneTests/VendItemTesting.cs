using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class VendItemTesting
    {
        [TestMethod]
        public void VendItem_TestChips()
        {
            Chip fiftyCents = new Chip(0.50M, "Chip");

            Assert.AreEqual("Crunch Crunch, Yum!", fiftyCents.MakeEatNoise());
            Assert.AreEqual(0.50M, fiftyCents.Cost);
        }

        [TestMethod]
        public void VendItem_TestCandy()
        {
            Candy sugarFree = new Candy(2.00M, "sugarFree");

            Assert.AreEqual("Munch Munch, Yum!", sugarFree.MakeEatNoise());
            Assert.AreEqual(2.00M, sugarFree.Cost);
        }

        [TestMethod]
        public void VendItem_TestDrink()
        {
            Drink example = new Drink(199.50M, "Thrist");

            Assert.AreEqual("Glug Glug, Yum!", example.MakeEatNoise());
            Assert.AreEqual(199.50M, example.Cost);
        }

        [TestMethod]
        public void VendItem_TestGum()
        {
            Gum overpriced = new Gum(5.50m, "Gum");

            Assert.AreEqual("Chew Chew, Yum!", overpriced.MakeEatNoise());
            Assert.AreEqual(5.50m, overpriced.Cost);
        }
    }
}
