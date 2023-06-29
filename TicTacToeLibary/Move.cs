namespace TicTacToeLibary;

public struct Move
{
    public Move(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; }
    public int Y { get; }
}


public struct BotMove
{
    public BotMove(Move move, int value)
    {
        Move = move;
        Value = value;
    }
    public BotMove(int value) : this (new Move(-1, -1), value) { }

    public Move Move { get; }
    public int Value { get; }

    public static implicit operator Move(BotMove m) => m.Move;

}
