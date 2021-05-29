using GameOfLife.Domain;
using System.Linq;
using System;
using System.Threading;

namespace GameOfLife.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Game of life");

            Console.WriteLine("Press any key to begin");


            Game game = new Game();
            InitializeGame(game);

            //var cells = game.Cells.Where(x => x.Live == true);
            var counter = game.Cells.Count(x => x.Live == true);            

            int count = 0;

            while (true)
            {                
                var grid = game.DisplayCell();

                Console.SetCursorPosition(0, 4);
                Console.Write("\rTick: {0}", count++);

                Console.SetCursorPosition(0, 5);
                //Console.Write("{0}", grid);
                Console.WriteLine(grid);
                game.Evolution();

                Thread.Sleep(3000);
            }
        }

        private static void InitializeGame(Game game)
        {
            var cell1 = game.FindCellBy(0, 0);
            var cell2 = game.FindCellBy(0, 1);
            var cell3 = game.FindCellBy(1, 0);
            var cell4 = game.FindCellBy(1, 1);
            var cell5 = game.FindCellBy(0, 2);
            var cell6 = game.FindCellBy(2, 2);
            var cell7 = game.FindCellBy(4, 1);
            var cell8 = game.FindCellBy(4, 2);
            var cell9 = game.FindCellBy(3, 2);


            cell1.SetLive(true);
            cell2.SetLive(true);
            cell3.SetLive(true);
            cell4.SetLive(true);
            cell5.SetLive(true);
            cell6.SetLive(true);
            cell7.SetLive(true);
            cell8.SetLive(true);
            cell9.SetLive(true);
        }
    }
}