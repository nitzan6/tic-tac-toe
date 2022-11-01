using System;
using System.Collections.Generic;
using UnityEngine;

//Singleton for game events
public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    void Awake()
    {
        Instance = this;
    }

    public event Action onGameStart;
    public void GameStart()
    {
        onGameStart?.Invoke();
    }

    public event Action<string> onRolesAssigned;
    public void RolesAssigned(string firstTurnPlayerName)
    {
        onRolesAssigned?.Invoke(firstTurnPlayerName);
    }

    public event Action<enGameState> onGameEnded;
    public void GameEnded(enGameState gameResult)
    {
        onGameEnded?.Invoke(gameResult);
    }

    public event Action<Vector2Int, enSymbol> onMadeMove;
    public void MadeMove(Vector2Int position, enSymbol symbol)
    {
        onMadeMove?.Invoke(position, symbol);
    }

    public event Action<List<Vector2Int>> onUndoLastMove;
    public void UndoLastMove(List<Vector2Int> lastMove)
    {
        onUndoLastMove?.Invoke(lastMove);
    }
}