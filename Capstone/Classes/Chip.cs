using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chip : VendingItem
    {

        public override string MakeEatNoise()
        {
            return "Crunch Crunch, Yum!";
        }

        public Chip(decimal cost, string productName): base(cost, productName)
        {

        }


    }
}
