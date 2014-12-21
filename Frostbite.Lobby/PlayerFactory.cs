using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Cards.Spell;
using Frostbite.Engine.Cards.Summon;
using Frostbite.Engine.Gameplay;
using Frostbite.Engine.Heroes;

namespace Frostbite.Lobby
{
    class PlayerFactory
    {
        public Player CreatePlayer(int playerId)
        {
            return new Player(new List<Card>
            {
                new DogCard(),
                new AttackCard(),
                new DogCard(),
                new DogCard(),
                new DogCard(),
                new DogCard(),
                new DogCard()
            }, new AverageJoe());
        }
    }
}
