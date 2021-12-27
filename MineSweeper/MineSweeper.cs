using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    public class MineSweeper
    {
        public bool HasLose { get; private set; }
        public bool HasWin { get; private set; }

        private readonly int _numMines;
        private readonly Matrix _matrix;
        private readonly Matrix _showedMatrix;

        public MineSweeper(Matrix matrix, int numMines)
        {
            (_matrix, _numMines) = (matrix, numMines);
            
            _showedMatrix = new Matrix(_matrix.Width, _matrix.Height);
            SetMines();
        }
        

        private void SetMines()
        {
            HashSet<Coordinate> minesSet = new HashSet<Coordinate>();
            Random rnd = new Random();

            while (minesSet.Count != _numMines)
                minesSet.Add(new Coordinate(
                    rnd.Next(0, _matrix.Width), 
                    rnd.Next(0, _matrix.Height))
                );

            foreach (Coordinate coordinate in minesSet)
                _matrix.SetMine(coordinate);
        }

        public void Open(Coordinate coordinate)
        {
            if (_matrix.At(coordinate).Value == '*')
                HasLose = true;

            UpdateMatrix(coordinate);
            HasWin = PlayerHasWin();
        }

        private void UpdateMatrix(Coordinate coordinate)
        {
            int numOfMines = _matrix.NeighborsOf(coordinate).Count(cell => cell.Value == '*');
            _matrix.ChangeValue(coordinate, char.Parse(numOfMines.ToString()));
        }

        private bool PlayerHasWin()
        {
            for (int x = 0; x < _matrix.Width -1; x++)
                for (int y = 0; y < _matrix.Height -1; y++)
                    if (_matrix.At(new(x,y)).Value == '.')
                        return false;

            return true;
        }

        public String PrintMatrix()
        {
            string temp = "";
            for (int x = 0; x < _matrix.Width; x++)
            {
                for (int y = 0; y < _matrix.Height; y++)
                {
                    temp += _matrix.At(new Coordinate(x, y)).Value == '*' 
                        ? '.' 
                        : _matrix.At(new Coordinate(x, y)).Value;
                }
                temp += '\n';
            }

            return temp;
        }
    }
}