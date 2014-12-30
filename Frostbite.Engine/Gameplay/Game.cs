using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Exceptions;
using Frostbite.Engine.Gameplay;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Gameplay
{
    public class Game
    {
        private readonly List<Player> _players;

		public List<Player> Players { get { return _players; } }

        public delegate void PlayerTurnEventHandler(object sender, PlayerTurnEventArgs e);

        public delegate void HandChangeEventHandler(object sender, HandChangeEventArgs e);

        public delegate void UnitChangeEventHandler(object sender, UnitChangeEventArgs e);

        public delegate void ManaChangeEventHandler(object sender, ManaChangeEventArgs e);

        private int _currentPlayerIndex;
        private int _turn;

        public Game(IEnumerable<Player> players)
        {
            _players = players.ToList();
            foreach (var player in _players)
            {
                player.HandChange += PlayerOnHandChange;
                player.UnitChange += PlayerOnUnitChange;
                player.ManaChange += PlayerOnManaChange;
            }
        }

        private void PlayerOnManaChange(object sender, EventArgs eventArgs)
        {
            var player = (Player)sender;
            OnManaChange(player);
        }

        private void PlayerOnUnitChange(object sender, EventArgs eventArgs)
        {
            var player = (Player) sender;
            OnUnitChange(player);
        }

        private void PlayerOnHandChange(object sender, EventArgs eventArgs)
        {
            var player = (Player) sender;
            OnHandChange(player);
        }

        public void Start()
        {
            _turn = 0;
            _players[0].DrawCards(2);
            _players[1].DrawCards(2);
            _currentPlayerIndex = new Random().Next(2);

            StartCurrentPlayersTurn();
        }

        public void PlayCard(int playerId, int cardId, IEnumerable<CardTarget> cardTargets)
        {
            var currentPlayer = GetCurrentPlayer();

            if (currentPlayer.Id != playerId) throw new GameplayException("Not this player's turn");

            var targets = GetTargets(cardTargets);

            currentPlayer.PlayCard(cardId, targets.ToArray());
        }

        private IEnumerable<ITarget> GetTargets(IEnumerable<CardTarget> cardTargets)
        {
            if (cardTargets == null) return Enumerable.Empty<ITarget>();
            return cardTargets.Select(x => x.GetTarget(_players));
        }

        private Player GetOpponent()
        {
            return _players[(_currentPlayerIndex + 1)%2];
        }

        public void EndTurn(int playerId)
        {
            var currentPlayer = GetCurrentPlayer();

            if (currentPlayer.Id != playerId) throw new GameplayException("Not this player's turn");

            _currentPlayerIndex = (_currentPlayerIndex + 1)%2;

            

            StartCurrentPlayersTurn();
        }

        private void StartCurrentPlayersTurn()
        {
            _turn++;
            OnPlayerTurn();

            Player currentPlayer = GetCurrentPlayer();
            currentPlayer.DrawCards(1);
            currentPlayer.SetMaxMana(GetMaxManaForThisTurn());
            currentPlayer.ReplenishMana();
        }

        private int GetMaxManaForThisTurn()
        {
            return ((_turn -1) / 2)+1;
        }

        private Player GetCurrentPlayer()
        {
            return _players[_currentPlayerIndex];
        }


        #region events 
        public event PlayerTurnEventHandler PlayerTurn;


        protected virtual void OnPlayerTurn()
        {
            if (PlayerTurn != null)
            {
                var currentPlayer = GetCurrentPlayer();
                var e = new PlayerTurnEventArgs
                {
                    PlayerId = currentPlayer.Id,
                    Hand = currentPlayer.GetHand(),
                    Units = currentPlayer.GetUnits()
                };
                PlayerTurn(this, e);
            }
        }

        public event HandChangeEventHandler HandChange;

        protected virtual void OnHandChange(Player player)
        {
            if (HandChange != null)
            {
                var e = new HandChangeEventArgs
                {
                    PlayerId = player.Id,
                    Hand = player.GetHand(),
                };
                HandChange(this, e);
            }
        }

        public event UnitChangeEventHandler UnitChange;

        protected virtual void OnUnitChange(Player player)
        {
            if (UnitChange != null)
            {
                var e = new UnitChangeEventArgs
                {
                    PlayerId = player.Id,
                    Units = player.GetUnits(),
                };
                UnitChange(this, e);
            }
        }

        public event ManaChangeEventHandler ManaChange;

        protected virtual void OnManaChange(Player player)
        {
            if (ManaChange != null)
            {
                var e = new ManaChangeEventArgs
                {
                    PlayerId = player.Id,
                    ManaLeft = player.GetManaLeft(),
                    MaxMana = player.GetMaxMana(),
                };
                ManaChange(this, e);
            }
        }

        #endregion
    }

    public class CardTarget
    {
        private readonly int _playerId;
        private readonly int _targetId;

        public CardTarget(int playerId, int targetId)
        {
            _playerId = playerId;
            _targetId = targetId;
        }

        public ITarget GetTarget(IEnumerable<Player> players)
        {
            var player = players.First(x => x.Id == _playerId);
            var hero = player.GetHero();
            if (hero.Id == _targetId)
            {
                return hero;
            }
            var unit = player.GetUnits().FirstOrDefault(x => x.Id == _targetId);

            if(unit == null) throw new GameplayException("Nonexisting element (unit, hero etc.) was targeted during players action");

            return unit;
        }
    }

    public class UnitChangeEventArgs : EventArgs
    {
        public int PlayerId { get; set; }
        public List<Unit> Units { get; set; }
    }

    public class PlayerTurnEventArgs : EventArgs
    {
        public int PlayerId { get; set; }
        public List<Card> Hand { get; set; }
        public List<Unit> Units { get; set; }
    }

    public class HandChangeEventArgs : EventArgs
    {
        public int PlayerId { get; set; }
        public List<Card> Hand { get; set; }
    }

    public class ManaChangeEventArgs : EventArgs
    {
        public int PlayerId { get; set; }
        public int MaxMana { get; set; }
        public int ManaLeft { get; set; }
    }
}
