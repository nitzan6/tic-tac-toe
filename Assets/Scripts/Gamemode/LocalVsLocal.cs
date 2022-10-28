using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagement.Gamemodes
{
    public class LocalVsLocal : IGamemode<LocalPlayer, LocalPlayer>
    {
        public LocalPlayer Player1 { get; set; }
        public LocalPlayer Player2 { get; set; }
    }

}
