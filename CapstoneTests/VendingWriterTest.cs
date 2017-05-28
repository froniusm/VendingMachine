using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone.Classes;
using System.IO;

namespace CapstoneTests
{
    [TestClass]
    public class VendingWriterTest
    {
        [TestMethod]
        public void VendingWriter_RecordsChange()
        {
            string directory = Directory.GetCurrentDirectory();
            string writeToHere = "vendingmachine.csv";
            string correctStrings = "";

            VendingReader vr = new VendingReader();
            VendingWriter vw = new VendingWriter();
        }
    }
}
