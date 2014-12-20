using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Commands;
using Frostbite.Engine.Gameplay;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Cards.Summon
{
    public class DogCard:Card
    {

        public DogCard()
        {
            Id = new Random().Next();
        }
        public override int ManaCost
        {
            get { return 1; }
        }

        public override void Play(Player player)
        {
            new SummonCommand(new Dog(), player).Execute();
        }

        public override string ToString()
        {
            return "Dog card " + Id;
        }
    }
}
