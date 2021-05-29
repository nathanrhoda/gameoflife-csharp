namespace GameOfLife.Domain
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int Y { get; private set; }
        public int X { get; private set; }
        public bool Live { get; private set; }

        public void SetLive(bool b)
        {
            Live = b;
        }
    }
}