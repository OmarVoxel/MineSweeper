using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper
{
    public record Coordinate (int X, int Y);

    public class Matrix
    {
        private readonly Cell[,] _matrix;
    
        public int Width { get; }
        public int Height { get; }

        public Matrix(int width, int height)
        {
            (Width, Height) = (width, height);
            
            _matrix = new Cell[width, height];
            Initialize();
        }

        private void Initialize()
        { 
            for (int m = 0; m < Width; m++)
                for (int n = 0; n < Height; n++)
                    _matrix[m, n] = new Cell('.');
        }

        public Cell At(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y];
        
        public IEnumerable<Cell> NeighborsOf(Coordinate coord)
        {
            for (int x = Math.Max(coord.X - 1, 0); x <= Math.Min(coord.X + 1, Width - 1); x++)
                for (int y = Math.Max(coord.Y - 1, 0); y <= Math.Min(coord.Y + 1, Height - 1); y++)
                    if ((x,y) != (coord.X, coord.Y)) 
                            yield return At(new Coordinate(x, y));
        }
        
        public void SetMine(Coordinate coordinate) 
            => _matrix[coordinate.X, coordinate.Y] = new Cell('*');

        public void ChangeValue(Coordinate coordinate, char value)
            => _matrix[coordinate.X, coordinate.Y] = new Cell(value);
        
        public Cell Open(Coordinate coordinate)
            => _matrix[coordinate.X, coordinate.Y];
        
        public int CountDots()
            => _matrix.OfType<Cell>().Count(c => c.Value == '.');

        private string CellsAsString()
            => string.Concat(_matrix.OfType<Cell>().Select(c => c.Value));
        
        public override bool Equals(object other)
            => this.CellsAsString().Equals((other as Matrix)?.CellsAsString());
        
        public override int GetHashCode()
            => this.CellsAsString().GetHashCode();
    }
}