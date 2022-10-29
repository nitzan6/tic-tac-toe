using System;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{

    public class PlayerInputEventArgs : EventArgs
    {
        Vector2Int position;
    }

    //defining the interface for a player
    public interface IPlayer
    {
        // this event will be invoked when the player chooses a valid cell,
        // and will pass the cell coordinates as an argument.
        EventHandler<PlayerInputEventArgs> OnChooseCell { get; set; }

        // every player is assigned a role, which is either X or O.
        Symbol Role { get; set; }
    }
}
