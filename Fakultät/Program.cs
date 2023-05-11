using Examples;
using System.Diagnostics;
using System.Threading.Tasks.Sources;

namespace Fakultät

{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Faculty
            //Faculty_Loop x = new Faculty_Loop();
            //x.FacultyLoop(15); //max 20

            //Faculty_Recursive y = new Faculty_Recursive();
            //y.FacultyRecursive(15);

            //Fibonacci
            //Fibonacci z = new Fibonacci();
            //z.Fibonacci_sequence(50); //max 92

            Fibonacci_Recursive f = new Fibonacci_Recursive();

            Console.WriteLine("**********************Without Memo**********************");
            ulong n = 43;
            var watchOne = new Stopwatch();
            watchOne.Start();
            for (ulong i = 1; i <= n; i++)
            {
                var watchTwo = Stopwatch.StartNew(); // Startzeit aufzeichnen
                ulong result = f.Fibonacci_sequence_recursive(i);
                watchTwo.Stop(); // Endzeit aufzeichnen
                Console.WriteLine($"{i} -> {result}. Elapsed Time {watchTwo.ElapsedMilliseconds} ms.");
            }
            watchOne.Stop();
            double totalTimeOne = watchOne.ElapsedMilliseconds;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.ResetColor();

            Console.WriteLine("\n**********************With Memo**********************");
            ulong c = 43;
            var watchOneX = new Stopwatch();
            watchOneX.Start();
            for (ulong i = 1; i <= c; i++)
            {
                var watchTwoX = Stopwatch.StartNew(); // Startzeit aufzeichnen
                ulong result = f.Fibonacci_Memo_sequence_recursive(i);
                watchTwoX.Stop(); // Endzeit aufzeichnen
                Console.WriteLine($"{i} -> {result}. Elapsed Time {watchTwoX.ElapsedMilliseconds} ms.");
            }
            watchOneX.Stop();
            double totalTimeTwo = watchOneX.ElapsedMilliseconds;

            double percentFaster = ((totalTimeOne - totalTimeTwo) / totalTimeTwo) * 100;
            double rounded_PrecentFaster = Math.Round(percentFaster, 2);
            string formattedNumber = rounded_PrecentFaster.ToString("#,##0.00");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nWIHOUT MEMOIZATION: Elapsed Time for the whole Calculation was {watchOne.Elapsed} ms\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"WITH MEMOIZATION: Elapsed Time for the whole Calculation WITH Memoization was {watchOneX.Elapsed} ms\n ");
            Console.WriteLine($"---> The Code with Meomization was {formattedNumber} % faster than the Code without!\n");
            Console.ResetColor();

            //f.Fibonacci_Memo_sequence_recursive(10);
        }
    }
}

