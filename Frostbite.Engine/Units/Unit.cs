using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Gameplay;

namespace Frostbite.Engine.Units
{
    public abstract class Unit : IAttackTarget, ITarget
    {


        public int Id
        {
            get { return GetHashCode(); }
        }

        public int HealthLeft { get; protected set; }
        public int AttackPoints { get; protected set; }
        public int BaseAttackPoints { get; private set; }

        public int BaseHealth { get; private set; }

        protected Unit(int baseHealth, int baseAtackPoints)
        {
            BaseHealth = baseHealth;
            HealthLeft = baseHealth;

            BaseAttackPoints = baseAtackPoints;
            AttackPoints = baseAtackPoints;
        }

        public virtual AttackResult ReactToAttack(AttackRequest attackRequest)
        {
            HealthLeft -= attackRequest.AttackAmount;

            return new AttackResult
            {
                DamageDealt = attackRequest.AttackAmount
            };
        }

        public override string ToString()
        {
            return String.Format("{0} | A: {1} | H: {2} / {3}", GetType().Name, AttackPoints, HealthLeft, BaseHealth);
        }
    }
}
