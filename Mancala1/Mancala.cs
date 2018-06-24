﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala1
{
    public partial class Mancala
    {
        int[] SquareContent = new int[13] { 0, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 0 };
        int[] SquareCoordX = new int[13] { 0, 12, 19, 26, 33, 40, 47, 40, 33, 26, 19, 12, 5 };
        int[] SquareCoordY = new int[13] { 0, 6, 6, 6, 6, 6, 4, 2, 2, 2, 2, 2, 4 };
        int CurrentSquare;
        int MarblesCapturedPlayer = 0;
        int MarblesCapturedComputer = 0;
        int MarblesOnHand; //Note: Marbles on hand before picking up or dropping down
        int StartSquare;
        int Player = 1; // 1=You, 2=Computer

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
                if (IsEndTime() == true)
                {
                    break;
                }

                //Computer's turn
                Player = 2;
                StartSquare = ChooseStartSquare();
                CurrentSquare = StartSquare;
                MarblesOnHand = 0; //Note: Marbles on hand before picking up or dropping down
                MoveUntilFinishTurn();
                if (IsEndTime() == true)
                {
                    break;
                }
            }

            // TODO: determine the winner
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
                    while (IsCaptureTime() == true && CurrentSquare != 10 && CurrentSquare != 4)
                    {
                        CurrentSquare = AdvanceToNextSquare();
                        MarblesCapturedPlayer += SquareContent[CurrentSquare];
                        Console.SetCursorPosition(18, 11);
                        Console.Write(MarblesCapturedPlayer);
                        SquareContent[CurrentSquare] = 0;
                        DisplayMarbles();
                        CurrentSquare = AdvanceToNextSquare();
                    }

                    if (IsStopTime() == true)
                    {
                        Player = 2;
                        Console.SetCursorPosition(0, 22);
                        Console.Write("Computer's Turn. Press enter to continue.");
                        Console.ReadKey();

                        MarblesOnHand = 0; //Note: Marbles on hand before picking up or dropping down
                        Random computer = new Random();
                        int computerInt = computer.Next(7, 11);
                        StartSquare = computerInt;
                        SquareContent[computerInt] = SquareContent[StartSquare];

                        while (SquareContent[StartSquare] == 0)
                        {
                            computerInt = computer.Next(7, 11);
                            StartSquare = computerInt;
                        }
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
                Console.Write(MarblesOnHand); //Note: Marbles on hand before picking up or dropping down
                Console.Write(" ");
                System.Threading.Thread.Sleep(1000);
                CurrentSquare = AdvanceToNextSquare();
            }
        }
    }
}