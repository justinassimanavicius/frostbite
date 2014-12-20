using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Frostbite.Engine.Cards.Summon;
using Frostbite.Engine.Gameplay;

namespace Frostbite.GameTestHarness
{
    public partial class Form1 : Form
    {
        private Game _game;
        private int _currentPlayerId;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var player1 = new Player(new List<Card>
            {
                new DogCard(),
                new DogCard(),
                new DogCard(),
                new DogCard(),
                new DogCard()
            });
            var player2 = new Player(new List<Card>
            {
                new DogCard(),
                new DogCard(),
                new DogCard(),
                new DogCard(),
                new DogCard()
            });
            _game = new Game(new List<Player>{player1, player2});
            _game.PlayerTurn += game_PlayerTurn;
            _game.HandChange += GameOnHandChange;
            _game.Start();
        }

        private void GameOnHandChange(object sender, HandChangeEventArgs handChangeEventArgs)
        {
            if (handChangeEventArgs.PlayerId == _currentPlayerId)
            {
                comboBox1.DataSource = null;
                comboBox1.DataSource = handChangeEventArgs.Hand;
            }
        }

        void game_PlayerTurn(object sender, PlayerTurnEventArgs e)
        {
            textBox1.Text = "Player's turn: " + e.PlayerId + Environment.NewLine;
            textBox1.Text += "Player's hand: " + String.Join(", ", e.Hand) + Environment.NewLine;
            textBox1.Text += "Player's units: " + String.Join(", ", e.Units) + Environment.NewLine;
            _currentPlayerId = e.PlayerId;
            comboBox1.DataSource = e.Hand;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var card = (Card) comboBox1.SelectedItem;
            _game.PlayCard(_currentPlayerId, card.Id);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _game.EndTurn(_currentPlayerId);
        }
    }
}
