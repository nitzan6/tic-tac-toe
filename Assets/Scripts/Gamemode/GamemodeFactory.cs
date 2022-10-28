using System;
using System.Linq;
using System.Reflection;
using TicTacToe.GameManagement.Gamemodes;
using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagment
{
    public static class GamemodeFactory
    {
        private static Type[] _playerTypes = Assembly.GetAssembly(typeof(IPlayer)).GetTypes()
                .Where(type => type.IsClass && typeof(IPlayer).IsAssignableFrom(type))
                .ToArray();

        public static Type[] GetPlayersFromGamemode(IGamemode<IPlayer, IPlayer> gamemode)
        {
            Type[] currentGamemodePlayerTypes = new Type[2];

            currentGamemodePlayerTypes = _playerTypes.Where(type => (Type)gamemode.Player1 == type && (Type)gamemode.Player2 == type).ToArray();

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

            return _playerTypes;
        }
    }
}

