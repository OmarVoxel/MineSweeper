using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class MatrixTests
    {
        [Fact]
        public void MatrixAtZeroZeroHasADot()
        {
            Matrix matrix = new Matrix(4, 4);
            matrix.At(0, 0).Value.Should().Be('.');
        }
    }
}