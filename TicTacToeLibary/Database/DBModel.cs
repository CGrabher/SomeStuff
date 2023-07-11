using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLibary.Database
{
    internal class DBModel
    {
        public string? PlayerName { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
