using System;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameSetup
{
    public class Gamemode
    {
        public Gamemode(Type player1Type, Type player2Type)
        {
            //Check if the given types implement the IPlayer interface
            if (!typeof(IPlayer).IsAssignableFrom(player1Type) || !typeof(IPlayer).IsAssignableFrom(player2Type))
            {
                throw new Exception("[GameMode] - Unsupported type. Please only use types that implement the IPlayer interface");
            }

            //Check to see that the given types are implementations of the interface, not the interface itself
            if (!player1Type.IsClass || !player2Type.IsClass)
            {
                throw new Exception("[GameMode] - Please an implementation of IPlayer instead of the interface itself");
            }

            Player1Type = player1Type;
            Player2Type = player2Type;
        }

        public readonly Type Player1Type;
        public readonly Type Player2Type;
    }

}
