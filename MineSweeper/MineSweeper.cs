using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
    public class MineSweeper
    {
        public bool HasLose { get; private set; }
        public bool HasWin { get; private set; }
        
        private readonly Matrix _matrix;

        public MineSweeper(Matrix matrix, int numMines)
        {
            _matrix = matrix;
            SetMines(numMines);
        }
        
        private void SetMines(int numMines)
        {
            HashSet<Coordinate> minesSet = new HashSet<Coordinate>();
            Random rnd = new Random();

            while (minesSet.Count != numMines)
                minesSet.Add(new Coordinate(
                    rnd.Next(0, _matrix.Width), 
                    rnd.Next(0, _matrix.Height))
                );

            foreach (Coordinate coordinate in minesSet)
                _matrix.SetMine(coordinate);
        }

        public void Open(Coordinate coordinate)
        {
            PlayerHasLose(coordinate);
            UpdateMatrix(coordinate);
            PlayerHasWin();
        }

        private void PlayerHasLose(Coordinate coordinate)
            => HasLose = _matrix.At(coordinate).Value == '*';

        private void PlayerHasWin()
            => HasWin = _matrix.CountDots() <= 0;

        private void UpdateMatrix(Coordinate coordinate)
        {
            int numOfMines = _matrix.NeighborsOf(coordinate).Count(cell => cell.Value == '*');
            _matrix.ChangeValue(coordinate, char.Parse(numOfMines.ToString()));
        }
        
        public String PrintMatrix()
        {
            StringBuilder temp = new StringBuilder();

            for (int x = 0; x < _matrix.Width; x++)
            {
                for (int y = 0; y < _matrix.Height; y++)
                {
                    temp.Append( _matrix.At(new Coordinate(x, y)).Value == '*' ? '.' : _matrix.At(new Coordinate(x, y)).Value);
                }
                temp.Append('\n');
            }
            return temp.ToString();
        }
    }
}