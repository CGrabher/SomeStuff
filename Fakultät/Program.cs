namespace Fakultät
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Faculty_Loop x = new Faculty_Loop();

            //x.FacultyLoop(27);

            Faculty_Recursive y = new Faculty_Recursive();

            Console.WriteLine(y.FacultyRecursive(5));
        }
    }
}