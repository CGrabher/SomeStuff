﻿using System.ComponentModel.DataAnnotations.Schema;
using TicTacToeLibary.Database;

namespace TicTacToeLibary.Players
{
    public abstract class Player
    {
        public string Name { get; set; }
        public char Symbol { get; internal set; }
        public Player? Enemy { get; internal set; }

        public List<GameResult> GameResults { get; } = new List<GameResult>();

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
