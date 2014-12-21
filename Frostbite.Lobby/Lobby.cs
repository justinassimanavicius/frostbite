using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Gameplay;

namespace Frostbite.Lobby
{
    public class Lobby
    {

        private readonly List<Player> _waitingPlayers = new List<Player>();
        private readonly object _waitingPlayersLock = new object();

        private readonly List<Game> _games = new List<Game>();
        private readonly object _gamesLock = new object();

        private readonly GameFactory _gameFactory = new GameFactory();
        private readonly PlayerFactory _playerFactory = new PlayerFactory();

        public void AddWaitingPlayer(int playerId)
        {
            var newPlayer = CreateNewPlayer(playerId);

            var opponent = GetOpponent(newPlayer);

            if (opponent != null)
            {
                StartNewGame(newPlayer, opponent);
            }
        }

        private Player GetOpponent(Player newPlayer)
        {
            lock (_waitingPlayersLock)
            {
                if (_waitingPlayers.Any())
                {
                    var opponent = _waitingPlayers[0];
                    _waitingPlayers.RemoveAt(0);
                    return opponent;
                }
                _waitingPlayers.Add(newPlayer);
            }
            return null;
        }

        private void StartNewGame(Player newPlayer, Player opponent)
        {
            var game = _gameFactory.CreateGame(newPlayer, opponent);
            lock (_gamesLock)
            {
                _games.Add(game);
            }
        }

        private Player CreateNewPlayer(int playerId)
        {
            return _playerFactory.CreatePlayer(playerId);
        }
    }
}
