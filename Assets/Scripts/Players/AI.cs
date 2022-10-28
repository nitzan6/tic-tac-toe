using System;
using UnityEngine;

namespace TicTacToe.GameManagement.Players
{
    public class AI : MonoBehaviour, IPlayer
    {
        public Role Role { get; set; }
        public event Action<int> OnChooseCell;
    }
}

