using System.Collections.Generic;
using System.Linq;
using Frostbite.Engine.Commands;
using Frostbite.Engine.Exceptions;
using Frostbite.Engine.Gameplay;

namespace Frostbite.Engine.Cards.Spell
{
    public class AttackCard:Card
    {

        
        public override int ManaCost
        {
            get { return 1; }
        }

        public override bool RequiresTarget
        {
            get { return true; }
        }

        public override void Play(Player player, IList<ITarget> targets)
        {
            if (targets == null || !targets.Any()) throw new GameplayException("This card requires target");

            var target = targets.First() as IAttackTarget;

            new AttackCommand(target, 1).Execute();
        }

        public override string ToString()
        {
            return "Attack card " + Id;
        }
    }
}
