using System;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameProgression
{
    public class RoleAssigner
    {
        private Random random;

        public RoleAssigner()
        {
            random = new Random();
        }

        public void AssignRolesForPlayers(IPlayer player1, IPlayer player2)
        {
            //Generate a random number between 1 and 2
            int playerNumberForXSymbol = random.Next(1, 3);

            if (playerNumberForXSymbol == 1)
            {
                player1.Symbol = enSymbol.X;
                player2.Symbol = enSymbol.O;
            }
            else
            {
                player1.Symbol = enSymbol.O;
                player2.Symbol = enSymbol.X;
            }
        }
    }

}
