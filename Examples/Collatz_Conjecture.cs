using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    public class Collatz_Conjecture
    {
        public List<int> CollatzSequence(int num)
        {
            return ComputeCollatzSequence(num, new List<int>());
        }
        private List<int> ComputeCollatzSequence(int n, List<int> sequence)
        {
            while (n != 1)
            {
                sequence.Add(n);

                if (n % 2 == 0)
                {
                    n = n / 2;
                }
                else
                {
                    try
                    {
                        checked
                        { n = 3 * n + 1; }
                    }
                    catch 
                    {
                        throw new OverflowException("Overflow at num: " + n);
                    }
                }
            }
            sequence.Add(1);
            return sequence;
        }
    }
}
