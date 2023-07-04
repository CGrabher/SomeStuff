using System.Diagnostics.CodeAnalysis;
using TicTacToeLibary.Players;

namespace TicTacToeLibary
{
    public class TicTacToeGame
    {

        private char[,] _board = new char[3, 3];
        private Player _player1;
        private Player _player2;

        public TicTacToeGame(Player player1, Player player2)
        {
            _player1 = player1;
            _player1.Symbol = 'X';

            _player2 = player2;
            _player2.Symbol = 'O';

            _player1.Enemy = _player2;
            _player2.Enemy = _player1;

            CurrentPlayer = _player1;
        }

        internal char[,] Board => _board;

        public Player? CurrentPlayer { get; private set; }

        public bool GameOver { get; private set; }

        public Player? Winner { get; private set; }

        public void UndoMove(Move move)
        {
            _board[move.Y, move.X] = default;
        }

        public List<Move> GetPossibleMoves() => GetPossibleMoves(_board);
        internal static List<Move> GetPossibleMoves(char[,] board)
        {
            var result = new List<Move>();

            for (var y = 0; y < 3; y++)
            {
                for (var x = 0; x < 3; x++)
                {
                    if (board[y, x] != 'X' && board[y, x] != 'O')
                    {
                        result.Add(new Move(x, y));
                    }
                }
            }
            return result;

        }

        //public async Task UpdateBoardAsync(Move move)
        //{
        //    bool IsFree(int x, int y) => _board[y, x] is not 'X' and not 'O';

        //    if (GameOver)
        //    {
        //        throw new Exception("Spiel ist bereits vorbei");
        //    }

        //    if (move.X is < 0 or > 2 || move.Y is < 0 or > 2 || !IsFree(move.X, move.Y))
        //    {
        //        throw new Exception("Zug ungültig");
        //    }

        //    if (CurrentPlayer == null)
        //    {
        //        throw new Exception("Aktueller Spieler ist null!");
        //    }

        //    _board[move.Y, move.X] = CurrentPlayer.Symbol;

        //    var status = CheckForWin(_board);

        //    if (status > -1)
        //    {
        //        GameOver = true;
        //        if (status > 0)
        //        {
        //            Winner = CurrentPlayer;
        //        }
        //        CurrentPlayer = null;
        //    }
        //    else
        //    {
        //        CurrentPlayer = CurrentPlayer.Enemy;

        //        if (CurrentPlayer is BotPlayer bot)
        //        {
        //            await Task.Delay(TimeSpan.FromSeconds(1)); 
        //            var botMove = bot.GetMove(this);
        //            await UpdateBoardAsync(botMove);
        //        }
        //    }
        //}




        public void UpdateBoard(Move move)
        {
            bool IsFree(int x, int y) => _board[y, x] is not 'X' and not 'O';
            if (GameOver)
            {
                throw new Exception("Already Game over");
            }

            //if (move.X < 0 || move.X > 2 || move.Y < 0 || move.Y > 2 || !IsFree(move.X, move.Y))
            if (move.X is < 0 or > 2 || move.Y is < 0 or > 2 || !IsFree(move.X, move.Y))
            {
                throw new Exception("Move invalid");
            }

            // _ bedeutet Discard(wegwerfen) und weißt den Current player somit ins leere zu. die beiden Fragezeichen bedeuten, wenn links null ist nimmt er rechts.
            //_ = CurrentPlayer ?? throw new Exception("Already Game over");
            if (CurrentPlayer == null)
            {
                throw new Exception("Current player is null!");
            }
            _board[move.Y, move.X] = CurrentPlayer.Symbol;



            var status = CheckForWin(_board);

            if (status > -1)
            {
                GameOver = true;
                if (status > 0)
                {
                    Winner = CurrentPlayer;
                }
                CurrentPlayer = null;
            }
            else
            {
                CurrentPlayer = CurrentPlayer.Enemy;
                if (CurrentPlayer is BotPlayer bot)
                {
                    var botMove = bot.GetMove(this);
                    UpdateBoard(botMove);
                }
            }
        }


        /// <summary>
        /// Checks the current status of the game
        ///  -1 Game ongoing
        ///  0 Draw
        ///  1 Player1 won
        ///  2 Player2 won
        /// </summary>
        /// <returns></returns>


        internal static int CheckForWin(char[,] board)
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] != default && board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                    return board[row, 0] == 'X' ? 1 : 2;
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] != default && board[0, col] == board[1, col] && board[1, col] == board[2, col])
                    return board[0, col] == 'X' ? 1 : 2;
            }

            // Check diagonals
            if (board[0, 0] != default && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return board[0, 0] == 'X' ? 1 : 2;
            if (board[0, 2] != default && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return board[0, 2] == 'X' ? 1 : 2;


            //if (GetPossibleMoves().Count == 0)
            //    return 0;
            //return -1;
            return GetPossibleMoves(board).Count == 0
                ? 0
                : -1;
        }

        public char GetBoardContent(int x, int y) => _board[y, x];
    }
}
