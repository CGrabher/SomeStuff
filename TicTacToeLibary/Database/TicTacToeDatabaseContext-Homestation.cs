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
    }
}
