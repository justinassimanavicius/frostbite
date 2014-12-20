using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Commands;

namespace Frostbite.Engine.Gameplay
{
    public abstract class Card
    {
        public abstract int ManaCost { get;}
        public int Id { get; set; }

        public abstract void Play(Player player);
    }
}
