using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frostbite.Engine.Units
{
    public abstract class Unit
    {


        public int Id { get; set; }
        public int HealthLeft { get; protected set; }
        public int Attack { get; protected set; }
        public abstract int BaseAttack { get; }
        public abstract int BaseHealth { get; }
    }
}
