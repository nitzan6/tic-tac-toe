using System;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class AI : MonoBehaviour, IPlayer
    {
        public Symbol Role { get; set; }
        EventHandler<PlayerInputEventArgs> IPlayer.OnChooseCell { get; set; }


    }
}

