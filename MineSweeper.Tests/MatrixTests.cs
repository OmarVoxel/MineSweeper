using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class MatrixTests
    {
        [Fact]
        public void MatrixAtZeroZeroHasADot()
        {
            Matrix matrix = new Matrix(new Coordinate(4,4));
            matrix.At(new Coordinate(0,0)).Value.Should().Be('.');
        }
    }
}