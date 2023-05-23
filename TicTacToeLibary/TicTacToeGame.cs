using TicTacToeLibary;

namespace TicTacToeLibary
{
    public class TicTacToeGame
    {
        private char[,] board = new char[3, 3];
        private int currentPlayer = 1; 
        private int totalMoves = 0;

        public TicTacToeGame()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            int cellValue = 1;
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = cellValue.ToString()[0];
                    cellValue++;
                }
            }
        }

        public void Play()
        {
            bool gameActive = true;

            while (gameActive)
            {
                Console.Clear();
                DrawBoard();

                int choice = GetPlayerChoice();

                if (IsValidMove(choice))
                {
                    UpdateBoard(choice);
                    totalMoves++;

                    if (CheckForWin())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Player {0} wins!", currentPlayer);
                        gameActive = false;
                    }
                    else if (totalMoves == 9)
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("It's a draw!");
                        gameActive = false;
                    }
                    else
                    {
                        currentPlayer = (currentPlayer == 1) 
                            ? 2 
                            : 1;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move! Press any key to try again...");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private void DrawBoard()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    Console.Write(" {0} ", board[row, col]);
                    if (col < 2)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (row < 2)
                    Console.WriteLine("---+---+---");
            }
        }

        private int GetPlayerChoice()
        {
            Console.WriteLine("\nPlayer {0}, enter your choice (1-9):", currentPlayer);

            string? input = Console.ReadLine();

            if (input != null && IsNumeric(input))
            {
                return Convert.ToInt32(input);
            }
            else
            {
                return 0;
            }

            //return Convert.ToInt32(Console.ReadLine());
        }

        private bool IsValidMove(int choice)
        {
            int row = (choice - 1) / 3;
            int col = (choice - 1) % 3;

            if (choice < 1 || choice > 9)
                return false;

            if (board[row, col] == 'X' || board[row, col] == 'O')
                return false;

            return true;
        }

        private void UpdateBoard(int choice)
        {
            int position = choice - 1;
            int row = position / 3;
            int col = position % 3;
            board[row, col] = (currentPlayer == 1) 
                ? 'X' 
                : 'O';

            //if (currentPlayer == 1)
            //{
            //    board[row, col] = 'X';
            //}
            //else
            //{
            //    board[row, col] = 'O';
            //}
        }

        private bool CheckForWin()
        {
            // Check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
                    return true;
            }

            // Check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == board[1, col] && board[1, col] == board[2, col])
                    return true;
            }

            // Check diagonals
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;

            return false;
        }

        public static bool IsNumeric(string input)
        {
            double result;
            return double.TryParse(input, out result);
        }

        // Get 0 if O wins
        // Get 2 if X wins
        // Get 1 if draw
        // Get -1 if it not clear at the moment
        public static (int, int) MiniMax()
        {

            return (0, 0);
        }
    }


}
