namespace MineSweeper
{
    public struct Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
            => (X, Y) = (x, y);
    }

    public class Matrix
    {
        private readonly Coordinate _coordinate;
        private readonly Cell[,] _matrix;
        private const char InitValue = '.';

        public Matrix(Coordinate coordinate)
        {
            _coordinate = coordinate;
            _matrix = new Cell[coordinate.X, coordinate.Y];
            Initialize();
        }

        private void Initialize()
        { 
            for (int m = 0; m < _coordinate.X; m++)
                for (int n = 0; n < _coordinate.Y; n++)
                    _matrix[m, n] = new Cell(InitValue);
        }

        public Cell At(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y];
    }
}