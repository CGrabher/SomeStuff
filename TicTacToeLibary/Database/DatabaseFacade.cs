using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLibary.Players;

namespace TicTacToeLibary.Database;

public class DatabaseFacade
{

    private TicTacToeDatabaseContext context = new TicTacToeDatabaseContext();

    public string getHighScoreOfCurrentMonth()
    {
        var oneMonthAgo = DateTime.Now.Subtract(new TimeSpan(30, 0, 0, 0));



            var allResults = from gr in context.GameResults
                             where gr.DateTime.CompareTo(oneMonthAgo) > 0
                             group gr by gr.Player into playerResults
                             select new
                             {
                                 Name = playerResults.Key.Name,
                                 Score = playerResults.Sum(gr => gr.Score),
                             } into result
                             orderby result.Score descending
                             select result;


            string list = "";

            foreach (var entry in allResults)
            {
                list += $"{entry.Name}\t\t{entry.Score}\n";
            }

            return list;
    }

    /// <summary>
    ///  adds a player with the given name to the database or returns the existing one if he/she already exists
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public Player addPlayerToDatabase(string name)
    {
        var existingPlayer = from player in context.Players
                             where player.Name == name select player;

        var p = existingPlayer.FirstOrDefault();
        if (p == null)
        {
            // new player
            p = new HumanPlayer(name);
            context.Players.Add(p);
            return p;
        }
        else
        {
            return p;
        }
    }

    public void addResultToPlayer(Player p, int score)
    {
        context.Add(new GameResult
        {
            DateTime = DateTime.Now,
            Player = p,
            Score = score,
        });
    }

    public void UpdateDatabase()
    {
        context.SaveChanges();
    }

}
