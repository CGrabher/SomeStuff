using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fakultät
{
    internal class Faculty_Loop
    {
        public ulong FacultyLoop(ulong num)
        {
            if (num == 0)
            {
                return 1;
            }
            else
            {
                try
                {
                    checked
                    {
                        for (ulong i = num - 1; i > 0; i--)
                        {
                            Console.Write(num + "*" + i + " = ");
                            num = num * i;
                            Console.Write(num + "\n");
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
}
