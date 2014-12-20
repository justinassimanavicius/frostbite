using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Exceptions;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Gameplay
{
    public class Game
    {
        private readonly List<Player> _players;

        public delegate void PlayerTurnEventHandler(object sender, PlayerTurnEventArgs e);

        private int _currentPlayerIndex;

        public Game(IEnumerable<Player> players)
        {
            _players = players.ToList();
        }

        public void Start()
        {
            _players[0].DrawCards(2);
            _players[1].DrawCards(2);
            _currentPlayerIndex = new Random().Next(2);
            OnPlayerTurn();
        }

        public void PlayCard(int playerId, int cardId)
        {
            var currentPlayer = GetCurrentPlayer();

            if(currentPlayer.Id != playerId) throw new GameplayException("Not this player's turn");

            currentPlayer.PlayCard(cardId);
        }

        public void EndTurn(int playerId)
        {
            var currentPlayer = GetCurrentPlayer();

            if (currentPlayer.Id != playerId) throw new GameplayException("Not this player's turn");

            _currentPlayerIndex = (_currentPlayerIndex + 1)%2;

            OnPlayerTurn();
        }

        private Player GetCurrentPlayer()
        {
            return _players[_currentPlayerIndex];
        }

        public event PlayerTurnEventHandler PlayerTurn;

        protected virtual void OnPlayerTurn()
        {
            if (PlayerTurn != null)
            {
                Player currentPlayer = GetCurrentPlayer();
                var e = new PlayerTurnEventArgs
                {
                    PlayerId = currentPlayer.Id,
                    Hand = currentPlayer.GetHand(),
                    Units = currentPlayer.GetUnits()
                };
                PlayerTurn(this, e);
            }
        }


    }

    public class PlayerTurnEventArgs:EventArgs
    {
        public int PlayerId { get; set; }
        public List<Card> Hand { get; set; }
        public List<Unit> Units { get; set; }
    }
}
