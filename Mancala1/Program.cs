using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala1
{
    public class Program
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
            var Program = new Program();
            Program.DrawBoard();
            Program.StartGame();
        }

        public void DrawBoard()
        {
            Console.WriteLine(@"      ------------------------------------------      ");
            Console.WriteLine(@"    /    |      |      |      |      |      |    \    ");
            Console.WriteLine(@"   /     |  5   |  5   |  5   |  5   |  5   |     \   ");
            Console.WriteLine(@"  |      |      |      |      |      |      |      |  ");
            Console.WriteLine(@"  |  0   ------------------------------------  0   |  ");
            Console.WriteLine(@"  |      |      |      |      |      |      |      |  ");
            Console.WriteLine(@"   \     |  5   |  5   |  5   |  5   |  5   |     /   ");
            Console.WriteLine(@"    \    |      |      |      |      |      |    /    ");
            Console.WriteLine(@"      ------------------------------------------      ");
            Console.WriteLine(@"                                                      ");
            Console.WriteLine(@"Player 1: You                 Player 2: Computer      ");
            Console.WriteLine(@"Marbles Captured: 0           Marbles Captured: 0     ");
            Console.WriteLine(@"                                                      ");
            Console.WriteLine(@"                Current Player: You                   ");
            Console.WriteLine(@"                Started Square: 0                     ");
            Console.WriteLine(@"                Current Square: 0                     ");
            Console.WriteLine(@"                Marbles on Hand: 0                    ");
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


        public void DisplayStatus()
        {
            if (Player == 1)
            {
                Console.SetCursorPosition(32, 13);
                Console.Write("You           ");
            }
            if (Player == 2)
            {
                Console.SetCursorPosition(32, 13);
                Console.Write("Computer");
            }
            Console.SetCursorPosition(32, 14);
            Console.Write(StartSquare);
            Console.SetCursorPosition(32, 15);
            Console.Write(CurrentSquare + " ");
            Console.SetCursorPosition(33, 16);
        }


        public void DisplayMarbles()
        {
            int coordX = SquareCoordX[CurrentSquare];
            int coordY = SquareCoordY[CurrentSquare];
            Console.SetCursorPosition(coordX, coordY);
            Console.Write(SquareContent[CurrentSquare]);
            Console.Write(" ");
            DisplayStatus();
        }


        public bool IsCaptureTime()
        {
            int currentSquareContent = SquareContent[CurrentSquare];

            int nextSquare = AdvanceToNextSquare();
            int nextSquareContent = SquareContent[nextSquare];

            if (currentSquareContent == 0 && nextSquareContent > 0)
                return true;
            else
                return false;
        }


        public bool IsStopTime()
        {
            int currentSquareContent = SquareContent[CurrentSquare];

            int nextSquare = AdvanceToNextSquare();
            int nextSquareContent = SquareContent[nextSquare];

            if (currentSquareContent == 0 && nextSquareContent == 0)
                return true;
            else
                return false;
        }


        public bool IsEndTime()
        {
            // TODO: End the game if all squares are empty or players connot move annymore
        }


        public int AdvanceToNextSquare()
        {
            int nextSquare;

            if (CurrentSquare < 12)
                nextSquare = CurrentSquare + 1;
            else
                nextSquare = 1;

            return nextSquare;
        }

        /// <summary>
        /// Chooses the start square for each player
        /// </summary>
        /// <returns></returns>
        public int ChooseStartSquare()
        {
            int sq = 0;

            if (Player == 1) // You
            {
                while (sq >= 1 && sq <= 5)
                {
                    Console.SetCursorPosition(0, 20);
                    Console.WriteLine("Which box do you choose (1, 2, 3, 4, 5)?");
                    sq = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (Player == 2) // Computer
            {
                Console.SetCursorPosition(0, 22);
                Console.Write("Computer's Turn. Press enter to continue.");
                Console.ReadKey();
                Random computer = new Random();
                sq = computer.Next(7, 11);
            }

            return sq;
        }
    }
}