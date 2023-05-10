using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultät
{
    internal class Faculty_Recursive
    {
        public ulong FacultyRecursive(ulong num)
        {
            if (num == 0)
            {
                return 1;
            }
            
            try
            {
                checked
                {
                    return num * FacultyRecursive(num - 1);
                }
            }
            catch (OverflowException)
            {
                throw new OverflowException("Overflow at num: " + num);
            }
            
        }
    }
}
