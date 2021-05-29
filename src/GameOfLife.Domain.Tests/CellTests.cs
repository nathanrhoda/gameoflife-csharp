using Xunit;

namespace GameOfLife.Domain.Tests
{
    public class CellTests
    {
        private Cell _cell = new Cell(1,1);
        
        [Fact]
        public void Cell_WhenCreatedWithXAndYValues_RetainsPassedInXAndYValues()
        {
            int x = 5;
            int y = 2;
            _cell = new Cell(x,y);
            Assert.Equal(5, _cell.X);
            Assert.Equal(2, _cell.Y);
        }

        [Fact]
        public void Cell_WhenSetToLive_ReturnsLiveStatus()
        {
            _cell.SetLive(true);
            
            Assert.True(_cell.Live);
        }
        
        [Fact]
        public void Cell_WhenSetToDeal_ReturnsLiveFalse()
        {
            _cell.SetLive(false);
            Assert.False(_cell.Live);
        }
    }
}