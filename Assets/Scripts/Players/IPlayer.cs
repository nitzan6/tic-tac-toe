using System;

namespace TicTacToe.Gameplay.Players
{
    //defining the interface for a player
    public interface IPlayer
    {
        // this event will be invoked when the player chooses a valid cell,
        // and will pass the cell number as an argument.
        event Action<int> OnGetMove;
    }
}