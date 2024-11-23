using System.Collections.Generic;
using System.Media;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool gameOver;
        List<Button> gameTiles = new List<Button>();
        Random random = new Random();
        int playerWins = 0;
        int cpuWins = 0;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {
            gameTiles.Clear();
            gameTiles.AddRange([btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9]);

            foreach (Button button in gameTiles) 
            {
                button.Background = Brushes.White;
            }
            gameOver = false;
        }

        private void PlayerMove(object sender, RoutedEventArgs e)
        { 
            
            var button = (Button)sender;
            if (button.Background != Brushes.White) // Stops player from clicking used tile
            {
                return;
            }
            else 
            { 
                button.Background = Brushes.MediumPurple;
                gameTiles.Remove(button);
                CheckWin();
                CpuMove();
            }
        }

        private void CheckWin()
        {
            throw new NotImplementedException();
        }

        private void CpuMove()
        {
            Thread.Sleep(500); // Adds suspense
            int index = random.Next(gameTiles.Count);            
            var button = gameTiles[index];
            button.Background = Brushes.Orange;
            gameTiles.Remove(button);
        }



        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}