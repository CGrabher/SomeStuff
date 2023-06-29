namespace TicTacToeLibary.Players.Bots
{
    public class BobBot : BotPlayer
    {
        Random _random;
        public BobBot()
            : base("Bob")
        {
            _random = new Random();
        }

        internal override Move GetMove(TicTacToeGame game)
        {
            var moves = game.GetPossibleMoves();
            var result = moves[_random.Next(0, moves.Count)];
            return result;
        }
    }
}
