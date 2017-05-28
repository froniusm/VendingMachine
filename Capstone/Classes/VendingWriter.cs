using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.Classes;
using System.IO;

namespace Capstone.Classes
{
    public class VendingWriter
    {
        public void WritingAFile(string thisIsWhatTheVendingMachineDid)
        {
            string directory = Environment.CurrentDirectory;
            string filename = "log.txt";
            string fullPath = Path.Combine(directory, filename);

            try
            {
                using (StreamWriter sw = new StreamWriter(filename, true))
                {
                    sw.WriteLine(DateTime.UtcNow + thisIsWhatTheVendingMachineDid);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error occured writing file" + e.Message);
            }
        }
    }
}
