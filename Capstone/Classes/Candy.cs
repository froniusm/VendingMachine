using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : VendingItem
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
            return "Munch Munch, Yum!";
        }

        public Candy(decimal cost, string productName)
        {
            name = productName;
            this.cost = cost;
        }
    }
}
