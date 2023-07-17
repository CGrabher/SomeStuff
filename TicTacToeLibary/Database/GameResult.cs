using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToeLibary.Database;

public class GameResult
{
    //ef constructor
    private GameResult() { }
    public GameResult(string player1Name, string player2Name, GameState gameState)
    {
        Player1Name = player1Name;
        Player2Name = player2Name;
        GameState = gameState;
        Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        Timezone  = DateTimeOffset.Now.Offset.TotalHours;
    }

    public int Id { get; set; }
    public string Player1Name { get; set; } = null!;
    public string Player2Name { get; set; } = null!;
    public GameState GameState { get; set; }
    public long Timestamp { get; set; } 
    public double Timezone { get; set; }

    [NotMapped]
    public DateTimeOffset CompletetTimestamp => DateTimeOffset.FromUnixTimeSeconds(Timestamp).ToOffset(TimeSpan.FromHours(Timezone));
}

public enum GameState
{
    Draw = 0,
    Player1Won = 1,
    Player2Won = 2
}
