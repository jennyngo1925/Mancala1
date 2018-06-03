using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala1
{
    class Program
    {
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
            Console.WriteLine(@"   /     |      |      |      |      |      |     \   ");
            Console.WriteLine(@"  |      |      |      |      |      |      |      |  ");
            Console.WriteLine(@"  |      ------------------------------------      |  ");
            Console.WriteLine(@"  |      |      |      |      |      |      |      |  ");
            Console.WriteLine(@"   \     |      |      |      |      |      |     /   ");
            Console.WriteLine(@"    \    |      |      |      |      |      |    /    ");
            Console.WriteLine(@"      ------------------------------------------      ");
            //Console.SetCursorPosition(5, 10);
            //System.Threading.Thread.Sleep(100);
            //Console.ReadKey();
        }

        void WalkSquare()
        {
            int n = 1;
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 0; j <= 4; j++)
                {
                    Console.SetCursorPosition(j*7+12, 2);
                    Console.Write(n++);
                    System.Threading.Thread.Sleep(1000);
                }

                Console.SetCursorPosition(5 * 7 + 12, 4);
                Console.Write(n++);
                System.Threading.Thread.Sleep(1000);

                for (int j = 4; j >=0 ; j--)
                {
                    Console.SetCursorPosition(j * 7 + 12, 6);
                    Console.Write(n++);
                    System.Threading.Thread.Sleep(1000);
                }

                Console.SetCursorPosition(-1 * 7 + 12, 4);
                Console.Write(n++);
                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadKey();
        }
    }
}
