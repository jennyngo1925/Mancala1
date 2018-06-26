using System;
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
            Console.WriteLine(@"                Current Player:  You                  ");
            Console.WriteLine(@"                Started Square:  0                   ");
            Console.WriteLine(@"                Current Square:  0                    ");
            Console.WriteLine(@"                Marbles on Hand: 0                    ");
            Console.WriteLine(@"                Captured yet?:   No                   ");
            Console.WriteLine(@"                Lose turn yet?:  No                   ");
            Console.WriteLine(@"                Game over yet?:  No                   ");
            Console.WriteLine(@"                                                      ");

        }

        public void DisplayStatus()
        {
            if (Player == 1)
            {
                Console.SetCursorPosition(33, 13);
                Console.Write("You          ");
            }
            if (Player == 2)
            {
                Console.SetCursorPosition(33, 13);
                Console.Write("Computer");
            }
            Console.SetCursorPosition(18, 11);
            Console.Write(MarblesCapturedPlayer + " ");
            Console.SetCursorPosition(48, 11);
            Console.Write(MarblesCapturedComputer + " ");
            Console.SetCursorPosition(33, 14); 
            Console.Write(StartSquare + " ");
            Console.SetCursorPosition(33, 15);
            Console.Write(CurrentSquare + "  ");
            Console.SetCursorPosition(33, 16);
            Console.Write(MarblesOnHand + " "); //Note: Marbles on hand before picking up or dropping down 
            Console.SetCursorPosition(33, 17);
            if (IsCaptureTime() == true)
                Console.Write("Yes  ");
            else
                Console.Write("No   ");
            Console.SetCursorPosition(33, 18);
            if (IsTurnEnd() == true)
                Console.Write("Yes ");
            else
                Console.Write("No ");
            Console.SetCursorPosition(33, 19);
            if (IsGameEnd() == true)
                Console.Write("Yes ");
            else
                Console.Write("No ");
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

            if (MarblesOnHand == 0 && currentSquareContent == 0 && nextSquareContent > 0)
                return true;
            else
                return false;
        }


        public bool IsTurnEnd()
        {
            int currentSquareContent = SquareContent[CurrentSquare];

            int nextSquare = AdvanceToNextSquare();
            int nextSquareContent = SquareContent[nextSquare];

            if (MarblesOnHand == 0 && currentSquareContent == 0 && nextSquareContent == 0)
                return true;
            else
                return false;
        }


        public bool IsGameEnd()
        {
            return false;
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
                while (sq < 1 || sq > 5)
                {
                    Console.SetCursorPosition(0, 22);
                    Console.WriteLine("Which box do you choose (1, 2, 3, 4, 5)?       ");
                    sq = Convert.ToInt32(Console.ReadLine());
                }
            }
            else if (Player == 2) // Computer
            {
                Console.SetCursorPosition(0, 22);
                Console.Write("Computer's Turn. Press enter to continue.        ");
                Console.ReadKey();
                Random computer = new Random();
                sq = computer.Next(7, 11);
            }

            return sq;
        }
    }
}