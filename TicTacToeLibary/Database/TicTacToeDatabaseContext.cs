using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLibary.Players;

namespace TicTacToeLibary.Database
{
    public class TicTacToeDatabaseContext : DbContext
    {
        public DbSet<HumanPlayer> Players { get; set; }
        public DbSet<GameResult> GameResults { get; set; }

        public string DbPath { get; }

        public TicTacToeDatabaseContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "games.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");
            Console.WriteLine($"Data Source={DbPath}");
        }

        /// <summary>
        /// adds 10 random players with 25-50 random games
        /// </summary>
        public void fillDatabase()
        {
            var scores = new int[]{ 0, 5, 10};
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {

                var newPlayer = new HumanPlayer("Player" + i);

                var numberOfGames = random.Next(25, 50); 
                for (int j = 0; j < numberOfGames; j++) {
                    var gr = new GameResult();
                    gr.Score = scores[random.Next(3)];

                    // guess random time in last 3 months (~ 6.5 mio seconds)
                    gr.DateTime = DateTime.Now.Subtract(new TimeSpan(0, 0, random.Next(5000, 6_500_000)));
                    newPlayer.GameResults.Add(gr);
                }

                this.Add(newPlayer);
            }
            this.SaveChanges();
        }
    }
}
