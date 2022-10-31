using System;
using System.Linq;
using System.Reflection;
using TicTacToe.GameManagement.Gamemodes;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagment.Setup
{
    public static class PlayerFactory
    {
        //Here I am getting all types which implement the IPlayer interface using reflection
        //Excluding the interface itself
        private static Type[] _playerTypes = Assembly.GetAssembly(typeof(IPlayer)).GetTypes()
                .Where(type => type.IsClass && typeof(IPlayer).IsAssignableFrom(type))
                .ToArray();

        public static Type[] GetPlayerTypesFromGamemode(Gamemode gamemode)
        {
            Type[] gamemodePlayerTypes = new Type[2];

            foreach (Type type in _playerTypes)
            {
                if (gamemode.Player1Type == type)
                {
                    gamemodePlayerTypes[0] = type;
                }

                if (gamemode.Player2Type == type)
                {
                    gamemodePlayerTypes[1] = type;
                }
            }

            return gamemodePlayerTypes;
        }
    }
}

