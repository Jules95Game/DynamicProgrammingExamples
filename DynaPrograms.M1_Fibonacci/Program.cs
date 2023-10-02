namespace DynaPrograms.M1_Fibonacci;

internal class Program
{
    static void Main()
    {
        Console.Write("Press enter to start.");
        Console.ReadLine();
        Console.WriteLine(Fib(6));  // 8
        Console.WriteLine(Fib(7));  // 13
        Console.WriteLine(Fib(8));  // 21
        Console.WriteLine(Fib(50)); // 12586269025
        Console.WriteLine(Fib(92)); // 7540113804746346429
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
    private static long BruteFib(int n)
    {
        if (n <= 2) return 1;
        return BruteFib(n - 1) + BruteFib(n - 2);
    }
}