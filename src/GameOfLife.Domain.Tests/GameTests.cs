using System.Collections.Generic;
using Xunit;
using System.Linq;
using System.Text;

namespace GameOfLife.Domain.Tests
{
    public class GameTests
    {
        private Game _game = new Game();
        private Cell _firstCell = new Cell(0, 0);
        private Cell _secondCell = new Cell(1, 0);

        [Fact]
        public void Game_HasNineByNineCells_returnsCellCountOfNine()
        {
            Assert.Equal(81, _game.Cells.Count);
        }

        [Fact]
        public void Game_AllCellsByDefaultHasDeadState_ReturnsLiveCellsEqualsZero()
        {
            var liveCells = _game.Cells.Count(x => x.Live == true);
            Assert.Equal(0, liveCells);
        }

        [Fact]
        public void FindCell_WhereValidXAndYIsPassed_ReturnsCell()
        {
            int x = 1;
            int y = 0;

            var cell = _game.FindCellBy(x, y);

            Assert.Equal(x, cell.X);
            Assert.Equal(y, cell.Y);
        }

        [Fact]
        public void FindCell_WhereInValidXAndYIsPassed_ReturnsNull()
        {
            int x = 1000;
            int y = 500;

            var cell = _game.FindCellBy(x, y);

            Assert.Null(cell);
        }

        [Fact]
        public void FindCellBy_WhereLiveIsChangedToTrue_UpdatesGameObjectsCellLiveValueToTrueAsWell()
        {
            int x = 0;
            int y = 0;
            bool isLive = true;
            _game = new Game();

            var cell = _game.FindCellBy(x, y);
            Assert.False(cell.Live);
            cell.SetLive(isLive);
            Assert.True(cell.Live);

            Assert.Contains(_game.Cells, c => c.X == x && c.Y == y && c.Live == isLive);
        }

        [Fact]
        public void FindNeighbours_WhereACellHasNeighboursOnAllSide_ReturnsAListOf8Neighbours()
        {
            //0,0 | 1,0| 2,0
            //0,1 | 1,1| 2,1
            //0,2 | 1,2 |2,2

            Cell cell = new Cell(1, 1);
            var neighbourlist = _game.FindNeighbours(cell);

            Assert.Equal(8, neighbourlist.Count);
            Assert.Contains(neighbourlist, n => n.X == 0 && n.Y == 0);
            Assert.Contains(neighbourlist, n => n.X == 1 && n.Y == 0);
            Assert.Contains(neighbourlist, n => n.X == 2 && n.Y == 0);
            Assert.Contains(neighbourlist, n => n.X == 0 && n.Y == 1);
            Assert.Contains(neighbourlist, n => n.X == 2 && n.Y == 1);
            Assert.Contains(neighbourlist, n => n.X == 0 && n.Y == 2);
            Assert.Contains(neighbourlist, n => n.X == 1 && n.Y == 2);
            Assert.Contains(neighbourlist, n => n.X == 2 && n.Y == 2);
        }

        [Fact]
        public void FindNeighbours_WhereFirstCellHas3Neighbours_ReturnsAListOf3Neighbours()
        {
            //0,0 | 1,0
            //0,1 | 1,1

            var neighbourlist = _game.FindNeighbours(_firstCell);

            Assert.Equal(3, neighbourlist.Count);
            Assert.Contains(neighbourlist, n => n.X == 1 && n.Y == 0);
            Assert.Contains(neighbourlist, n => n.X == 0 && n.Y == 1);
            Assert.Contains(neighbourlist, n => n.X == 1 && n.Y == 1);
        }

        [Fact]
        public void Evolution_WhereFirstLiveCellWithlessThan2LiveNeighbours_ReturnsLiveEqualsToFalse()
        {
            // X|0 = 0,0|1,0
            // 0|X| = 1,0|1,1

            _game = new Game();
            GameObjectMother.LiveCellWithFewer1LiveNeighbours(_game);

            _game.Evolution();

            var returnCell = _game.FindCellBy(_firstCell.X, _firstCell.Y);

            Assert.False(returnCell.Live);
        }


        [Fact]
        public void Evolution_WhereFirstLiveCellWith3LiveNeighbours_ReturnsLiveEqualsToTrue()
        {
            //X|X = 0,0|1,0
            //X|X = 0,1|1,1

            _game = new Game();
            GameObjectMother.LiveCellWith3LiveNeighbours(_game);

            _game.Evolution();

            var returnCell = _game.FindCellBy(_firstCell.X, _firstCell.Y);

            Assert.True(returnCell.Live);
        }

        [Fact]
        public void Evolution_WhereFirstLiveCellWith2LiveNeighbours_ReturnsLiveEqualsToTrue()
        {
            //X|0 = 0,0|1,0
            //X|X = 0,1|1,1

            _game = new Game();
            GameObjectMother.LiveCellWith2LiveNeighbours(_game);

            _game.Evolution();

            var returnCell = _game.FindCellBy(_firstCell.X, _firstCell.Y);

            Assert.True(returnCell.Live);
        }

        [Fact]
        public void Evolution_WhereSecondCellWith4LiveNeighbours_ReturnsLiveEqualsToFalse()
        {
            //X|X|X = 0,0|1,0|2,0
            //X|X|0 = 0,1|1,1|2,1

            _game = new Game();
            GameObjectMother.LiveCellWith4LiveNeighbours(_game);

            _game.Evolution();

            var returnCell = _game.FindCellBy(_secondCell.X, _secondCell.Y);

            Assert.False(returnCell.Live);
        }

        [Fact]
        public void DisplayCells_WhereAllCellsAreFalse_ReturnsListOfFalseCellsIn2by2Dimensions()
        {
            //0|0 = 0,0|1,0
            //0|0 = 0,1|1,1

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("O|O");
            sb.AppendLine("O|O");

            _game = new Game(2, 2);

            var actual = _game.DisplayCell();

            Assert.Equal(sb.ToString(), actual);
        }      
    }
}