using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToeTermProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int turn = 0;
        int P1Score = 0;
        int P2Score = 0;
        int drawcount = 0;
        enum Status
        {
            Empty = 0,
            X = 1,
            O = -1
        }
       
        Enum[,] Board = new Enum[3, 3] { { Status.Empty, Status.Empty, Status.Empty}, { Status.Empty, Status.Empty, Status.Empty}, { Status.Empty, Status.Empty, Status.Empty } };
        // 1 2 3
        // 4 5 6
        // 7 8 9
        private void TicTac(Button button , int row, int column)
        {
            string marker = "";
            if (turn % 2 == 0)
            {
                marker = "X";
                Board[row, column] = Status.X;
            }
            else
            {
                marker = "O";
                Board[row, column] = Status.O;
            }



            button.IsEnabled = false;
            turn += 1;
            button.Content = marker;
        }
        private void reset()
        {
            turn = 0;
            A1.Content = "";
            A2.Content = "";
            A3.Content = "";
            B1.Content = "";
            B2.Content = "";
            B3.Content = "";
            C1.Content = "";
            C2.Content = "";
            C3.Content = "";

            A1.IsEnabled = true;
            A2.IsEnabled = true;
            A3.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            C1.IsEnabled = true;
            C2.IsEnabled = true;
            C3.IsEnabled = true;
            for(int i = 0; i<3; i++)
            {
                Board[i, 0] = Status.Empty;
                Board[i, 1] = Status.Empty;
                Board[i, 2] = Status.Empty;

            }
}

        private void Check()
        {
           for(int i = 0; i<3; i++)
            {
                if(Board[i,0].Equals(Board[i,1]) && Board[i,1].Equals(Board[i,2])) //checks horizontal wins
                {
                    if (Board[i, 0].Equals(Status.X))
                    {
                        P1Score += 1;
                        playerOneScore.Content = P1Score;
                        reset();
                    }
                    if (Board[i,0].Equals(Status.O))
                    {
                        P2Score += 1;
                        playerTwoScore.Content = P2Score;
                        reset();
                    }

                }

                if (Board[0, i].Equals(Board[1, i]) && Board[1, i].Equals(Board[2, i]))
                {
                    if (Board[0, i].Equals(Status.X))
                    {
                        P1Score += 1;
                        playerOneScore.Content = P1Score;
                        reset();
                    }
                    if (Board[0, i].Equals(Status.O))
                    {
                        P2Score += 1;
                        playerTwoScore.Content = P2Score;
                        reset();
                    }
                }

                if (turn == 9)
                {
                    drawcount += 1;
                    DrawScore.Content = drawcount;
                    reset();
                }
                
            }
            if (Board[0, 0].Equals(Board[1, 1]) && Board[1, 1].Equals(Board[2, 2])){
                if (Board[0, 0].Equals(Status.X))
                {
                    P1Score += 1;
                    playerOneScore.Content = P1Score;
                    reset();
                }
                if (Board[0, 0].Equals(Status.O))
                {
                    P2Score += 1;
                    playerTwoScore.Content = P2Score;
                    reset();
                }

            }
            if (Board[0,2].Equals(Board[1,1]) && Board[1, 1].Equals(Board[2, 0]))
            {
                if (Board[2, 0].Equals(Status.X))
                {
                    P1Score += 1;
                    playerOneScore.Content = P1Score;
                    reset();
                }
                if (Board[2, 0].Equals(Status.O))
                {
                    P2Score += 1;
                    playerTwoScore.Content = P2Score;
                    reset();
                }
            }

               
        }

       

        //private void BotTurn() will run the robots move.
    
        private void A1_Click(object sender, RoutedEventArgs e)
        {
            TicTac(A1,0,0);
            Check();
        }

        private void A2_Click(object sender, RoutedEventArgs e)
        {
            TicTac(A2,0,1);
            Check();

            
        }

        private void A3_Click(object sender, RoutedEventArgs e)
        {
            TicTac(A3,0,2);
            Check();

        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            TicTac(B1,1,0);
            Check();

        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            TicTac(B2,1,1);
            Check();

        }

        private void B3_Click(object sender, RoutedEventArgs e)
        {
            TicTac(B3,1,2);
            Check();
        }

        private void C1_Click(object sender, RoutedEventArgs e)
        {
            TicTac(C1,2,0);
            Check();

        }

        private void C2_Click(object sender, RoutedEventArgs e)
        {
            TicTac(C2,2,1);
            Check();

        }

        private void C3_Click(object sender, RoutedEventArgs e)
        {
            TicTac(C3,2,2);
            Check();

        }


        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {

            reset();



        }

        private void RoboButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
