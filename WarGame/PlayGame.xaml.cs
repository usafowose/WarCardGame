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
        //TODO - find out the better approach to get images
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
            //TODO - improve DRY code in these two button click methods
            imgComputerWarCard.Source = null;
            imgComputerWarCard2.Source = null;
            imgComputerWarCard3.Source = null;
            imgPlayerWarCard.Source = null;
            imgPlayerWarCard2.Source = null;
            imgPlayerWarCard3.Source = null;
            imgComputerWarBet.Source = null;
            imgPlayerWarBet.Source = null;

            bool result = Game.Turn();
            int cardTotalPlayer = Player.PlayerCards.Count + Player.CardsForShuffle.Count;
            int cardTotalComputer = PlayerComputer.PlayerCards.Count + PlayerComputer.CardsForShuffle.Count;
            imgComputerTurnCard.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"/CardPNGs/{PlayerComputer.TurnCard.ToString()}.PNG"));
            imgPlayerTurnCard.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"CardPNGs/{Player.TurnCard.ToString()}.PNG"));

            lblTotalCards.Content = cardTotalPlayer;
            if ((result && (cardTotalPlayer < 4 || cardTotalComputer < 4)) || Game.GameOver())
            {
                btnDeclareWar.Visibility = Visibility.Hidden;
                btnMakeTurn.Visibility = Visibility.Hidden;
                btnNewGame.Visibility = Visibility.Visible;
                MessageBox.Show($"Player {Game.GameWinner().PlayerName} wins!");
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
            imgPlayerWarCard2.Source = new BitmapImage(new Uri(backImagePath));
            imgPlayerWarCard3.Source = new BitmapImage(new Uri(backImagePath));

            bool result = Game.DeclareWar();
            int cardTotalPlayer = Player.PlayerCards.Count + Player.CardsForShuffle.Count;
            int cardTotalComputer = PlayerComputer.PlayerCards.Count + PlayerComputer.CardsForShuffle.Count;
            imgComputerWarBet.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + $"/CardPNGs/{PlayerComputer.TurnCard.ToString()}.PNG"));
            imgPlayerWarBet.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + $"CardPNGs/{Player.TurnCard.ToString()}.PNG"));

            lblTotalCards.Content = cardTotalPlayer;
            if ((result && (cardTotalPlayer < 4 || cardTotalComputer < 4)) || Game.GameOver())
            {
                btnDeclareWar.Visibility = Visibility.Hidden;
                btnMakeTurn.Visibility = Visibility.Hidden;
                btnNewGame.Visibility = Visibility.Visible;
                MessageBox.Show($"Player {Game.GameWinner().PlayerName} wins!");
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

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newGame = new MainWindow();
            newGame.Show();
            this.Close();
        }
    }
}
