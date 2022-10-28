using System;
using TicTacToe.Gameplay.Players;
using UnityEngine;

public class AI : MonoBehaviour, IPlayer
{
    public Role Role { get; set; }
    public event Action<int> OnChooseCell;
}
