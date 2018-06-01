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
        }

        void DrawBoard()
        {
            Console.WriteLine(@"       ----------------------------------       ");
            Console.WriteLine(@"     /    |                               \     ");
            Console.WriteLine(@"   /      |                                 \   ");
            Console.WriteLine(@"  |                                          |  ");
            Console.WriteLine(@"  |    ---------------------------------     |  ");
            Console.WriteLine(@"  |                                          |  ");
            Console.WriteLine(@"   \                                        /   ");
            Console.WriteLine(@"     \                                    /     ");
            Console.WriteLine(@"       ----------------------------------       ");
            //Console.SetCursorPosition(5, 10);
            //System.Threading.Thread.Sleep(100);
            Console.ReadKey();
        }
    }
}
