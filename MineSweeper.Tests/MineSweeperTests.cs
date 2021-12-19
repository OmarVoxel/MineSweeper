using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {

        [Fact]
        public void MatrixFromMatrixIsntTheSameThanMatrixFromMineSweeper()
        {
            Matrix _matrix = new Matrix(4, 4);
            MineSweeper mineSweeper = new MineSweeper(4, 4, 2);
            mineSweeper.Matrix.Should().NotBe(_matrix);
        }
    }
}