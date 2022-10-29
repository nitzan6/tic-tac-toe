using System;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class LocalPlayer : MonoBehaviour, IPlayer
    {
        public Symbol Role { get; set; }
        EventHandler<PlayerInputEventArgs> IPlayer.OnChooseCell { get; set; }

        private void AttemptChooseCell(int cellNumber)
        {

        }
    }

}
