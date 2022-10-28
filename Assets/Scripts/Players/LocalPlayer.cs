using System;
using TicTacToe.Gameplay.Players;
using UnityEngine;

public class LocalPlayer : MonoBehaviour, IPlayer
{
    public Role Role { get; set; }
    public event Action<int> OnChooseCell;
    
    private void AttemptChooseCell(int cellNumber)
    {
        
    }
}
