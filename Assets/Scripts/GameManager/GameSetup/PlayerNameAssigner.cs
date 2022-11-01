using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameSetup
{
    public class PlayerNameAssigner
    {
        public void AssignNamesToPlayers(IPlayer player1, IPlayer player2)
        {
            player1.Name = player1 is AI ? Consts.COMPUTER_NAME : Consts.PLAYER_1_NAME;
            player2.Name = player2 is AI ? Consts.COMPUTER_NAME : Consts.PLAYER_2_NAME;
        }
    }

}
