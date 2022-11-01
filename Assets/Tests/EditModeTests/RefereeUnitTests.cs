using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TicTacToe.GameProgression;
using UnityEngine;
using UnityEngine.TestTools;

public class RefereeUnitTests
{
    [Test]
    public void WinningBoardForX_ShouldDetermineXAsWinner()
    {

    }

    [Test]
    public void WinningBoardForO_ShouldDetermineOAsWinner()
    {
        
    }

    [Test]
    public void DrawBoard_ShouldDetermineXAsWinner()
    {
        
    }

    [Test]
    public void PartiallyFullBoardWithoutWinner_ShouldDetermineNoWinners()
    {
        //ARRANGE
        enSymbol[,] noWinnersBoard = GetPartiallyFullNoWinnersBoard();
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(noWinnersBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.EMPTY);
    }

    [Test]
    public void PartiallyFullBoardWithoutWinner_ShouldDetermineXAsWinner()
    {
        //ARRANGE
        enSymbol[,] noWinnersBoard = GetPartiallyFullNoWinnersBoard();
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(noWinnersBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.X);
    }

    private enSymbol[,] GetPartiallyFullNoWinnersBoard()
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = enSymbol.X;
        cells[1, 0] = enSymbol.O;
        cells[1, 2] = enSymbol.X;

        return cells;
    }

    private enSymbol[,] GetXWinningBoard()
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = enSymbol.X;
        cells[1, 1] = enSymbol.X;
        cells[2, 2] = enSymbol.X;

        return cells;
    }

    private enSymbol[,] GetDiagonalWinningBoard(enSymbol symbol)
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = symbol;
        cells[1, 1] = symbol;
        cells[2, 2] = symbol;

        return cells;
    }

    private enSymbol[,] GetHorizontalWinningBoard(enSymbol symbol)
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = symbol;
        cells[1, 0] = symbol;
        cells[2, 0] = symbol;

        return cells;
    }

    private enSymbol[,] GetVerticalWinningBoard(enSymbol symbol)
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = symbol;
        cells[0, 1] = symbol;
        cells[0, 2] = symbol;

        return cells;
    }
}
