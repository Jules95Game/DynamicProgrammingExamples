namespace DynaPrograms.M2_GridTraveler;

internal class Program
{
    static void Main()
    {
        Console.Write("Press enter to start.");
        Console.ReadLine();
        Console.WriteLine(GridTraveler(1, 1));   // 1
        Console.WriteLine(GridTraveler(2, 3));   // 3
        Console.WriteLine(GridTraveler(3, 2));   // 3
        Console.WriteLine(GridTraveler(3, 3));   // 6
        Console.WriteLine(GridTraveler(18, 18)); // 2333606220
        Console.Write("Done!");
        Console.ReadLine();
    }

    // Memoized
    // O(m*n) Time
    // O(n+m) Space
    private static long GridTraveler(int m, int n, Dictionary<string, long>? memo = null)
    {
        memo ??= new();
        string key = $"{m},{n}";
        if (memo.ContainsKey(key)) return memo[key];
        if (m == 1 && n == 1) return 1;
        if (m == 0 || n == 0) return 0;
        memo[key] = GridTraveler(m - 1, n, memo) + GridTraveler(m, n - 1, memo);
        return memo[key];
    }

    // Unoptimized
    // O(2^(n+m)) Time
    // O(n+m) Space
    private static long BruteGridTraveler(int m, int n)
    {
        if (m == 1 && n == 1) return 1;
        if (m == 0 || n == 0) return 0;
        return BruteGridTraveler(m - 1, n) + BruteGridTraveler(m, n - 1);
    }
}