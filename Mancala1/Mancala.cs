using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala1
{
    public partial class Mancala
    {
        static void Main(string[] args)
        {
            var Mancala = new Mancala();
            Mancala.DrawBoard();
            Mancala.StartGame();
        }

        public void StartGame()
        {
            while (true)
            {
                //Your turn
                Player = 1;
                StartSquare = ChooseStartSquare();
                CurrentSquare = StartSquare;
                MarblesOnHand = 0; //Note: Marbles on hand before picking up or dropping down
                MoveUntilFinishTurn();
                if (IsGameEnd() == true)
                {
                    break;
                }

                //Computer's turn
                Player = 2;
                StartSquare = ChooseStartSquare();
                CurrentSquare = StartSquare;
                MarblesOnHand = 0; //Note: Marbles on hand before picking up or dropping down
                MoveUntilFinishTurn();
                if (IsGameEnd() == true)
                {
                    break;
                }

            }

            //End of game
            if (IsGameEnd() == true)
            {
                if (MarblesCapturedComputer > MarblesCapturedPlayer)
                    Console.Write("Congratulations! You win!!!! :)");
                if (MarblesCapturedPlayer > MarblesCapturedComputer)
                    Console.Write("Haha you lose :P");
            }

        }

        /// <summary>
        /// Moves and captures until loses the turn
        /// </summary>
        public void MoveUntilFinishTurn()
        {
            while (true)
            {
                if (MarblesOnHand > 0) //Note: Marbles on hand before picking up or dropping down
                {
                    MarblesOnHand--; //Note: Marbles on hand before picking up or dropping down
                    SquareContent[CurrentSquare] = SquareContent[CurrentSquare] + 1;
                }
                else
                {
                    if (IsTurnEnd() == true)
                    {
                        break;
                    }

                    if (IsCaptureTime() == false)
                    {
                        MarblesOnHand = SquareContent[CurrentSquare]; //Note: Marbles on hand before picking up or dropping down
                        SquareContent[CurrentSquare] = 0;
                    }
                    else
                    {
                        while (SquareContent[CurrentSquare] == 0)
                        {
                            CurrentSquare = AdvanceToNextSquare();

                            if (Player == 1)
                            {
                                MarblesCapturedPlayer += SquareContent[CurrentSquare];
                            }

                            if (Player == 2)
                            {
                                MarblesCapturedComputer += SquareContent[CurrentSquare];
                            }
                            SquareContent[CurrentSquare] = 0;
                            DisplayMarbles();
                            DisplayStatus();
                            CurrentSquare = AdvanceToNextSquare();
                            Console.ReadKey();
                        }

                        //if (SquareContent[CurrentSquare] > 0)
                        break;
                    }

                    if (SquareContent[1] + SquareContent[2] + SquareContent[3] + SquareContent[4] + SquareContent[5] == 0)
                    {
                        MarblesCapturedComputer = MarblesCapturedComputer + SquareContent[7] + SquareContent[8] + SquareContent[9] + SquareContent[10] + SquareContent[11];
                        break;
                    }
                    if (SquareContent[7] + SquareContent[8] + SquareContent[9] + SquareContent[10] + SquareContent[11] == 0)
                    {
                        MarblesCapturedPlayer = MarblesCapturedPlayer + SquareContent[1] + SquareContent[2] + SquareContent[3] + SquareContent[4] + SquareContent[5];
                        break;
                    }
                }

                DisplayMarbles();
                Console.ReadKey();
                CurrentSquare = AdvanceToNextSquare();
            }
        }
    }
}