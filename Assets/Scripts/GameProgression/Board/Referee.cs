using UnityEngine;

namespace TicTacToe.GameProgression
{
    public class Referee
    {
        public Referee()
        {

        }

        public BoardState CheckBoard(Board board)
        {
            return BoardState.PLAYING;
        }

    }

}

