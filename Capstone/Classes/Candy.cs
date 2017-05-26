using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Candy : VendingItem
    {

        public override string MakeEatNoise()
        {
            return "Munch Munch, Yum!";
        }

        public Candy(decimal cost, string productName): base(cost, productName)
        {

        }
    }
}
