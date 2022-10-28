using System;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class LocalPlayer : MonoBehaviour, IPlayer
    {
        public Role Role { get; set; }
        public event Action<int> OnChooseCell;

        private void AttemptChooseCell(int cellNumber)
        {

        }
    }

}
