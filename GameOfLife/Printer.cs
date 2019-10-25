using System;

namespace GameOfLife
{
    public class Printer
    {
        private int _counter;

        public Printer()
        {
            _counter = 0;
        }

        public void PrintGrid(Grid grid)
        {
            Console.WriteLine($"Iteration {_counter++}\nActive cells {grid.CountActiveCells()}");
            for (int i = 0; i < grid.Size; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    if (grid.GetCellState(i, j) == false)
                        Console.Write("  .  ");
                    else
                        Console.Write(" [X] ");
                }
                Console.WriteLine();
            }
        }
    }
}
