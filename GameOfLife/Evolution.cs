namespace GameOfLife
{
    public class Evolution
    {
        public Evolution()
        {
        }

        public Grid GetNextGeneration(Grid currentGrid)
        {
            var newGrid = new Grid(currentGrid.Size);

            for (int l = 1; l < currentGrid.Size - 1; l++)
            {
                for (int m = 1; m < currentGrid.Size - 1; m++)
                {
                    int activeNeighbours = GetNumberOfActiveNeighbours(currentGrid, l, m);

                    if ((currentGrid.GetCellState(l, m) == true) && (activeNeighbours < 2))
                        newGrid.Kill(l, m);

                    else if ((currentGrid.GetCellState(l, m) == true) && (activeNeighbours > 3))
                        newGrid.Kill(l, m);

                    else if ((currentGrid.GetCellState(l, m) == false) && (activeNeighbours == 3))
                        newGrid.Active(l, m);

                    else
                    {
                        if (currentGrid.GetCellState(l, m))
                            newGrid.Active(l, m);
                        else
                            newGrid.Kill(l, m);
                    }
                }
            }
            return newGrid;
        }

        public int GetNumberOfActiveNeighbours(Grid grid, int x, int y)
        {
            int activeNeighbours = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                    activeNeighbours += grid.GetCellState(x + i, y + j) == true ? 1 : 0;

            activeNeighbours -= grid.GetCellState(x, y) == true ? 1 : 0;
            return activeNeighbours;
        }
    }
}
