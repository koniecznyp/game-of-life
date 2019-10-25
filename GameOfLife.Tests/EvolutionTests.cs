using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GameOfLife.Tests
{
    public class EvolutionTests
    {
        [Fact]
        public void GetNextGeneration_GridIsEmpty_NewGenerationShouldBeEmpty()
        {
            var grid = new Grid(10);
            var evolution = new Evolution();

            var newGeneration = evolution.GetNextGeneration(grid);
            newGeneration.CountActiveCells().Should().Be(0);
        }

        [Fact]
        public void GetNextGeneration_OneActiveCellExists_NewGenerationShouldBeEmpty()
        {
            var grid = new Grid(10);
            grid.Active(3, 4);
            var evolution = new Evolution();

            var newGeneration = evolution.GetNextGeneration(grid);
            newGeneration.CountActiveCells().Should().Be(0);
        }

        [Theory]
        [InlineData(4, 4)]
        [InlineData(4, 5)]
        [InlineData(4, 6)]
        [InlineData(5, 4)]
        [InlineData(5, 6)]
        [InlineData(6, 4)]
        [InlineData(6, 5)]
        [InlineData(6, 6)]
        public void GetNextGeneration_TwoActiveCellsNextToEachOtherExists_NewGenerationShouldBeEmpty(int x, int y)
        {
            var grid = new Grid(10);
            grid.Active(5, 5);
            grid.Active(x, y);
            var evolution = new Evolution();

            var newGeneration = evolution.GetNextGeneration(grid);
            newGeneration.CountActiveCells().Should().Be(0);
        }

        [Fact]
        public void GetNextGeneration_ThreeCellsInRowExists_NewGenerationShouldBeReturned()
        {
            var grid = new Grid(10);
            grid.Active(3, 4);
            grid.Active(3, 5);
            grid.Active(3, 6);
            var evolution = new Evolution();

            var newGeneration = evolution.GetNextGeneration(grid);

            newGeneration.CountActiveCells().Should().Be(3);
            newGeneration.GetCellState(2, 5).Should().Be(true);
            newGeneration.GetCellState(3, 5).Should().Be(true);
            newGeneration.GetCellState(4, 5).Should().Be(true);
        }

        [Fact]
        public void GetNextGeneration_ThreeCellsAreDiagonallyAdjacentToEachOther_NewGenerationShouldBeReturned()
        {
            var grid = new Grid(10);

            grid.Active(3, 3);
            grid.Active(4, 4);
            grid.Active(5, 3);
            var evolution = new Evolution();

            var newGeneration = evolution.GetNextGeneration(grid);

            newGeneration.CountActiveCells().Should().Be(2);
            newGeneration.GetCellState(4, 3).Should().Be(true);
            newGeneration.GetCellState(4, 4).Should().Be(true);
        }


        [Fact]
        public void GetNextGeneration_TwoPairsOfSeparatedCellsExists_NewGenerationShouldBeEmpty()
        {
            var grid = new Grid(10);
            grid.Active(3, 3);
            grid.Active(3, 4);

            grid.Active(7, 6);
            grid.Active(7, 7);
            var evolution = new Evolution();

            var newGeneration = evolution.GetNextGeneration(grid);

            newGeneration.CountActiveCells().Should().Be(0);
        }

        [Fact]
        public void GetNextGeneration_GliderTest_After10InterationsThereShouldBe5ActiveCells()
        {
            var grid = new Grid(10);
            grid.Active(2, 3);
            grid.Active(3, 4);
            grid.Active(4, 2);
            grid.Active(4, 3);
            grid.Active(4, 4);

            var evolution = new Evolution();
            for (int i = 0; i < 10; ++i)
            {
                grid = evolution.GetNextGeneration(grid);
            }
            grid.CountActiveCells().Should().Be(5);
            grid.GetCellState(5, 6).Should().Be(true);
            grid.GetCellState(6, 4).Should().Be(true);
            grid.GetCellState(6, 6).Should().Be(true);
            grid.GetCellState(7, 5).Should().Be(true);
            grid.GetCellState(7, 6).Should().Be(true);
        }
    }
}
