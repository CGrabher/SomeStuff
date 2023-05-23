using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    internal class Collatz_Conjecture_Recursive
    {
        public int[] CollatzSequenceRecursive(int num)
        {
            List<int> sequence = new List<int>();
            ComputeCollatzSequence(num, sequence);
            return sequence.ToArray();
        }

        private void ComputeCollatzSequence(int n, List<int> sequence)
        {
            sequence.Add(n);

            if (n == 1)
                return;

            if (n % 2 == 0)
                ComputeCollatzSequence(n / 2, sequence);
            else
                try
                {
                    checked
                    { ComputeCollatzSequence(3 * n + 1, sequence); }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("Overflow at num: " + n);
                }

        }

        private void ComputeCollatzSequenceWithoutWrapper(int n, List<int>? sequence = null)
        {
            //if (sequence == null)
            //{
            //    sequence = new List<int>();
            //}
            sequence ??= new List<int>(); // same as if() above
            
            if (n == 1)
                return;

            if (n % 2 == 0)
                n /= 2;
            else
                try
                {
                    checked
                    { 
                        n = 3 * n + 1; 
                    }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("Overflow at num: " + n);
                }

            sequence.Add(n);

            ComputeCollatzSequenceWithoutWrapper(n, sequence);
        }

    }
}
