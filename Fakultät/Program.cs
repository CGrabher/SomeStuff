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

            ulong n = 42;
            var watchOne = new Stopwatch();
            watchOne.Start();
            for (ulong i = 0; i <= n; i++)
            {
                var watchTwo = Stopwatch.StartNew(); // Startzeit aufzeichnen
                ulong result = f.Fibonacci_sequence_recursive(i);
                watchTwo.Stop(); // Endzeit aufzeichnen
                Console.WriteLine($"{i} -> {result}. Elapsed Time {watchTwo.ElapsedMilliseconds} ms.");
            }
            watchOne.Stop();
            Console.WriteLine($"Elapsed Time for the whole Calculation WIHOUT Memoization was {watchOne.Elapsed} \n");




            ulong c = 42;
            var watchOneX = new Stopwatch();
            watchOneX.Start();
            for (ulong i = 0; i <= c; i++)
            {
                var watchTwoX = Stopwatch.StartNew(); // Startzeit aufzeichnen
                ulong result = f.Fibonacci_Memo_sequence_recursive(i);
                watchTwoX.Stop(); // Endzeit aufzeichnen
                Console.WriteLine($"{i} -> {result}. Elapsed Time {watchTwoX.ElapsedMilliseconds} ms.");
            }
            watchOneX.Stop();
            Console.WriteLine($"Elapsed Time for the whole Calculation WITH Memoization was {watchOneX.Elapsed} ");

            //f.Fibonacci_Memo_sequence_recursive(10);
        }
    }
}

