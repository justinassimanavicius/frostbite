using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Gameplay;

namespace Frostbite.Lobby
{
    class GameFactory
    {
        public Game CreateGame(Player player1, Player player2)
        {
            var game = new Game(new List<Player> {player1, player2});

            return game;
        }
    }
}
