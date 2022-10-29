using System;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class Board
    {
        private Symbol[,] _cells { get; set; }

        public Board(int width, int height)
        {
            _cells = new Symbol[width, height];
        }

        public Board(Symbol[,] cells)
        {
            _cells = cells;
        }

        public bool IsBoardEmpty()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    if (_cells[i,j] != Symbol.EMPTY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void InsertElement(Vector2Int position, Symbol element)
        {
            _cells[position.x, position.y] = element;
        }

        public bool IsCellEmpty(Vector2Int position)
        {
            return _cells[position.x, position.y] == Symbol.EMPTY;
        }

        public void Clear()
        {
            for (int i = 0; i < _cells.GetLength(0); i++)
            {
                for (int j = 0; j < _cells.GetLength(1); j++)
                {
                    _cells[i, j] = Symbol.EMPTY;
                }
            }
        }
    }
}

