using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibary.Database
{
    internal class PlayerModel : DbContext
    {
        public DbSet<PlayerModel> Players { get; set; }

        //string dbPath = "C:\\Users\\Clemens Grabher\\AppData\\HighScoreDB";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
             => options.UseSqlite("Data Source=C:\\Users\\Clemens Grabher\\AppData\\HighScore.db");


    }
}
