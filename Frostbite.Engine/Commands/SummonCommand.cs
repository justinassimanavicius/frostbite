using Frostbite.Engine.Gameplay;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Commands
{
    class SummonCommand:Command
    {
        private readonly Unit _unit;
        private readonly Player _player;

        public SummonCommand(Unit unit, Player player)
        {
            _unit = unit;
            _player = player;
        }

        public override void Execute()
        {
            _player.AddUnit(_unit);
        }
    }
}
