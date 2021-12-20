using System;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeper
    {
        public bool HasLose { get; private set; }
        private readonly int _numMines;
        private readonly Matrix _matrix;
        private readonly Size _size;

        public MineSweeper(Matrix matrix, int numMines)
        {
            (_matrix, _numMines) = (matrix, numMines);
            _size = _matrix.GetSize();
            SetMines();
        }
        
        private void SetMines()
        {
            HashSet<Coordinate> minesSet = new HashSet<Coordinate>();
            Random rnd = new Random();

            while (minesSet.Count != _numMines)
                minesSet.Add(new Coordinate(
                    rnd.Next(0, _size.M), 
                    rnd.Next(0, _size.N))
                );

            foreach (Coordinate coordinate in minesSet)
                _matrix.SetMine(coordinate);
        }

        public void Open(Coordinate coordinate)
        {
            if (_matrix.At(coordinate).Value == '*')
                HasLose = true;
        }

        public Matrix PrintMatrix()
        {
            throw new Exception();
        }
    }
}