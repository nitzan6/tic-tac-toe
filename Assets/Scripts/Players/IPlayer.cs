using System;
using TicTacToe.GameProgression;

namespace TicTacToe.GameManagement.Players
{

    //defining the interface for a player
    public interface IPlayer
    {
        // this event will be invoked when the player chooses a valid cell,
        // and will pass the cell coordinates as an argument.
        event Action<UnityEngine.Vector2Int, enSymbol> OnChooseMove;

        //For getting notified on the current turn - whose turn it is
        public void ReceiveCurrentTurnInfo(enSymbol currentTurnSymbol);

        //The player name
        string Name { get; set; }

        //A reference to the game board for move validations
        Board GameBoard { get; set; }

        // every player is assigned a symbol, which is either X or O.
        enSymbol Symbol { get; set; }
    }
}
