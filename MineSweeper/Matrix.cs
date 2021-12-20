using System.Linq;

namespace MineSweeper
{
    public record Coordinate (int X, int Y);
    
    public class Matrix
    {
        private readonly int _M, _N;
        private readonly Cell[,] _matrix;
        private const char InitValue = '.';

        public Matrix(int m,  int n)
        {
            (_M, _N) = (m, n);
            _matrix = new Cell[m, n];
            Initialize();
        }

        private void Initialize()
        { 
            for (int m = 0; m < _M; m++)
                for (int n = 0; n < _N; n++)
                    _matrix[m, n] = new Cell(InitValue);
        }

        public Cell At(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y];
        
        public void SetMine(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y] = new Cell('*');

        private string CellsAsString()
            => string.Concat(_matrix.OfType<Cell>().Select(c => c.Value));
        
        public override bool Equals(object other)
            => this.CellsAsString().Equals((other as Matrix)?.CellsAsString());
        
        public override int GetHashCode()
            => this.CellsAsString().GetHashCode();
    }
}