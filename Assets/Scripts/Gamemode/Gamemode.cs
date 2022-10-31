using System;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagement.Gamemodes
{
    public class Gamemode
    {
        public Gamemode(Type player1Type, Type player2Type)
        {
            if (!typeof(IPlayer).IsAssignableFrom(player1Type) || !typeof(IPlayer).IsAssignableFrom(player2Type))
            {
                throw new Exception("Please only use types that implement the IPlayer interface");
            }

            if (!player1Type.IsClass || !player2Type.IsClass)
            {
                throw new Exception("Please use a class as type, not the interface itself");
            }

            Player1Type = player1Type;
            Player2Type = player2Type;
        }

        public bool IsGameModeVsComputer()
        {
            return Player1Type == typeof(AI) || Player2Type == typeof(AI);
        }

        public readonly Type Player1Type;
        public readonly Type Player2Type;
    }

}
