using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    internal class Faculty_Loop
    {
        public ulong FacultyLoop(ulong num)
        {
            if (num == 0)
            {
                return 1;
            }
            
            try
            {
                checked
                {
                    for (ulong i = num - 1; i > 0; i--)
                    {                       
                        num *= i;
                    }
                    return num;
                }
            }
            catch (OverflowException)
            {
                throw new OverflowException("Overflow at num: " + num);
            }
            
        }
    }
}
