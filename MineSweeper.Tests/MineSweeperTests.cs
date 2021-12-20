using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class MineSweeperTests
    {

        [Fact]
        public void MatrixFromMatrixIsntTheSameThanMatrixFromMineSweeper()
        {
            Matrix m1 = new(4,4); m1.SetMine(new(1,1));
            Matrix m2 = new(4,4); m2.SetMine(new(1,1));
            Matrix xx = new(4,4); xx.SetMine(new(2, 2));

            m2.Should().Be(m1);
            xx.Should().NotBe(m1);
        }
    }
}