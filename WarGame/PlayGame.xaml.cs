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
        Game game = new Game();
        public PlayGame(string playerName)
        {
            InitializeComponent();

            lblShowPlayerName.Content = playerName;
        }

        private void btnMakeTurn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello Dream Team!!!");
        }
    }
}
