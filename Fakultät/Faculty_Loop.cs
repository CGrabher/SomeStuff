using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultät
{
    internal class Faculty_Loop
    {
        public decimal FacultyLoop(decimal num)
        {
            for (decimal i = num - 1; i > 0; i--)
            {
                Console.Write(num + "*" + i + " = ");
                num = num * i;
                Console.Write(num + "\n");
            }
            return num;
        }
    }
}
