using FluentAssertions;
using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridTests
    {
        [Fact]
        public void GetCellState_CellIsActive_StateIsTrue()
        {
            var grid = new Grid(10);
            grid.Active(4, 5);
            var result = grid.GetCellState(4, 5);
            result.Should().Be(true);
        }

        [Fact]
        public void GetCellState_CellIsNotActive_StateIsFalse()
        {
            var grid = new Grid(10);
            var result = grid.GetCellState(4, 5);
            result.Should().Be(false);
        }

        [Fact]
        public void GetCellState_IndexOfCellIsOutOfRange_MethodThrowException()
        {
            var grid = new Grid(10);
            var exception = Assert.Throws<IndexOutOfRangeException>(()
                => grid.GetCellState(5, 20));
            Assert.IsType<IndexOutOfRangeException>(exception);
        }

        [Fact]
        public void Active_ActivateCell_CellShouldBeActive()
        {
            var grid = new Grid(10);
            grid.Active(2, 5);
            var result = grid.GetCellState(2, 5);
            result.Should().Be(true);
        }

        [Fact]
        public void Active_ActivateCellManyTimes_CellShouldBeStillActive()
        {
            var grid = new Grid(10);
            grid.Active(2, 5);
            grid.Active(2, 5);
            var result = grid.GetCellState(2, 5);
            result.Should().Be(true);
        }

        [Fact]
        public void Active_AllCellsAreInactive_AllCellsShouldBeActivated()
        {
            int n = 10;
            var grid = new Grid(n);

            for (int i = 0; i < grid.Size; ++i)
                for (int j = 0; j < grid.Size; ++j)
                    grid.Active(i, j);

            var activeCount = grid.CountActiveCells();
            activeCount.Should().Be(n * n);
        }
        
        [Fact]
        public void Active_XIndexOfCellIsOutOfRange_MethodThrowException()
        {
            var grid = new Grid(10);
            var exception = Assert.Throws<IndexOutOfRangeException>(()
                => grid.Active(20, 4));
            Assert.IsType<IndexOutOfRangeException>(exception);
        }

        [Fact]
        public void Active_YIndexOfCellIsOutOfRange_MethodThrowException()
        {
            var grid = new Grid(10);
            var exception = Assert.Throws<IndexOutOfRangeException>(()
                => grid.Active(5, 20));
            Assert.IsType<IndexOutOfRangeException>(exception);
        }

        [Fact]
        public void Kill_CellIsInactive_CellShouldBeStillInactive()
        {
            var grid = new Grid(10);
            grid.Kill(3, 5);
            var result = grid.GetCellState(3, 5);
            result.Should().Be(false);
        }

        [Fact]
        public void Kill_CellIsActive_ActiveCellShouldBeKilled()
        {
            var grid = new Grid(10);
            grid.Active(3, 5);
            grid.Kill(3, 5);
            var result = grid.GetCellState(3, 5);
            result.Should().Be(false);
        }

        [Fact]
        public void Kill_AllCellsAreActive_AllCellsShouldBeKilled()
        {
            int n = 10;
            var grid = new Grid(n);

            for (int i = 0; i < grid.Size; ++i)
                for (int j = 0; j < grid.Size; ++j)
                    grid.Active(i, j);

            for (int i = 0; i < grid.Size; ++i)
                for (int j = 0; j < grid.Size; ++j)
                    grid.Kill(i, j);

            var activeCount = grid.CountActiveCells();
            activeCount.Should().Be(0);
        }

        [Fact]
        public void CountActiveCells_ActiveCellsExists_MethodShouldReturnPositiveNumber()
        {
            var grid = new Grid(10);
            grid.Active(3, 2);
            grid.Active(4, 2);
            grid.Active(4, 3);
            var result = grid.CountActiveCells();
            result.Should().Be(3);
        }

        [Fact]
        public void CountActiveCells_ActiveCellsNotExists_MethodShouldReturnZero()
        {
            var grid = new Grid(10);
            var result = grid.CountActiveCells();
            result.Should().Be(0);
        }
    }
}
