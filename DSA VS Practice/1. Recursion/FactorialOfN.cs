using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._Recursion
{
    public class FactorialOfN
    {
        public static int FactorialLoop(int n)
        {
            if (n == 0) return 1;
            int result = 1;
            for(int i = n;i > 0; i--)
            {
                result *= i;
            }
            return result;
        }

        public static int FactorialRecursion(int n)
        {
            if (n == 0) return 1;
            return n * FactorialRecursion(n - 1);
        }
    }
}
