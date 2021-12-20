using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {

        [Fact]
        public void PlayerLoseIfTheValueOfCellIsAMine()
        {
            Matrix matrix = new Matrix(new(4, 4));
            matrix.SetMine(new(1,1));
            
            MineSweeper mineSweeper = new(matrix, 2);
            mineSweeper.Open(new(1, 1));
            mineSweeper.HasLose.Should().Be(true);
        }
        
        [Fact]
        public void PlayerDoNotLoseIfTheValueOfCellIsNotAMine()
        {
            Matrix matrix = new Matrix(new(4, 4));
            matrix.SetMine(new(1,1));
            
            MineSweeper mineSweeper = new(matrix, 2);
            mineSweeper.Open(new(1, 0));
            mineSweeper.HasLose.Should().Be(false);
        }

        [Fact]
        public void PrintingTheMatrixReturnTheSameHarcodedList()
        {
            Cell[,] harcodedList = new Cell[4,4]
            {
                {  new Cell(','), new Cell(','), new Cell(','), new Cell(',') },
                {  new Cell(','), new Cell(','), new Cell(','), new Cell(',') },
                {  new Cell(','), new Cell(','), new Cell(','), new Cell(','), },
                {  new Cell(','), new Cell(','), new Cell(','), new Cell(',') }  
            };

            mineSweeper.GetMatrix().Should().Be(harcodedList);
        }
    }
}