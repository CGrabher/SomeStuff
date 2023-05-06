using System.Threading.Tasks.Sources;

namespace Fakultät

{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Faculty_Loop x = new Faculty_Loop();

            //x.FacultyLoop(30);
            

            Faculty_Recursive y = new Faculty_Recursive();

            Console.WriteLine(y.FacultyRecursive(25));
        }
    }
}