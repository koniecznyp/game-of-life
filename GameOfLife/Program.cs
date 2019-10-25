using GameOfLife;
using System;
using System.Threading;

public class Program
{
    private static Grid _grid;
    private static Printer _printer;
    private static Evolution _evolution;

    public static void Main()
    {
        _grid = new Grid(20);
        _printer = new Printer();
        _evolution = new Evolution();

        SetupWithSampleData();
        StartSimulation();
    }

    private static void SetupWithSampleData()
    {
        //glider
        _grid.Active(2, 3);
        _grid.Active(3, 4);
        _grid.Active(4, 2);
        _grid.Active(4, 3);
        _grid.Active(4, 4);

        //some random cells
        _grid.Active(6, 8);
        _grid.Active(6, 9);
        _grid.Active(7, 9);
        _grid.Active(10, 8);
        _grid.Active(10, 9);
        _grid.Active(11, 7);
        _grid.Active(11, 13);
        _grid.Active(12, 10);
        _grid.Active(13, 9);
    }

    private static void StartSimulation()
    {
        _printer.PrintGrid(_grid);
        for (int i = 0; i < 20; i++)
        {
            Thread.Sleep(500);
            Console.Clear();
            _grid = _evolution.GetNextGeneration(_grid);
            _printer.PrintGrid(_grid);
        }
        Console.WriteLine("End of simulation");
        Console.ReadLine();
    }
}
