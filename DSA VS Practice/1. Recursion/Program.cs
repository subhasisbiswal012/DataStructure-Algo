
using _1._Recursion;

public class Program
{
    public static void TailRecusrion(int n)
    {
        if(n > 0)
        {
            Console.WriteLine(n * n);
            TailRecusrion(n - 1);
        }

    }
    public static void headRecursion(int n)
    {
        if(n > 0)
        {
            headRecursion(n - 1);
            Console.WriteLine(n * n);
        }
    }
    public static void Treerecusrsion(int n)
    {
        if ((n > 0))
        {
            Treerecusrsion(n - 1);
            Console.WriteLine(n * n);
            Treerecusrsion(n - 1);
        }
    }

    public static void IndirectOne(int n)
    {
        if (n > 0)
        {
            Console.WriteLine(n * n);
            IndirectTwo(n - 1);
        }
    }

    private static void IndirectTwo(int v)
    {
        if (v > 0)
        {
            Console.WriteLine(v * v);
            IndirectTwo(v - 1);
        }
    }

    public static void Main(string[] args)
    {
        TailRecusrion(5);
        Console.WriteLine("-------------");
        headRecursion(5);
        Console.WriteLine("-------------");
        Treerecusrsion(3);
        Console.WriteLine("-------------");
        IndirectOne(3);
        Console.WriteLine("------SumOfNFormula-------");
        Console.WriteLine(SumOfN.SumOfNFormula(5));
        Console.WriteLine("------SumOfNLoop-------");
        Console.WriteLine(SumOfN.SumOfNLoop(5));
        Console.WriteLine("-------SumOfNRecursion------");
        Console.WriteLine(SumOfN.SumOfNRecursion(5));

        Console.WriteLine("-------FactorialLoop------");
        Console.WriteLine(FactorialOfN.FactorialLoop(5));
        Console.WriteLine("-------FactorialRecursion------");
        Console.WriteLine(FactorialOfN.FactorialRecursion(5));
    }
}
