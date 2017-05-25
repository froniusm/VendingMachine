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

    }
}
