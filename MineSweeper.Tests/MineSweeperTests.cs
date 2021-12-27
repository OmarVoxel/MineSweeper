using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {

        [Fact]
        public void PlayerLoseIfTheValueOfCellIsAMine()
        {
            Matrix matrix = new Matrix(4, 4);
            matrix.SetMine(new(1,1));
            
            MineSweeper mineSweeper = new(matrix, 2);
            mineSweeper.Open(new(1, 1));
            mineSweeper.HasLose.Should().Be(true);
        }
        
        [Fact]
        public void PlayerDoNotLoseIfTheValueOfCellIsNotAMine()
        {
            Matrix matrix = new Matrix(4, 4);
            matrix.SetMine(new(1,1));
            
            MineSweeper mineSweeper = new(matrix, 2);
            mineSweeper.Open(new(1, 0));
            mineSweeper.HasLose.Should().Be(false);
        }

        [Fact]
        public void WhenMatrixIsPrintedShouldShowTheFollowingString()
        {
            string printExpected = "....\n....\n....\n....\n";

            Matrix matrix = new Matrix(4, 4);
            MineSweeper mineSweeper = new(matrix, 2);
            
            mineSweeper.PrintMatrix().Should().Be(printExpected);
        }
        
        [Fact]
        public void CellIsOpenWithoutAMineButWithOneMineAdjacent()
        {
            string printExpected = "1...\n....\n....\n....\n";

            Matrix matrix = new Matrix(4, 4);
            matrix.SetMine(new(0,1));
            
            MineSweeper mineSweeper = new(matrix, 2);
            mineSweeper.Open(new(0,0));
            
            mineSweeper.PrintMatrix().Should().Be(printExpected);
        }
        
        [Fact]
        public void CellIsOpenWithoutAMineButWithTwoMineAdjacent()
        {
            string printExpected = "2..\n...\n...\n";

            Matrix matrix = new Matrix(3,3);
            matrix.SetMine(new(0,1));
            matrix.SetMine(new(1,0));
            
            MineSweeper mineSweeper = new(matrix, 2);
            mineSweeper.Open(new(0,0));
            
            mineSweeper.PrintMatrix().Should().Be(printExpected);
        }
        
        [Fact]
        public void PlayerWinIfCanNotOpenNoMoreCells()
        {
            Matrix matrix = new Matrix(3, 3);
            
            matrix.SetMine(new(0,1));
            matrix.SetMine(new(0,2));

            matrix.SetMine(new(1,0));
            matrix.SetMine(new(1,1));
            matrix.SetMine(new(1,2));

            matrix.SetMine(new(2,0));
            matrix.SetMine(new(2,1));
            matrix.SetMine(new(2,2));

            MineSweeper mineSweeper = new(matrix, 2);
            mineSweeper.Open(new(0, 0));
            
            mineSweeper.HasWin.Should().Be(true);
            mineSweeper.HasWin.Should().Be(true);
        }
        
    }
}