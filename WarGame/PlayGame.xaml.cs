using System;
using System.Collections.Generic;
using System.IO;
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
        //TODO - figuring out the better approach to get images
        string backImagePath = Directory.GetCurrentDirectory() + "/CardPNGs/backdesign_6.PNG";

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
            btnDeclareWar.Visibility = Visibility.Hidden;
            btnNewGame.Visibility = Visibility.Hidden;
            imgComputerDeck.Source = new BitmapImage(new Uri(backImagePath));
            imgPlayerDeck.Source = new BitmapImage(new Uri(backImagePath));
        }

        private void btnMakeTurn_Click(object sender, RoutedEventArgs e)
        {
            imgComputerWarCard.Source = null;
            imgComputerWarBet.Source = null;
            imgPlayerWarCard.Source = null;
            imgPlayerWarBet.Source = null;
            bool result = Game.Turn();
            int cardTotalPlayer = Player.PlayerCards.Count + Player.CardsForShuffle.Count;
            int cardTotalComputer = PlayerComputer.PlayerCards.Count + PlayerComputer.CardsForShuffle.Count;
            lblComputerCardTurn.Content = PlayerComputer.TurnCard.ToString();
            imgComputerTurnCard.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"/CardPNGs/{PlayerComputer.TurnCard.ToString()}.PNG"));
            lblPlayerCardTurn.Content = Player.TurnCard.ToString();
            imgPlayerTurnCard.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"CardPNGs/{Player.TurnCard.ToString()}.PNG"));
            lblTurnResult.Content = Game.TurnStatus;
            lblTotalCards.Content = cardTotalPlayer;
            if ((result && (cardTotalPlayer < 4 || cardTotalComputer < 4)) || Game.GameOver())
            {
                btnDeclareWar.Visibility = Visibility.Hidden;
                btnMakeTurn.Visibility = Visibility.Hidden;
                btnNewGame.Visibility = Visibility.Visible;
            }
            if (result)
            {
                btnDeclareWar.Visibility = Visibility.Visible;
                btnMakeTurn.Visibility = Visibility.Hidden;
            }
        }

        private void btnDeclareWar_Click(object sender, RoutedEventArgs e)
        {
            imgComputerWarCard.Source = new BitmapImage(new Uri(backImagePath));
            imgComputerWarCard2.Source = new BitmapImage(new Uri(backImagePath));
            imgComputerWarCard3.Source = new BitmapImage(new Uri(backImagePath));
            imgPlayerWarCard.Source = new BitmapImage(new Uri(backImagePath));
            bool result = Game.DeclareWar();
            int cardTotalPlayer = Player.PlayerCards.Count + Player.CardsForShuffle.Count;
            int cardTotalComputer = PlayerComputer.PlayerCards.Count + PlayerComputer.CardsForShuffle.Count;
            imgComputerWarBet.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"/CardPNGs/{PlayerComputer.TurnCard.ToString()}.PNG"));
            imgPlayerWarBet.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"CardPNGs/{Player.TurnCard.ToString()}.PNG"));
            lblTurnResult.Content = Game.TurnStatus;
            lblTotalCards.Content = cardTotalPlayer;
            if ((result && (cardTotalPlayer < 4 || cardTotalComputer < 4)) || Game.GameOver())
            {
                btnDeclareWar.Visibility = Visibility.Hidden;
                btnMakeTurn.Visibility = Visibility.Hidden;
                btnNewGame.Visibility = Visibility.Visible;
            }
            if (result)
            {
                btnDeclareWar.Visibility = Visibility.Visible;
                btnMakeTurn.Visibility = Visibility.Hidden;
            }
            else
            {
                btnDeclareWar.Visibility = Visibility.Hidden;
                btnMakeTurn.Visibility = Visibility.Visible;
            }
        }
    }
}
