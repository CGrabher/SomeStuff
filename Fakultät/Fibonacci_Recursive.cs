using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    internal class Fibonacci_Recursive
    {
       Dictionary<ulong, ulong> _fibNums = new Dictionary<ulong, ulong>();
        public ulong Fibonacci_sequence_recursive(ulong num)
        {
            if (num == 0)
            {
                return 0;
            }
            
            if (num == 1)
            {
                return 1;
            }
            return Fibonacci_sequence_recursive(num - 1) + Fibonacci_sequence_recursive(num - 2);
        }

        public ulong Fibonacci_Memo_sequence_recursive(ulong num)
        {
            //num = 10
            if (num == 0)
            {
                return 0;
            }

            if (num == 1)
            {
                return 1;
            }

            if (_fibNums.ContainsKey(num))
            {
                return _fibNums[num];
            }
            //                              9                                           10
            ulong fibNum = Fibonacci_Memo_sequence_recursive(num - 1) + Fibonacci_Memo_sequence_recursive(num - 2);

            _fibNums[num] = fibNum;

            return fibNum;
        }
    }
}
