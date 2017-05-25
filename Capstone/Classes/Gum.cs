using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum: VendingItem
    {
        private string name;
        public string Name
        {
            get { return name; }
        }

        private decimal cost;
        public decimal Cost
        {
            get { return cost; }
        }

        public override string MakeEatNoise()
        {
            return "Chew Chew, Yum!";
        }

        public Gum(decimal cost, string productName)
        {
            name = productName;
            this.cost = cost;
        }
    }
}
