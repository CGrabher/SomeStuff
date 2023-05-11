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

        public ulong Fibonacci_sequence_recursive(ulong num)
        {
            if (num <= 2) return 1;
            try
            {
                checked
                {
                    return Fibonacci_sequence_recursive(num - 1) + Fibonacci_sequence_recursive(num - 2);
                }
            }
            catch
            {
                throw new OverflowException("Overflow at num: " + (num + 1));
            }
        }

        public ulong Fibonacci_Memo_sequence_recursive(ulong num)
        {
            return Fibonacci_Memo_sequence_recursive(num, new Dictionary<ulong, ulong>());
        }

        private ulong Fibonacci_Memo_sequence_recursive(ulong num, Dictionary<ulong, ulong> fibNums)
        {           
            //num = 10
            if (num <= 2) return 1;

            if (fibNums.ContainsKey(num))
            {
                return fibNums[num];
            }
            try
            {
                checked
                {
                    //                              9                                           10
                    ulong fibNum = Fibonacci_Memo_sequence_recursive(num - 1, fibNums) + Fibonacci_Memo_sequence_recursive(num - 2, fibNums);
                    fibNums[num] = fibNum;
                    return fibNum;
                }
            }
            catch
            {
                throw new OverflowException("Overflow at num: " + (num));
            }
        }


        //quicky
        //public ulong Fibonacci_Memo_sequence_recursive(ulong num, Dictionary<ulong, ulong>? fibNums = null)
        //{
        //    if (fibNums == null)
        //        fibNums = new Dictionary<ulong, ulong>();

        //    //num = 10
        //    if (num <= 2) return 1;

        //    if (fibNums.ContainsKey(num))
        //    {
        //        return fibNums[num];
        //    }
        //    try
        //    {
        //        checked
        //        {
        //            //                              9                                           10
        //            ulong fibNum = Fibonacci_Memo_sequence_recursive(num - 1, fibNums) + Fibonacci_Memo_sequence_recursive(num - 2, fibNums);
        //            fibNums[num] = fibNum;
        //            return fibNum;
        //        }
        //    }
        //    catch
        //    {
        //        throw new OverflowException("Overflow at num: " + (num));
        //    }
        //}
    }
}
