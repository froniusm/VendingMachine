using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public abstract class VendingItem
    {
        public string Name { get; }
        public decimal Cost { get; } 

        public virtual string MakeEatNoise()
        {
            return "Food Noises Food Noises, Yum! (You should probably replace this) ";
        }
        
    }
}
