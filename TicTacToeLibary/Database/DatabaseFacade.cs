using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeLibary.Players;

namespace TicTacToeLibary.Database;

public class DatabaseFacade
{
    // - Add-Migration InitialCreate
    //
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


    /// <summary>
    /// adds 10 random players with 25-50 random games
    /// </summary>
    public void fillDatabase()
    {
        var scores = new int[] { 0, 5, 10 };
        var random = new Random();
        for (int i = 0; i < 10; i++)
        {

            var newPlayer = new HumanPlayer("Player" + i);

            var numberOfGames = random.Next(25, 50);
            for (int j = 0; j < numberOfGames; j++)
            {
                var gr = new GameResult();
                gr.Score = scores[random.Next(3)];

                // guess random time in last 3 months (~ 6.5 mio seconds)
                gr.DateTime = DateTime.Now.Subtract(new TimeSpan(0, 0, random.Next(5000, 6_500_000)));
                newPlayer.GameResults.Add(gr);
                gr.Player = newPlayer;
            }

            context.Add(newPlayer);
        }
        context.SaveChanges();
    }

}
