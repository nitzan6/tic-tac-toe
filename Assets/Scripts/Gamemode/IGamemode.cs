using TicTacToe.GameManagement.Players;

namespace TicTacToe.GameManagement.Gamemodes
{
    public interface IGamemode<T, U> where T : IPlayer
                                     where U : IPlayer
    {
        public T Player1 { get; set; }
        public U Player2 { get; set; }
    }

}
