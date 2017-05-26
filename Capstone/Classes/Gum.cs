using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum: VendingItem
    {

        public override string MakeEatNoise()
        {
            return "Chew Chew, Yum!";
        }

        public Gum(decimal cost, string productName): base(cost, productName)
        {

        }
    }
}
