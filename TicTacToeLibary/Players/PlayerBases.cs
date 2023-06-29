namespace TicTacToeLibary.Players
{
    public abstract class Player
    {

        public string Name { get; }
        public char Symbol { get; internal set; }
        public Player? Enemy { get; internal set; }
        public Player(string name)
        {
            Name = name;
        }

    }

    public abstract class BotPlayer : Player
    {
        public BotPlayer(string name) : base(name)
        {

        }
        internal abstract Move GetMove(TicTacToeGame game);
    }
}
