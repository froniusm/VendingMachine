using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingItem
    {
        private string name;
        public string Name { get { return name; } }

        private decimal cost;
        public decimal Cost { get {return cost; } }

        public abstract string MakeEatNoise();
        
        public VendingItem(decimal cost, string productName)
        {
            this.name = productName;
            this.cost = cost;
        }
    }
}
