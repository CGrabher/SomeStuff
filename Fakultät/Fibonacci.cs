using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{ 
    internal class Fibonacci
    {
        public ulong Fibonacci_sequence(ulong num)
        {
            if (num == 0)
            {
                Console.WriteLine("0");
                return 0;
            }
            
            if (num == 1)
            {
                Console.WriteLine("1");
                return 1;
            }

            try
            {
                checked
                {
                    ulong prev1 = 1;
                    ulong prev2 = 1;
                    ulong result = 0;

                    for (ulong i = 3; i <= num + 1; i++)
                    {
                        result = prev1 + prev2;
                        prev1 = prev2;
                        prev2 = result;
                    }
                    return result;
                }
            }
            catch
            {
                throw new OverflowException("Overflow at num: " + (num + 1));
            }
            
        }


    }
}
