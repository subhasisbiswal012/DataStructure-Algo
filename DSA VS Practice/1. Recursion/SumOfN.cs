using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._Recursion
{
    public class SumOfN
    {
        public static int SumOfNFormula(int n)
        {
            return (n * (n + 1)) / 2;
        }

        public static int SumOfNLoop(int n)
        {
            int result = 0;
            for (int i = 1; i <= n; i++)
            {
                result += i;
            }
            return result;
        }

        public static int SumOfNRecursion(int n)
        {
            if (n == 0) return 0;
            return n + SumOfNRecursion(n - 1);
        }
    }
}
