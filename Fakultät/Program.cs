using Examples;
using System.Threading.Tasks.Sources;

namespace Fakultät

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Faculty_Loop x = new Faculty_Loop();

            x.FacultyLoop(20); //max 20

            Faculty_Recursive y = new Faculty_Recursive();

            Console.WriteLine("Recursive Faculty: " + y.FacultyRecursive(20));

            Fibonacci z = new Fibonacci();

            z.Fibonacci_sequence(92); //max 92
        }
    }
}