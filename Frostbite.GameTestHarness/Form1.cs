using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frostbite.Engine.Cards;
using Frostbite.Engine.Cards.Spell;
using Frostbite.Engine.Cards.Summon;
using Frostbite.Engine.Gameplay;
using Frostbite.Engine.Heroes;
using Frostbite.Engine.Units;

namespace Frostbite.GameTestHarness
{
    public partial class Form1 : Form
    {
        private Game _game;
        private int _currentPlayerId;
        private Player _player1;
        private Player _player2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _player1 = new Player(new List<Card>
            {
	            new DogCard(),
	            new AttackCard(),
	            new DogCard(),
	            new DogCard(),
	            new DogCard(),
	            new DogCard(),
	            new DogCard()
            }, new AverageJoe());
            _player2 = new Player(new List<Card>
            {
	            new DogCard(),
	            new DogCard(),
	            new DogCard(),
	            new AttackCard(),
	            new AttackCard(),
	            new AttackCard(),
	            new DogCard(),
	            new DogCard()
            }, new AverageJoe());

            player1IdLabel.Text = _player1.Id.ToString();
            player2IdLabel.Text = _player2.Id.ToString();
            
            _game = new Game(new List<Player>{_player1, _player2});
            _game.PlayerTurn += game_PlayerTurn;
            _game.HandChange += GameOnHandChange;
            _game.UnitChange += GameOnUnitChange;
            _game.ManaChange += GameOnManaChange;
            _game.Start();
        }

        private void GameOnManaChange(object sender, ManaChangeEventArgs manaChangeEventArgs)
        {
            Label label;
            if (manaChangeEventArgs.PlayerId == _player1.Id)
            {
                label = player1ManaLabel;
            }
            else
            {
                label = player2ManaLabel;
            }
            label.Text = manaChangeEventArgs.ManaLeft + " / " + manaChangeEventArgs.MaxMana;
        }

        private void GameOnUnitChange(object sender, UnitChangeEventArgs unitChangeEventArgs)
        {
            ListBox listBox;
            if (unitChangeEventArgs.PlayerId == _player1.Id)
            {
                listBox = Player1UnitsListBox;
            }
            else
            {
                listBox = Player2UnitsListBox;
            }
            listBox.DataSource = null;
            listBox.DataSource = unitChangeEventArgs.Units;
            listBox.SelectedIndex = -1;
        }

        private void GameOnHandChange(object sender, HandChangeEventArgs handChangeEventArgs)
        {
            if (handChangeEventArgs.PlayerId == _currentPlayerId)
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = handChangeEventArgs.Hand;
            }

            ListBox listBox;
            if (handChangeEventArgs.PlayerId == _player1.Id)
            {
                listBox = Player1HandListBox;
            }
            else
            {
                listBox = Player2HandListBox;
            }
            listBox.DataSource = null;
            listBox.DataSource = handChangeEventArgs.Hand;
        }

        void game_PlayerTurn(object sender, PlayerTurnEventArgs e)
        {
            _currentPlayerId = e.PlayerId;
            curentPlayerIdLabel.Text = _currentPlayerId.ToString();
            comboBox1.DataSource = e.Hand;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var card = (Card) comboBox1.SelectedItem;
            if (card != null)
            {
                var cardTargets = new List<CardTarget>();
                if (card.RequiresTarget)
                {
                    var selectedUnit = Player1UnitsListBox.SelectedItem as Unit;
                    if (selectedUnit != null)
                    {
                        cardTargets.Add(new CardTarget(_player1.Id, selectedUnit.Id));
                    }

                    selectedUnit = Player2UnitsListBox.SelectedItem as Unit;
                    if (selectedUnit != null)
                    {
                        cardTargets.Add(new CardTarget(_player2.Id, selectedUnit.Id));
                    }
                    
                }
                _game.PlayCard(_currentPlayerId, card.Id, cardTargets);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _game.EndTurn(_currentPlayerId);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
