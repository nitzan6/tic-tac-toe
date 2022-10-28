using System;
using TicTacToe.Gameplay.Players;
using UnityEngine;

public class AI : MonoBehaviour, IPlayer
{
    public event Action<int> OnGetMove;
}
