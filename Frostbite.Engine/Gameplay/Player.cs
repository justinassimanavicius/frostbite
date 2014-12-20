using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Frostbite.Engine.Cards.Summon;
using Frostbite.Engine.Exceptions;
using Frostbite.Engine.Units;

namespace Frostbite.Engine.Gameplay
{
    public class Player
    {
        public int Id
        {
            get { return GetHashCode(); }
        }

        private Stack<Card> Deck { get; set; }
        private List<Card> Hand { get; set; }
        private List<Card> Discards { get; set; }
        private List<Unit> Units { get; set; }
        public int ManaLeft { get; private set; }
        public int MaxMana { get; private set; }

        public Player(IEnumerable<Card> deck)
        {
            Deck = new Stack<Card>(deck);
            Hand = new List<Card>();
            Discards = new List<Card>();
            Units = new List<Unit>();

            MaxMana = 10;
            ManaLeft = 10;

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



        public void PlayCard(int cardId)
        {
            var cardToPlay = Hand.FirstOrDefault(x => x.Id == cardId);

            if(cardToPlay == null) throw new GameplayException("Card not found in player's hand");
            if(cardToPlay.ManaCost > ManaLeft) throw new GameplayException("Card requires more mana than player currently has");

            Hand.Remove(cardToPlay);

            ManaLeft -= cardToPlay.ManaCost;
            cardToPlay.Play(this);

            Discards.Add(cardToPlay);

            OnHandChange();
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }

        public List<Card> GetHand()
        {
            return Hand;

        }

        public List<Unit> GetUnits()
        {
            return Units;
        }

        public delegate void HandChangeEventHandler(object sender, EventArgs e);
        public event HandChangeEventHandler HandChange;

        protected virtual void OnHandChange()
        {
            if (HandChange != null)
            {
                HandChange(this, null);
            }
        }
    }
}
