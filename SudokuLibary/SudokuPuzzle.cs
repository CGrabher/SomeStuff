namespace SudokuLibary
{
    public class SudokuPuzzle
    {
        private readonly int[,] _puzzle;
        public static event Action<string> OnErrorOccured = delegate { };

        public SudokuPuzzle()
        {
            _puzzle = new int[9, 9];
        }

        public int GetSpotValue(int x, int y)
        {
            return _puzzle[x, y];
        }

        public void SetSpotValue(int x, int y, int value)
        {
            try
            {
                if (value < 1 || value > 9)
                    throw new ArgumentOutOfRangeException(nameof(value));

                if (!CheckIfValueIsValid(_puzzle, x, y, value))
                {
                    string errorMessage = $"The number {value} you set at position Row: {x} Column: {y}  do not match the sudoku rules";
                    
                    throw new Exception(errorMessage);
                }
                _puzzle[x, y] = value;
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex.Message);
                
            }
        }

        public bool TrySolve()
        {
            var (x, y) = FindNextEmptyField();

            if (x == -1 && y == -1)
                return true;

            for (int num = 1; num <= 9; num++)
            {
                if (CheckIfValueIsValid(_puzzle, x, y, num))
                {
                    // set num at acutual position
                    SetSpotValue(x, y, num);

                    if (TrySolve())
                        return true;

                    // if the solution not works, try again
                    ResetSpotValue(x, y); //YEEEEESSS!!!!!!!
                }
            }
            //if no valid solution was found
            return false;
        }

        private void ResetSpotValue(int x, int y)
        {
            _puzzle[x, y] = 0;
        }

        private bool UsedInRow(int[,] grid, int x, int num)
        {
            for (int col = 0; col < 9; col++)
            {
                if (grid[x, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInColumn(int[,] grid, int y, int num)
        {
            for (int row = 0; row < 9; row++)
            {
                if (grid[row, y] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInBox(int[,] grid, int boxStartRow, int boxStartCol, int num)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (grid[x + boxStartRow, y + boxStartCol] == num)
                        return true;
                }
            }
            return false;
        }

        private bool CheckIfValueIsValid(int[,] grid, int row, int col, int num)
        {
            return !UsedInRow(grid, row, num) && !UsedInColumn(grid, col, num) && !UsedInBox(grid, row - row % 3, col - col % 3, num);
        }

        private (int x, int y) FindNextEmptyField()
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (GetSpotValue(x, y) == 0)
                    {
                        return (x, y);
                    }
                }
            }
            return (-1, -1);
        }

       
    }
}