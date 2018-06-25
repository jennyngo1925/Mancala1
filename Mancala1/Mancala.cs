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
                    continue;
                }

                //Computer's turn
                Player = 2;
                StartSquare = ChooseStartSquare();
                CurrentSquare = StartSquare;
                MarblesOnHand = 0; //Note: Marbles on hand before picking up or dropping down
                MoveUntilFinishTurn();
                if (IsGameEnd() == true)
                {
                    continue;
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

        }

        /// <summary>
        /// Moves and captures until loses the turn
        /// </summary>
        public void MoveUntilFinishTurn()
        {
            while (true)//Player
            {
                if (MarblesOnHand == 0) //Note: Marbles on hand before picking up or dropping down
                {
                    while (IsCaptureTime() == true)
                    {
                        CurrentSquare = AdvanceToNextSquare();
                        MarblesCapturedPlayer += SquareContent[CurrentSquare];
                        SquareContent[CurrentSquare] = 0;
                        DisplayMarbles();
                        CurrentSquare = AdvanceToNextSquare();

                        if (SquareContent[CurrentSquare] > 0)//how in the world do you make this stop
                        {
                            break;
                        }
                    }

                    if (IsTurnEnd() == true)
                    {
                        break;
                    }
                    else
                    {

                    }

                    MarblesOnHand = SquareContent[CurrentSquare]; //Note: Marbles on hand before picking up or dropping down
                    SquareContent[CurrentSquare] = 0;
                }
                else
                {
                    MarblesOnHand--; //Note: Marbles on hand before picking up or dropping down
                    SquareContent[CurrentSquare] = SquareContent[CurrentSquare] + 1;
                }

                DisplayMarbles();
                System.Threading.Thread.Sleep(1000);
                CurrentSquare = AdvanceToNextSquare();
            }
        }
    }
}