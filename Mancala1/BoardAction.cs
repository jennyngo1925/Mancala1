using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala1
{
    public partial class Mancala
    {
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
    }
}