using FluentAssertions;
using System;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {
        [Fact]
        public void MatrixAtZeroZeroHasADot()
        {
            Matrix matrix = new Matrix(4, 4);
            matrix.At(0, 0).Value.Should().Be('.');
        }
    }
}