using NUnit.Framework;
using TicTacToe.GameProgression;
using UnityEngine;
using UnityEngine.TestTools;

public class RefereeUnitTests
{
    [Test]
    public void WinningBoardForX_XWinsAntiDiagonal_ShouldDetermineXAsWinner()
    {
        //ARRANGE
        enSymbol[,] xWinBoard = GetAntiDiagonalWinningBoard(enSymbol.X);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(xWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.X);
    }

    [Test]
    public void WinningBoardForX_XWinsDiagonal_ShouldDetermineXAsWinner()
    {
        //ARRANGE
        enSymbol[,] xWinBoard = GetDiagonalWinningBoard(enSymbol.X);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(xWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.X);
    }

    [Test]
    public void WinningBoardForX_XWinsHorizontal_ShouldDetermineXAsWinner()
    {
        //ARRANGE
        enSymbol[,] xWinBoard = GetHorizontalWinningBoard(enSymbol.X);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(xWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.X);
    }

    [Test]
    public void WinningBoardForX_XWinsVertical_ShouldDetermineXAsWinner()
    {
        //ARRANGE
        enSymbol[,] xWinBoard = GetVerticalWinningBoard(enSymbol.X);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(xWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.X);
    }

    [Test]
    public void WinningBoardForO_OWinsAntiDiagonal_ShouldDetermineOAsWinner()
    {
        //ARRANGE
        enSymbol[,] oWinBoard = GetAntiDiagonalWinningBoard(enSymbol.O);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(oWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.O);
    }

    [Test]
    public void WinningBoardForO_OWinsDiagonal_ShouldDetermineOAsWinner()
    {
        //ARRANGE
        enSymbol[,] oWinBoard = GetDiagonalWinningBoard(enSymbol.O);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(oWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.O);
    }

    [Test]
    public void WinningBoardForO_OWinsHorizontal_ShouldDetermineOAsWinner()
    {
        //ARRANGE
        enSymbol[,] oWinBoard = GetHorizontalWinningBoard(enSymbol.O);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(oWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.O);
    }

    [Test]
    public void WinningBoardForO_OWinsVertical_ShouldDetermineOAsWinner()
    {
        //ARRANGE
        enSymbol[,] oWinBoard = GetVerticalWinningBoard(enSymbol.O);
        Referee referee = new Referee();

        //ACT
        enSymbol winner = referee.GetWinner(oWinBoard);

        //ASSERT
        Assert.AreEqual(winner, enSymbol.O);
    }

    [Test]
    public void DrawBoard_GameEndedInDraw_ShouldDetermineNoWinner()
    {
        //ARRANGE
        enSymbol[,] drawBoard = GetDrawBoard();
        Referee referee = new Referee();

        //ACT
        bool isDraw = referee.CheckDraw(drawBoard);

        //ASSERT
        Assert.IsTrue(isDraw);
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

    private enSymbol[,] GetPartiallyFullNoWinnersBoard()
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = enSymbol.X;
        cells[1, 0] = enSymbol.O;
        cells[1, 2] = enSymbol.X;

        return cells;
    }

    //There are two diagonal lines on the board, bottom left to top right and top left to bottom right
    //For this reason there are DiagonalWinningBoard and AntiDiagonalWinningBoard to test both diagonal lines
    private enSymbol[,] GetDiagonalWinningBoard(enSymbol winningSymbol)
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = winningSymbol;
        cells[1, 1] = winningSymbol;
        cells[2, 2] = winningSymbol;

        return cells;
    }

    private enSymbol[,] GetAntiDiagonalWinningBoard(enSymbol winningSymbol)
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 2] = winningSymbol;
        cells[1, 1] = winningSymbol;
        cells[2, 0] = winningSymbol;

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

    private enSymbol[,] GetDrawBoard()
    {
        enSymbol[,] cells = new enSymbol[Consts.BOARD_WIDTH, Consts.BOARD_HEIGHT];

        cells[0, 0] = enSymbol.X;
        cells[1, 0] = enSymbol.O;
        cells[2, 0] = enSymbol.X;
        cells[0, 1] = enSymbol.O;
        cells[1, 1] = enSymbol.X;
        cells[2, 1] = enSymbol.X;
        cells[0, 2] = enSymbol.O;
        cells[1, 2] = enSymbol.X;
        cells[2, 2] = enSymbol.O;

        return cells;
    }
}
