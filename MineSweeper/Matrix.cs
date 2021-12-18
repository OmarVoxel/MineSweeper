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
        
        // Possible setter? 
        public void SetMine(Coordinate coordinate)
        { 
            // Se esta cambiando el valor de un struct que supuestamente es inmutable????
            //_matrix[coordinate.X, coordinate.Y].Value =  '*';
            // Mejor approach?
            _matrix[coordinate.X, coordinate.Y] = new Cell('*');
        }
    }
}