using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfTicTacToe
{    
    public partial class MainWindow : Window
    {
        bool gameOver;
        List<Button> gameTiles = new List<Button>(); // A list of unclicked buttons for CPU-moves to work
        Random random = new Random();
        CurrentPlayer player;
        int playerWins = 0;
        int cpuWins = 0;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        /// <summary>
        /// Resets buttons for
        /// </summary>
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
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        private void PlayerMove(object sender, RoutedEventArgs e)
        { 
            var button = (Button)sender;

            if (gameOver || (button.Background != Brushes.White)) // Makes gameboard unclickable until NewGame and stops player from clicking used tile
            { return; } 
            else 
            {
                player = CurrentPlayer.Player;
                button.Background = Brushes.MediumPurple;
                gameTiles.Remove(button);
                CheckWin(button);
                
                if(!gameOver)
                    CpuMove();
            }
        }

        private void CpuMove()
        {
            if (gameTiles.Count == 0)
            {
                MessageBox.Show("Draw!");
                return;
            }

            if (!gameOver)
            {
                player = CurrentPlayer.CPU;
                Thread.Sleep(500); // Adds suspense
                int index = random.Next(gameTiles.Count);
                var button = gameTiles[index];
                button.Background = Brushes.Orange;
                gameTiles.Remove(button);
                CheckWin(button);
            }
        }
        
        /*
         * 1|2|3
         * 4|5|6
         * 7|8|9
         */
        private void CheckWin(Button button)
        {
            //This is so ugly
            {
                if ((((button.Background == btn1.Background) && (button.Background == btn2.Background) && (button.Background == btn3.Background)) || //Row win
                    ((button.Background == btn4.Background) && (button.Background == btn5.Background) && (button.Background == btn6.Background)) || //Row win
                    ((button.Background == btn7.Background) && (button.Background == btn8.Background) && (button.Background == btn9.Background)))|| //Row win
                    (((button.Background == btn1.Background) && (button.Background == btn4.Background) && (button.Background == btn7.Background)) || //Column win
                    ((button.Background == btn2.Background) && (button.Background == btn5.Background) && (button.Background == btn8.Background)) || //Column win
                    ((button.Background == btn3.Background) && (button.Background == btn6.Background) && (button.Background == btn9.Background))) || //Column win
                    ((button.Background == btn1.Background) && (button.Background == btn5.Background) && (button.Background == btn9.Background)) || //Diagonal win
                    ((button.Background == btn3.Background) && (button.Background == btn5.Background) && (button.Background == btn7.Background))) //Diagonal win
                {
                    gameOver = true;
                    MessageBox.Show($"{player} Wins!");

                    if (player == CurrentPlayer.Player)
                    {
                        playerWins++;
                        PlayerWins.Content = $"Player: {playerWins}";
                    }
                    else
                    {
                        cpuWins++;
                        CPUWins.Content = $"CPU: {cpuWins}";
                    }
                }
            }            
        }
    }
}