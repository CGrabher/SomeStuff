using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultät
{
    internal class Faculty_Recursive
    {
        public decimal FacultyRecursive(decimal num)
        {
            // Basisfall: Wenn num 0 ist, ist die Fakultät 1
            if (num == 0)
            {
                return 1;
            }
            else
            {
                // Rekursiver Aufruf: Multiplikation der aktuellen Zahl mit der Fakultät der vorherigen Zahl
                return num * FacultyRecursive(num - 1);
            }
        }
    }
}
