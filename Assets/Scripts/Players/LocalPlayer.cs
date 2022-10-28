using System;
using TicTacToe.Gameplay.Players;
using UnityEngine;

public class LocalPlayer : MonoBehaviour, IPlayer
{
    public event Action<int> OnGetMove;
}
