namespace TicTacToe.GameProgression
{
    public class Referee
    {
        //Return the winning symbol, return empty if there is no winner
        public enSymbol GetWinner(enSymbol[,] boardCells)
        {
            //vertical winner check
            for (int i = 0; i < boardCells.GetLength(0); i++)
            {
                if (boardCells[i,0] != enSymbol.EMPTY && boardCells[i, 0] == boardCells[i, 1] && boardCells[i,0] == boardCells[i,2])
                {
                    return boardCells[i, 0];
                }
            }

            //horizontal winner check
            for (int i = 0; i < boardCells.GetLength(1); i++)
            {
                if (boardCells[0, i] != enSymbol.EMPTY && boardCells[0, i] == boardCells[1, i] && boardCells[0, i] == boardCells[2, i])
                {
                    return boardCells[0, i];
                }
            }

            //diagonals winner check
            if (boardCells[0, 0] != enSymbol.EMPTY && boardCells[0, 0] == boardCells[1, 1] && boardCells[0, 0] == boardCells[2, 2])
            {
                return boardCells[0, 0];
            }
            
            if (boardCells[2, 0] != enSymbol.EMPTY && boardCells[2, 0] == boardCells[1, 1] && boardCells[2, 0] == boardCells[0, 2])
            {
                return boardCells[2, 0];
            }

            return enSymbol.EMPTY;
        }

        public bool CheckDraw(enSymbol[,] boardCells)
        {
            for (int i = 0; i < boardCells.GetLength(0); i++)
            {
                for (int j = 0; j < boardCells.GetLength(1); j++)
                {
                    if (boardCells[i, j] == enSymbol.EMPTY)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

    }

}

