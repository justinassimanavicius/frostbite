using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Cards.Summon;
using Frostbite.Engine.Exceptions;
using Frostbite.Engine.Heroes;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Gameplay
{
    public class Player
    {
	    private readonly IGameClient _client;
	    private readonly Hero _hero;

        public int Id
        {
            get { return GetHashCode(); }
        }

        private Stack<Card> Deck { get; set; }
        private List<Card> Hand { get; set; }
        private List<Card> Discards { get; set; }
        private List<Unit> Units { get; set; }

	    public IGameClient Client
	    {
		    get { return _client; }
	    }

	    private int _manaLeft;
        private int _maxMana;

        public Player(IGameClient client, IEnumerable<Card> deck, Hero hero)
        {
	        _client = client;
	        _hero = hero;
            Deck = new Stack<Card>(deck);
            Hand = new List<Card>();
            Discards = new List<Card>();
            Units = new List<Unit>();
        }

        public void ReplenishMana()
        {
            if (_manaLeft != _maxMana)
            {
                _manaLeft = _maxMana;
                OnManaChange();
            }

        }

        public void AddMana(int manaToAdd)
        {
            if (manaToAdd != 0)
            {
                var newMana =_manaLeft + manaToAdd;
                if (newMana > _maxMana)
                {
                    newMana = _maxMana;
                }
                else if(newMana < 0)
                {
                    newMana = 0;
                }

                _manaLeft = newMana;

                OnManaChange();
            }
        }

        public void SetMaxMana(int maxMana)
        {
            if (maxMana != _maxMana)
            {
                _maxMana = maxMana;
                OnManaChange();
            }
        }

        public int GetMaxMana()
        {
            return _maxMana;
        }

        public int GetManaLeft()
        {
            return _manaLeft;
        }


        public List<Card> DrawCards(int count)
        {
            var drawnCards = new List<Card>();
            for (int i = 0; i < count; i++)
            {
                if (!Deck.Any())
                {
                    throw new GameplayException("No more cards in deck");
                }
                var drawnCard = Deck.Pop();
                drawnCards.Add(drawnCard);
                Hand.Add(drawnCard);
            }
            OnHandChange();
            return drawnCards;
        }



        public void PlayCard(int cardId, IList<ITarget> targets)
        {
            var cardToPlay = Hand.FirstOrDefault(x => x.Id == cardId);

            if(cardToPlay == null) throw new GameplayException("Card not found in player's hand");

            if(cardToPlay.ManaCost > _manaLeft) throw new GameplayException("Card requires more mana than player currently has");

            Hand.Remove(cardToPlay);

            AddMana(-cardToPlay.ManaCost);

            cardToPlay.Play(this, targets);

            Discards.Add(cardToPlay);

            OnHandChange();
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
            OnUnitChange();
        }

        public List<Card> GetHand()
        {
            return Hand;

        }

        public List<Unit> GetUnits()
        {
            return Units;
        }

        #region events

        public delegate void HandChangeEventHandler(object sender, EventArgs e);
        public event HandChangeEventHandler HandChange;

        protected virtual void OnHandChange()
        {
            if (HandChange != null)
            {
                HandChange(this, null);
            }
        }

        public delegate void UnitChangeEventHandler(object sender, EventArgs e);
        public event UnitChangeEventHandler UnitChange;

        protected virtual void OnUnitChange()
        {
            if (UnitChange != null)
            {
                UnitChange(this, null);
            }
        }

        public delegate void ManaChangeEventHandler(object sender, EventArgs e);
        public event ManaChangeEventHandler ManaChange;

        protected virtual void OnManaChange()
        {
            if (ManaChange != null)
            {
                ManaChange(this, null);
            }
        }

        #endregion

        public Hero GetHero()
        {
            return _hero;
        }
    }

    public interface ITarget
    {
    }

    public interface IAttackTarget
    {
        AttackResult ReactToAttack(AttackRequest attackRequest);
    }

    public class AttackRequest
    {
        public int AttackAmount { get; set; }
    }

    public class AttackResult
    {
        public int DamageDealt { get; set; }
    }
}
