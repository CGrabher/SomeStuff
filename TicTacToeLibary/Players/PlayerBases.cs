using System.ComponentModel.DataAnnotations.Schema;
using TicTacToeLibary.Database;

namespace TicTacToeLibary.Players
{
    public abstract class Player
    {

        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public char Symbol { get; internal set; }
        [NotMapped]
        public Player? Enemy { get; internal set; }

        public List<GameResult> GameResults { get; } = new List<GameResult>();

        public Player(string name)
        {
            Name = name;
        }


        public static string InitializeDatabase()
        {
            var db = new TicTacToeDatabaseContext();
            db.fillDatabase();
            return db.DbPath;

        }

    }

    public class GameResult
    {
        public int GameResultId { get; set; }
        public int Score { get; set; }
        public DateTime DateTime { get; set; }
    }

    public abstract class BotPlayer : Player
    {
        public BotPlayer(string name) : base(name)
        {

        }
        internal abstract Move GetMove(TicTacToeGame game);
    }
}
