using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WarGame_ClassLib;

namespace WarGame
{
    /// <summary>
    /// Interaction logic for PlayGame.xaml
    /// </summary>
    public partial class PlayGame : Window
    {
        Game Game { get; set; }
        Player PlayerComputer { get; set; }
        Player Player { get; set; }

        public PlayGame(string playerName)
        {
            InitializeComponent();
            Game = new Game();
            PlayerComputer = new Player("Computer");
            Player = new Player(playerName);
            Game.Players.Add(PlayerComputer);
            Game.Players.Add(Player);
            Game.DealCards();
            lblShowPlayerName.Content = playerName;
        }

        private void btnMakeTurn_Click(object sender, RoutedEventArgs e)
        {
            string result = Game.Turn();
            lblComputerCardTurn.Content = PlayerComputer.TurnCard.ToString();
            lblPlayerCardTurn.Content = Player.TurnCard.ToString();
            lblTurnResult.Content = result;
        }
    }
}
