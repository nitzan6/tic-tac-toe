using System;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class Board
    {
        public Symbol[,] Cells { get; private set; }

        public Board(int width, int height)
        {
            Cells = new Symbol[width, height];
        }

        public Board(Symbol[,] cells)
        {
            Cells = cells;
        }

        public Vector2Int GetBounds()
        {
            return new Vector2Int(Cells.GetLength(0), Cells.GetLength(1));
        }

        public bool IsBoardEmpty()
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    if (Cells[i,j] != Symbol.EMPTY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void InsertElement(Vector2Int position, Symbol element)
        {
            Cells[position.x, position.y] = element;
        }

        public bool IsCellEmpty(Vector2Int position)
        {
            return Cells[position.x, position.y] == Symbol.EMPTY;
        }

        public Symbol GetSymbol(Vector2Int position)
        {
            return Cells[position.x, position.y];
        }

        public void ClearCell(Vector2Int position)
        {
            Cells[position.x, position.y] = Symbol.EMPTY;
        }
    }
}

