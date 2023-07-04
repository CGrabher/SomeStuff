namespace TicTacToeLibary.Players.Bots
{
    public class MiniMax : BotPlayer
    {
        Random _random;
        public MiniMax() : base("Max")
        {
            _random = new Random();
        }

        internal override Move GetMove(TicTacToeGame game)
        {
            return GetBestMove((char[,])game.Board.Clone(), game.CurrentPlayer!);
        }
 
        private BotMove GetBestMove(char[,] board, Player current)
        {

            int gameStatus = TicTacToeGame.CheckForWin(board);
            switch (gameStatus)
            {
                case 1:
                    return new BotMove(-1);
                case 2:
                    return new BotMove(1);
                case 0:
                    return new BotMove(0);
            }

            var moves = new List<BotMove>();
            foreach (var m in TicTacToeGame.GetPossibleMoves(board))
            {
                board[m.Y, m.X] = current.Symbol;
                var value = GetBestMove(board, current.Enemy!).Value;
                moves.Add(new BotMove(m, value));
                board[m.Y, m.X] = default;
            }


            var chosenValue = current.Symbol == 'O'
                ? moves.Max(x => x.Value)
                : moves.Min(x => x.Value);
            moves.RemoveAll(x => x.Value != chosenValue);
            return moves[_random.Next(moves.Count)];

        }


        //internal override Move GetMove(TicTacToeGame game)
        //{
            //int bestScore = int.MinValue; 
            //Move bestMove = new Move(-1, -1); 

            //// alle möglichen Zühe im aktuellen Spielstatus
            //foreach (var move in game.GetPossibleMoves())
            //{
            //    //das aktuelle Game wird geklont und anschliessend der Spielzug ausgeführt.
            //    //Danach wird dieser Zug bzw. der daraus resultierende mögliche Spielverlauf durch den Minimax bewertet
            //    var clonedGame = game.Clone();
            //    clonedGame.UpdateBoard(move); 
            //    int score = Minimax(clonedGame, 0, false); 
            //    //Wenn der Score des Zugs besser ist wrid er als bestMove gespeichert.
            //    if (score > bestScore)
            //    {
            //        bestScore = score;
            //        bestMove = move;
            //    }
            //}
            ////Wenn alle möglichen Züge durchlaufen wurden gebe ich den best Move zurück.
            //return bestMove;  
        //}


        //private int Minimax(TicTacToeGame game, bool isMaximizing)
        //{
        //    //Ich prüfe ob das Spiel noch läuft -1 für Niederlage, 1 Gewinn, 0 draw
        //    int gameStatus = TicTacToeGame.CheckForWin(game.Board);

        //    if (gameStatus == 1)
        //        return -1;

        //    else if (gameStatus == 2)
        //        return 1;

        //    else if (gameStatus == 0)
        //        return 0;


        //    if (isMaximizing) // Mr. MiniMax
        //    {
        //        int bestScore = int.MinValue;
        //        foreach (var move in game.GetPossibleMoves())
        //        {
        //            var clonedGame = game.Clone();
        //            clonedGame.UpdateBoard(move);
        //            int score = Minimax(clonedGame, !isMaximizing);

        //            bestScore = Math.Max(score, bestScore);
        //        }

        //        return bestScore;
        //    }
        //    else // Player
        //    {
        //        int bestScore = int.MaxValue;

        //        foreach (var move in game.GetPossibleMoves())

        //        {
        //            var clonedGame = game.Clone();
        //            clonedGame.UpdateBoard(move);
        //            int score = Minimax(clonedGame, !isMaximizing);

        //            bestScore = Math.Min(score, bestScore);
        //        }

        //        return bestScore;
        //    }
        //}

    }
}
