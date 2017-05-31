using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingReader
    {
        static char[] delimiters = new char[] { '|' }; // list of delimiters
        const int SlotID = 0;
        const int ProductName = 1;
        const int Cost = 2;

        public Dictionary<string, List<VendingItem>> StockNewVendingMachine(string filePath)
        {
            Dictionary<string, List<VendingItem>> initialStock = new Dictionary<string, List<VendingItem>>();

            if (!File.Exists(filePath))
            {
                throw new Exception("File path isn't valid.");
            }
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] vendItemProperties = line.Split(delimiters);
                        if (vendItemProperties.Length != 3)
                        {
                            throw new Exception("A vending item is not formatted correctly: " + line);
                        }
                        // This assumes all input files will be coming in with the format(Location|Product_Name|Price)
                        string productLocation = vendItemProperties[SlotID];
                        string productName = vendItemProperties[ProductName];
                        bool validCost = decimal.TryParse(vendItemProperties[Cost], out decimal productCost);
                        if (!validCost)
                        {
                            throw new Exception("The file had an invalid cost: " + line);
                        }

                        switch (productLocation[0])
                        {
                            case 'A': // chips
                                Chip ch = new Chip(productCost, productName);
                                List<VendingItem> fiveOfChipCH = new List<VendingItem> { ch, ch, ch, ch, ch };
                                initialStock[productLocation] = fiveOfChipCH;
                                break;
                            case 'B': //candy
                                Candy ca = new Candy(productCost, productName);
                                List<VendingItem> fiveOfCandyCA = new List<VendingItem> { ca, ca, ca, ca, ca };
                                initialStock[productLocation] = fiveOfCandyCA;
                                break;
                            case 'C': // drinks
                                Drink dr = new Drink(productCost, productName);
                                List<VendingItem> fiveOfDrinkDR = new List<VendingItem> { dr, dr, dr, dr, dr };
                                initialStock[productLocation] = fiveOfDrinkDR;
                                break;

                            case 'D': // gum
                                Gum g = new Gum(productCost, productName);
                                List<VendingItem> fiveOfGumG = new List<VendingItem> { g, g, g, g, g };
                                initialStock[productLocation] = fiveOfGumG;
                                break;
                            default:
                                break;
                        }


                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("StreamReader encountered a problem: " + e.Message);
            }

            return initialStock;
        }
    }
}
