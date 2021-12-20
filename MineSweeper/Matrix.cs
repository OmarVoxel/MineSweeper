using System.Linq;

namespace MineSweeper
{
    public record Coordinate (int X, int Y);

    public record Size(int M, int N);

    public class Matrix
    {
        private readonly Size _size;
        private readonly Cell[,] _matrix;
        private const char InitValue = '.';

        public Matrix(Size size)
        {
            _size = size;
            _matrix = new Cell[size.M, size.N];
            Initialize();
        }

        private void Initialize()
        { 
            for (int m = 0; m < _size.M; m++)
                for (int n = 0; n < _size.N; n++)
                    _matrix[m, n] = new Cell(InitValue);
        }

        public Size GetSize()
            => _size;
        public Cell At(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y];
        
        public void SetMine(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y] = new Cell('*');
        
        public Cell Open(Coordinate coordinate)
            => _matrix[coordinate.X, coordinate.Y];

        private string CellsAsString()
            => string.Concat(_matrix.OfType<Cell>().Select(c => c.Value));
        
        public override bool Equals(object other)
            => this.CellsAsString().Equals((other as Matrix)?.CellsAsString());
        
        public override int GetHashCode()
            => this.CellsAsString().GetHashCode();
    }
}