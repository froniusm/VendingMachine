using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chip : VendingItem
    {
        private string name;
        public new string Name
        {
            get { return name; }
        }

        private decimal cost;
        public new decimal Cost
        {
            get { return cost; }
        }

        public override string MakeEatNoise()
        {
            return "Crunch Crunch, Yum!";
        }

        public Chip(decimal cost, string productName)
        {
            name = productName;
            this.cost = cost;
        }

    }
}
