namespace MineSweeper
{
    public class Matrix
    {
        private readonly int _N;
        private readonly int _M;
        private Cell[,] _matrix;
        private const char InitValue = '.';

        public Matrix(int m, int n)
        {
            (_M, _N) = (m, n);
            _matrix = new Cell[_M, _N];
            Initialize();
        }

        private void Initialize()
        { 
            for (int m = 0; m < _M; m++)
                for (int n = 0; n < _N; n++)
                    _matrix[m, n] = new Cell(InitValue);
        }

        public Cell At(int x, int y) => _matrix[x, y];
    }
}