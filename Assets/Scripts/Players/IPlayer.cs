using System;

namespace TicTacToe.GameManagement.Players
{

    //defining the interface for a player
    public interface IPlayer
    {
        // this event will be invoked when the player chooses a valid cell,
        // and will pass the cell number as an argument.
        event Action<int> OnChooseCell;

        // every player is assigned a role, which is either X or O.
        Symbol Role { get; set; }
    }
}
