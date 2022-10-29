using System;
using System.Linq;
using System.Reflection;
using TicTacToe.GameManagement.Gamemodes;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagment.Setup
{
    public static class PlayerFactory
    {
        private static Type[] _playerTypes = Assembly.GetAssembly(typeof(IPlayer)).GetTypes()
                .Where(type => type.IsClass && typeof(IPlayer).IsAssignableFrom(type))
                .ToArray();

        public static Type[] GetPlayersFromGamemode(Gamemode gamemode)
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
            
            //playersTypes[0] = (gamemode.Player1 as LocalPlayer) || (gamemode.Player1 as AI);

            /*
            switch (gamemode)
            {
                case (GameMode.LocalVsAI):
                    playersTypes = new Type[] { typeof(LocalPlayer), typeof(AI) };
                    break;
                case (GameMode.LocalVsLocal):
                    playersTypes = new Type[] { typeof(LocalPlayer), typeof(LocalPlayer) };
                    break;
                default:
                    throw new Exception($"The gamemode {gamemode} is not supported.");
            }
            */
        }
    }
}

