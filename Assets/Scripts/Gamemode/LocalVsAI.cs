using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagement.Gamemodes
{
    public class LocalVsAI : IGamemode<LocalPlayer, AI>
    {
        public LocalPlayer Player1 { get; set; }
        public AI Player2 { get; set; }
    }
}

