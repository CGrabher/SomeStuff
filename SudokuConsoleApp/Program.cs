using SudokuLibary;
using System.Diagnostics;

namespace SudokuConsoleApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            var puzzle = new SudokuPuzzle();
            FillExample(puzzle);
            PrintPuzzle(puzzle);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress key to start solving...");
            Console.ResetColor();
            Console.ReadKey();

            sw.Start();

            puzzle.TrySolve();

            sw.Stop();
            PrintPuzzle(puzzle);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nIt took {sw.ElapsedMilliseconds} ms to solve the puzzle");
            Console.ResetColor();
            Console.ReadKey();
        }

        private static void FillExample(SudokuPuzzle puzzle)
        {
            //ROW 1
            puzzle.SetSpotValue(1, 0, 3);

            /*puzzle.SetSpotValue(5, 0, 3); *///Test

            //ROW 2
            puzzle.SetSpotValue(3, 1, 1);
            puzzle.SetSpotValue(4, 1, 9);
            puzzle.SetSpotValue(5, 1, 5);

            //ROW 3
            puzzle.SetSpotValue(2, 2, 8);
            puzzle.SetSpotValue(7, 2, 6);

            //ROW 4
            puzzle.SetSpotValue(0, 3, 8);
            puzzle.SetSpotValue(4, 3, 6);

            //ROW 5
            puzzle.SetSpotValue(0, 4, 4);
            puzzle.SetSpotValue(3, 4, 8);
            puzzle.SetSpotValue(8, 4, 1);

            //ROW 6
            puzzle.SetSpotValue(4, 5, 2);

            //ROW 7
            puzzle.SetSpotValue(1, 6, 6);
            puzzle.SetSpotValue(6, 6, 2);
            puzzle.SetSpotValue(7, 6, 8);

            //ROW 8
            puzzle.SetSpotValue(3, 7, 4);
            puzzle.SetSpotValue(4, 7, 1);
            puzzle.SetSpotValue(5, 7, 9);
            puzzle.SetSpotValue(8, 7, 5);

            //ROW 9
            puzzle.SetSpotValue(7, 8, 7);
        }

        public static void PrintPuzzle(SudokuPuzzle puzzle)
        {
            Console.Clear();
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    var value = puzzle.GetSpotValue(x, y);
                    var text = value == 0
                        ? " "
                        : value.ToString();
                    Console.Write($" {text} ");

                    if (x % 3 == 2 && x != 8)
                    {
                        Console.Write(" | ");
                    }
                }
                Console.WriteLine();
                if (y % 3 == 2 && y != 8)
                {
                    Console.WriteLine("---------------------------------");
                }
            }
        }
    }
}