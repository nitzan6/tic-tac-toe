using System;
using TicTacToe.GameProgression;

namespace TicTacToe.GameManagement.Players
{

    //defining the interface for a player
    public interface IPlayer
    {
        // this event will be invoked when the player chooses a valid cell,
        // and will pass the cell coordinates as an argument.
        event Action<UnityEngine.Vector2Int, Symbol> OnChooseMove;
        public void ReceiveTurnInformation(Symbol currentTurnSymbol);

        // every player is assigned a role, which is either X or O.
        Board GameBoard { get; set; }
        Symbol Symbol { get; set; }
    }
}
