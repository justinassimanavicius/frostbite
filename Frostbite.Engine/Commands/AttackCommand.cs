using Frostbite.Engine.Gameplay;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Commands
{
    class AttackCommand:Command
    {
        private readonly IAttackTarget _target;
        private readonly int _attackAmount;

        public AttackCommand(IAttackTarget target, int attackAmount)
        {
            _target = target;
            _attackAmount = attackAmount;
        }

        public override void Execute()
        {
            _target.ReactToAttack(new AttackRequest
            {
                AttackAmount = _attackAmount
            });
        }
    }
}
