using System;
using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class Board
    {
        public enSymbol[,] Cells { get; private set; }

        public Board(int width, int height)
        {
            Cells = new enSymbol[width, height];
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
                    if (Cells[i,j] != enSymbol.EMPTY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void InsertElement(Vector2Int position, enSymbol element)
        {
            Cells[position.x, position.y] = element;
        }

        public bool IsCellEmpty(Vector2Int position)
        {
            return Cells[position.x, position.y] == enSymbol.EMPTY;
        }

        public enSymbol GetSymbol(Vector2Int position)
        {
            return Cells[position.x, position.y];
        }

        public void ClearCell(Vector2Int position)
        {
            Cells[position.x, position.y] = enSymbol.EMPTY;
        }
    }
}

