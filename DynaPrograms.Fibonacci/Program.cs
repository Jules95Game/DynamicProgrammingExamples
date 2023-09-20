namespace DynaPrograms.Fibonacci;

internal class Program
{
    static void Main()
    {
        Console.Write("Press enter to start.");
        Console.ReadLine();
        Console.WriteLine(Fib(6));
        Console.WriteLine(Fib(7));
        Console.WriteLine(Fib(8));
        Console.WriteLine(Fib(50));
        Console.WriteLine(Fib(92));
        Console.Write("Done!");
        Console.ReadLine();
    }

    // Memoized
    // O(n) Time
    // O(n) Space
    private static long Fib(int n, Dictionary<int, long>? memo = null)
    {
        memo ??= new();
        if (memo.ContainsKey(n)) return memo[n];
        if (n <= 2) return 1;
        memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
        return memo[n];
    }

    // Unoptimized
    // O(2^n) Time
    // O(n) Space
    private static long BadFib(int n)
    {
        if (n <= 2) return 1;
        return BadFib(n - 1) + BadFib(n - 2);
    }
}