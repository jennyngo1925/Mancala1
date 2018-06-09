using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala1
{
    class Program
    {
        int[] SquareContent = new int[13] { 0, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 0 };
        int[] SquareCoordX = new int[13] { 0, 12, 19, 26, 33, 40, 47, 40, 33, 26, 19, 12, 5 };
        int[] SquareCoordY = new int[13] { 0, 6, 6, 6, 6, 6, 4, 2, 2, 2, 2, 2, 4 };

        static void Main(string[] args)
        {
            var Program = new Program();
            Program.DrawBoard();
            Program.WalkSquare();
        }

        void DrawBoard()
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

        void WalkSquare()
        {
            int currentSquare;
            int marblesOnHand;
            int coordX;
            int coordY;
            int startSquare;

            Console.SetCursorPosition(0, 20);
            Console.WriteLine("Which box do you choose (1, 2, 3, 4, 5)?");
            startSquare = Convert.ToInt32(Console.ReadLine());
            if (startSquare > 5)
            {
                Console.WriteLine("PLEASE CHOOSE A NUMBER BETWEEN 1 AND 5!!!");
                startSquare = Convert.ToInt32(Console.ReadLine());
            }

            currentSquare = startSquare;
            marblesOnHand = 0;

            while (true)
            {
                if (marblesOnHand == 0)
                {
                    marblesOnHand = SquareContent[currentSquare];
                    SquareContent[currentSquare] = 0;
                }
                marblesOnHand = marblesOnHand - 1;
                SquareContent[currentSquare] = SquareContent[currentSquare] + 1;
                coordX = SquareCoordX[currentSquare];
                coordY = SquareCoordY[currentSquare];
                Console.SetCursorPosition(coordX, coordY);
                Console.Write(SquareContent[currentSquare]);
                Console.SetCursorPosition(32, 14);
                Console.Write(startSquare);
                Console.SetCursorPosition(32, 15);
                Console.Write(currentSquare + " ");
                Console.SetCursorPosition(33, 16);
                Console.Write(marblesOnHand);
                System.Threading.Thread.Sleep(1000);
                if (currentSquare < 12)
                    currentSquare = currentSquare + 1;
                else
                    currentSquare = 1;
            }
        }
    }
}