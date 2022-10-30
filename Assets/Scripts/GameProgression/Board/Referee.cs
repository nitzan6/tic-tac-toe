using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class Referee
    {
        public BoardState CheckBoardState(Symbol[,] boardCells)
        {
            return BoardState.PLAYING;
        }

    }

}

