using TicTacToeLibary.Database;

namespace TicTacToeLibary.Services;

public class HighscoreService
{
    public IEnumerable<Highscore> GetHighScoreLastMonth(int amount = 10)
    {
        using var ctx = new TicTacToeDatabaseContext();
        var minimumTimestamp = DateTimeOffset.Now
            .Subtract(TimeSpan.FromDays(30))
            .ToUnixTimeSeconds();
        var relevantResults = ctx.GameResults
            .Where(x => x.Timestamp > minimumTimestamp)
            .ToList();

        var names = relevantResults.Select(x => x.Player1Name).ToList();
        names.AddRange(relevantResults.Select(x => x.Player2Name));
        names = names.Distinct().ToList();

        var highscores = names
            .Select(name =>
                new Highscore(
                    name,
                    relevantResults.Count(x =>
                        (x.Player1Name == name && x.GameState == GameState.Player1Won) ||
                        (x.Player2Name == name && x.GameState == GameState.Player2Won))))
            .OrderByDescending(x => x.Wins)
            .ToList();



        return highscores
            .Take(amount);

        

    }
}

public record Highscore(string Name, int Wins);

