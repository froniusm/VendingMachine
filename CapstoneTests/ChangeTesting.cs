using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;

namespace CapstoneTests
{
    [TestClass]
    public class ChangeTesting
    {
        [TestMethod]
        public void ChangeTesting_ReturnNoChange()
        {
            Change noChange = new Change(0.00M);
            Change oneCent = new Change(0.01M);

            Assert.AreEqual(0, noChange.Quarters);
            Assert.AreEqual(0, noChange.Dimes);
            Assert.AreEqual(0, noChange.Nickels);

            Assert.AreEqual(0, oneCent.Quarters);
            Assert.AreEqual(0, oneCent.Dimes);
            Assert.AreEqual(0, oneCent.Nickels);

        }

        [TestMethod]
        public void ChangeTesting_ReturnsCorrectChange()
        {
            Change fiveCents = new Change(0.05M);
            Change twentyCents = new Change(0.20m);
            Change oneDollar = new Change(1.00m);
            Change twoDollarsfiveCents = new Change(2.05M);
            Change fiveDollars = new Change(5.00m);

            Assert.AreEqual("0 Quarters, 0 Dimes, 1 Nickels.", fiveCents.ToString());
            Assert.AreEqual("0 Quarters, 2 Dimes, 0 Nickels.", twentyCents.ToString());
            Assert.AreEqual("4 Quarters, 0 Dimes, 0 Nickels.", oneDollar.ToString());
            Assert.AreEqual("8 Quarters, 0 Dimes, 1 Nickels.", twoDollarsfiveCents.ToString());
            Assert.AreEqual("20 Quarters, 0 Dimes, 0 Nickels.", fiveDollars.ToString());
        }

        [TestMethod]
        public void WriterTesting_RecordsAddingCash()
        {
            VendingReader vr = new VendingReader();
            
        }
    }
}
