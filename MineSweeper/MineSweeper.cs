﻿using System;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeper
    {
        private readonly int _m, _n, _numMines;
        private readonly Matrix _matrix;

        public MineSweeper(int m, int n, int numMines)
        {
            (_m, _n, _numMines) = (m, n, numMines);
            _matrix = new Matrix(m, n);
            SetMines();
        }

        private void SetMines()
        {
            HashSet<Coordinate> minesSet = new HashSet<Coordinate>();
            Random rnd = new Random();

            while (minesSet.Count != _numMines)
                minesSet.Add(new Coordinate(rnd.Next(0, _m), rnd.Next(0, _n)));

            foreach (Coordinate coordinate in minesSet)
                _matrix.SetMine(coordinate);
        } 
    }
}