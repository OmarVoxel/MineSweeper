using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class MatrixTests
    {
        [Fact]
        public void MatrixAtZeroZeroHasADot()
        {
            Matrix matrix = new Matrix( new Size(4, 4));
            matrix.At(new Coordinate(0, 0)).Value.Should().Be('.');
        }

        [Fact]
        public void SetAMineInThePositionZeroZero()
        {
            Matrix matrix = new Matrix( new Size(4, 4));
            matrix.SetMine(new Coordinate(0, 0));
            matrix.At(new Coordinate(0, 0)).Value.Should().Be('*');
        }

        [Fact]
        public void MatrixIsntTheSameAfterSetAMine()
        {
            Matrix m1 = new Matrix( new Size(4, 4));
            m1.SetMine(new(1, 1));
            Matrix m2 = new Matrix( new Size(4, 4));
            m2.SetMine(new(1, 1));
            Matrix xx = new Matrix( new Size(4, 4));
            xx.SetMine(new(2, 2));

            m2.Should().Be(m1);
            xx.Should().NotBe(m1);
        }

        [Fact]
        public void CellHasADotInTheCoordenateOneOne()
        {
            Matrix m1 = new Matrix( new Size(4, 4));
            m1.Open(new (1,1)).Value.Should().Be('.');
        }
        
        [Fact]
        public void CellHasAnAstherictInTheCoordenateOneOne()
        {
            Matrix m1 = new Matrix( new Size(4, 4));
            m1.SetMine(new(1,1));
            m1.Open(new (1,1)).Value.Should().Be('*');
        }

    }
}