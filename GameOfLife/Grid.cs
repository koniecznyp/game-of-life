using System;

namespace GameOfLife
{
    public class Grid
    {
        private int _size;

        public int Size
        {
            get { return _size; }
        }

        private bool[,] _cells;

        public Grid(int n)
        {
            _size = n;
            _cells = new bool[n, n];
        }

        public bool GetCellState(int x, int y)
        {
            CheckRange(x, y);
            return _cells[x, y];
        }

        public void Active(int x, int y)
        {
            CheckRange(x, y);
            _cells[x, y] = true;
        }

        public void Kill(int x, int y)
        {
            CheckRange(x, y);
            _cells[x, y] = false;
        }

        public int CountActiveCells()
        {
            var count = 0;
            for(int i=0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    count += _cells[i, j] == true ? 1 : 0;
            return count;
        }

        private void CheckRange(int x, int y)
        {
            if (x >= Size || y >= Size)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}
