using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Gameplay;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Heroes
{
    public abstract class Hero : Unit
    {
        protected Hero(int baseHealth) : base(baseHealth, 0)
        {
        }
    }
}
