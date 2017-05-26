using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Drink :VendingItem
    {

        public override string MakeEatNoise()
        {
            return "Glug Glug, Yum!";
        }

        public Drink(decimal cost, string productName): base(cost, productName)
        {

        }
    }
}
