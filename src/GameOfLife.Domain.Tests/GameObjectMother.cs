using System;
using System.Collections.Generic;

namespace GameOfLife.Domain.Tests
{
    public static class GameObjectMother
    {
        public static void LiveCellWithFewer1LiveNeighbours(Game game)
        {
            var isLive = true;
            
            // X|0 = 0,0|1,0
            // 0|X| = 1,0|1,1

            var cell1 = game.FindCellBy(0, 0);
            var cell2 = game.FindCellBy(0, 1);
            var cell3 = game.FindCellBy(1, 0);
            var cell4 = game.FindCellBy(1, 1);
            
            cell1.SetLive(isLive);
            cell4.SetLive(isLive);
        }

        public static void LiveCellWith3LiveNeighbours(Game game)
        {
            var isLive = true;
            //X|X = 0,0|1,0
            //X|X = 0,1|1,1

            var cell1 = game.FindCellBy(0, 0);
            var cell2 = game.FindCellBy(0, 1);
            var cell3 = game.FindCellBy(1, 0);
            var cell4 = game.FindCellBy(1, 1);

            cell1.SetLive(isLive);
            cell2.SetLive(isLive);
            cell3.SetLive(isLive);
            cell4.SetLive(isLive);
            
        }

        public static void LiveCellWith2LiveNeighbours(Game game)
        {
            var isLive = true;
            //X|0 = 0,0|1,0
            //X|X = 0,1|1,1

            var cell1 = game.FindCellBy(0, 0);            
            var cell3 = game.FindCellBy(1, 0);
            var cell4 = game.FindCellBy(1, 1);

            cell1.SetLive(isLive);            
            cell3.SetLive(isLive);
            cell4.SetLive(isLive);

        }

        internal static void LiveCellWith4LiveNeighbours(Game game)
        {
            var isLive = true;
            var isDead = false;
            //X|X|X = 0,0|1,0|2,0
            //X|X|0 = 0,1|1,1|2,1

            var cell1 = game.FindCellBy(0, 0);
            var cell2 = game.FindCellBy(1, 0);
            var cell3 = game.FindCellBy(2, 0);

            var cell4 = game.FindCellBy(0, 1);
            var cell5 = game.FindCellBy(1, 1);
            var cell6 = game.FindCellBy(2, 1);

            cell1.SetLive(isLive);
            cell2.SetLive(isLive);
            cell3.SetLive(isLive);
            cell4.SetLive(isDead);
            cell5.SetLive(isLive);
            cell6.SetLive(isLive);
        }
        

        internal static void DeadCellWith3LiveNeighbours(Game game)
        {
            var isLive = true;
            var isDead = false;
            //0|X = 0,0|1,0
            //X|X = 0,1|1,1

            var cell1 = game.FindCellBy(0, 0);
            var cell2 = game.FindCellBy(1, 0);
            var cell3 = game.FindCellBy(0, 1);
            var cell4 = game.FindCellBy(1, 1);

            cell1.SetLive(isDead);
            cell2.SetLive(isLive);
            cell3.SetLive(isLive);
            cell4.SetLive(isLive);
        }
    }
}