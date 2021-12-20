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
            mineSweeper.Open(1, 1);
            mineSweeper.HasLose.Should().Be(true);
        }
    }
}