using FluentAssertions;
using Xunit;

namespace MineSweeper.Tests
{
    public class CellTests
    {
        [Fact]
        public void CellContainsADot()
        {
            Cell cell = new Cell('.');
            cell.Value.Should().Be('.');
        }

        [Fact]
        public void CellContainsAAstheric()
        {
            Cell cell = new Cell('*');
            cell.Value.Should().Be('*');
        }
    }
}