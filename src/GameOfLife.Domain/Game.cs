using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.Domain
{
    public class Game
    {
        
        private int XDimension = 9;
        private int YDimension = 9;
        public List<Cell> Cells { get; private set; }

        public Game()
        {
            Intialize();
        }

        #region Public Methods

        public Cell FindCellBy(int x, int y)
        {
            return Cells.SingleOrDefault(cell => cell.X == x && cell.Y == y);
        }
        public List<Cell> FindNeighbours(Cell cell)
        {
            var neighbourlist = new List<Cell>();

            var cell1 = FindCellBy(cell.X - 1, cell.Y - 1);
            var cell2 = FindCellBy(cell.X, cell.Y - 1);
            var cell3 = FindCellBy(cell.X + 1, cell.Y - 1);

            var cell4 = FindCellBy(cell.X - 1, cell.Y);
            var cell5 = FindCellBy(cell.X + 1, cell.Y);

            var cell6 = FindCellBy(cell.X - 1, cell.Y + 1);
            var cell7 = FindCellBy(cell.X, cell.Y + 1);
            var cell8 = FindCellBy(cell.X + 1, cell.Y + 1);

            if (cell1 != null)
                neighbourlist.Add(cell1);

            if (cell2 != null)
                neighbourlist.Add(cell2);

            if (cell3 != null)
                neighbourlist.Add(cell3);

            if (cell4 != null)
                neighbourlist.Add(cell4);

            if (cell5 != null)
                neighbourlist.Add(cell5);

            if (cell6 != null)
                neighbourlist.Add(cell6);

            if (cell7 != null)
                neighbourlist.Add(cell7);

            if (cell8 != null)
                neighbourlist.Add(cell8);

            return neighbourlist;
        }

        public void Evolution()
        {
            var cellList = this.Cells;

            foreach (var cell in cellList)
            {
                var neighbourlist = FindNeighbours(cell);

                if (cell.Live == true)
                {
                    if (UnderPopulation(neighbourlist))
                    {
                        cell.SetLive(false);
                    }

                    if (NextGeneration(neighbourlist))
                    {
                        cell.SetLive(true);
                    }

                    if (Overpopulation(neighbourlist))
                    {
                        cell.SetLive(false);
                    }
                }
                else
                {
                    if (Reproduction(neighbourlist))
                    {
                        cell.SetLive(true);
                    }
                }


            }
        }

        #endregion

        #region Private Methods

        #region Initialize
        internal Game(int x, int y)
        {
            XDimension = x;
            YDimension = y;
            Intialize();
        }

        private void Intialize()
        {
            Cells = new List<Cell>();
            for (int x = 0; x <= XDimension - 1; x++)
            {
                for (int y = 0; y <= YDimension - 1; y++)
                {
                    Cells.Add(new Cell(x, y));
                }
            }
        }
        #endregion

        #region States
        private static bool Reproduction(List<Cell> neighbourlist)
        {
            return neighbourlist.Count(x => x.Live == true) == 3;
        }

        private static bool Overpopulation(List<Cell> neighbourlist)
        {
            return neighbourlist.Count(x => x.Live == true) > 3;
        }

        private static bool NextGeneration(List<Cell> neighbourlist)
        {
            return neighbourlist.Count(x => x.Live) > 2 && neighbourlist.Count(x => x.Live) < 3;
        }

        private static bool UnderPopulation(List<Cell> neighbourlist)
        {
            return neighbourlist.Count(x => x.Live == true) < 2;
        }
        #endregion

        #region Display
        public string DisplayCell()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < YDimension; y++)
            {
                for (int x = 0; x < XDimension; x++)
                {

                    var cell = Cells.Single(cell => cell.X == x && cell.Y == y);

                    if (cell.Live)
                    {
                        sb.Append("X");
                    }
                    else
                    {
                        sb.Append("O");
                    }

                    if (MovingToANewLine(cell))
                    {
                        sb.AppendLine();
                    }
                    else
                        if (NotAtEndOfLine(cell))
                    {
                        sb.Append("|");
                    }
                }
            }

            return sb.ToString();
        }

        private bool NotAtEndOfLine(Cell cell)
        {
            return cell.X < XDimension;
        }

        private bool MovingToANewLine(Cell cell)
        {
            return cell.X == XDimension - 1;
        }
        #endregion 
        #endregion

    }
}