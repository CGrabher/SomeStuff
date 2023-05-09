using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{ 
    internal class Fibonacci
    {
        private int cnt = 1;
        public ulong Fibonacci_sequence (ulong num)
        {

            //1 2 3 5 8 13 21 34

            //i = 0 i = i -1 + i
            //i = 1
            //i = 2 
            //i = 3
            //i = 4
            //i = 5 
            //i = 6
            //i = 7 
            //i = 8
            //i = 9
            //i = 10

            if (num <= 1)
            {
                return num;
            }
            else
            {
                try
                {
                    checked
                    {
                        ulong prev1 = 0;
                        ulong prev2 = 1;
                        ulong result = 0;
                        
                        for (ulong i = 2; i <= num + 1; i++)
                        {
                            result = prev1 + prev2;
                            prev1 = prev2;
                            prev2 = result;
                            Console.WriteLine(cnt + ". - " + result);
                            cnt++;
                        }
                        return result;
                    }
                }
                catch
                {
                    throw new OverflowException("Overflow at num: " + cnt);
                }
            }
        }
    }
}
