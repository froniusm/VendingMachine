using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Change
    {
        private int quarters;
        public int Quarters
        {
            get { return quarters; }
        }

        private int dimes;
        public int Dimes
        {
            get { return dimes; }
        }

        private int nickels;
        public int Nickels
        {
            get { return nickels; }
        }

        public decimal totalChange
        {
            get { return ((quarters * 0.25M) + (dimes * 0.1M) + (nickels * 0.05M)); }
        }

        public Change(decimal inputChange)
        {
            quarters = (int)(inputChange / 0.25M);
            inputChange = inputChange % 0.25M;

            dimes = (int)(inputChange / 0.1M);
            inputChange = inputChange % 0.1M;

            nickels = (int)(inputChange / 0.05M);
        }

        public override string ToString()
        {
            return (quarters + " Quarters, " + dimes + " Dimes, " + nickels + " Nickels.");
        }

    }
}
