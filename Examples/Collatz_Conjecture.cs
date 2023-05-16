using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples
{
    internal class Collatz_Conjecture
    {
        public List<int>CollatzSequence(int num) 
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
                    n = 3 * n + 1;
                }
            }
            sequence.Add(1);
            return sequence;
        }
    }
}
