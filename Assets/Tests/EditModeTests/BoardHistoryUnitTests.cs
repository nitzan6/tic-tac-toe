using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TicTacToe.GameProgression;
using System.Collections.Generic;
using System.Linq;

public class BoardHistoryUnitTests
{
    [Test]
    public void PartiallyFullHistory_RemoveLastMove_ShouldReturnLastMoveSuccessfully()
    {
        //ARRANGE
        BoardHistory boardHistory = GetBoardHistoryPartiallyFull();

        //ACT
        Vector2Int positionX = new Vector2Int(1, 1);
        boardHistory.AddToHistory(positionX);

        List<Vector2Int> removedPositions = boardHistory.GetAndRemoveLastMoves(1);

        //ASSERT
        Assert.AreEqual(removedPositions.First(), positionX);
    }

    [Test]
    public void PartiallyFullHistory_RemoveLastTwoMoves_ShouldReturnLastTwoMovesSuccessfully()
    {
        //ARRANGE
        BoardHistory boardHistory = GetBoardHistoryPartiallyFull();

        //ACT
        Vector2Int positionX = new Vector2Int(0, 0);
        Vector2Int positionO = new Vector2Int(0, 1);
        boardHistory.AddToHistory(positionX);
        boardHistory.AddToHistory(positionO);

        List<Vector2Int> removedPositions = boardHistory.GetAndRemoveLastMoves(2);

        //ASSERT
        Assert.AreEqual(removedPositions.Count, 2);
        Assert.AreEqual(removedPositions.First(), positionO);
        Assert.AreEqual(removedPositions.Last(), positionX);
    }

    [Test]
    public void OneMoveHistory_RemoveLastTwoMoves_ShouldReturnOneMoveSuccessfully()
    {
        //ARRANGE
        BoardHistory boardHistory = GetBoardHistoryEmpty();

        //ACT
        Vector2Int positionX = new Vector2Int(1, 1);
        boardHistory.AddToHistory(positionX);

        List<Vector2Int> removedPositions = boardHistory.GetAndRemoveLastMoves(2);

        //ASSERT
        Assert.AreEqual(removedPositions.Count, 1);
        Assert.AreEqual(removedPositions.First(), positionX);
    }

    [Test]
    public void NoHistory_RemoveOneMove_ShouldReturnNoMovesSuccessfully()
    {
        //ARRANGE
        BoardHistory boardHistory = GetBoardHistoryEmpty();

        //ACT
        List<Vector2Int> removedPositions = boardHistory.GetAndRemoveLastMoves(1);

        //ASSERT
        Assert.IsEmpty(removedPositions);
    }

    private BoardHistory GetBoardHistoryPartiallyFull()
    {
        BoardHistory boardHistory = new BoardHistory();
        Vector2Int positionX = new Vector2Int(1, 2);
        Vector2Int positionO = new Vector2Int(2, 2);

        boardHistory.AddToHistory(positionX);
        boardHistory.AddToHistory(positionO);

        return boardHistory;
    }

    private BoardHistory GetBoardHistoryEmpty()
    {
        return new BoardHistory();
    }
}
