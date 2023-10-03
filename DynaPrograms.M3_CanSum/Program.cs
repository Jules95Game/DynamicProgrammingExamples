namespace DynaPrograms.M3_CanSum;

internal class Program
{
    private static void Main()
    {
        Console.Write("Press enter to start.");
        Console.ReadLine();
        Console.WriteLine(CanSum(7, new int[] { 2, 3 }));       // True
        Console.WriteLine(CanSum(7, new int[] { 5, 3, 4, 7 })); // True
        Console.WriteLine(CanSum(7, new int[] { 2, 4 }));       // False
        Console.WriteLine(CanSum(8, new int[] { 2, 3, 5 }));    // True
        Console.WriteLine(CanSum(300, new int[] { 7, 14 }));    // False
        Console.Write("Done!");
        Console.ReadLine();
    }

    // Optimized
    // O(m*n) Time
    // O(m) Space
    // m = targetSum
    // n = numbers array length
    private static bool CanSum(int targetSum, int[] numbers, Dictionary<int, bool>? memo = null)
    {
        memo ??= new();
        if (memo.ContainsKey(targetSum)) return memo[targetSum];
        if (targetSum == 0) return true;
        if (targetSum < 0) return false;
        foreach (int num in numbers)
        {
            if (CanSum(targetSum - num, numbers, memo))
            {
                memo[targetSum] = true;
                return true;
            };
        }
        memo[targetSum] = false;
        return false;
    }

    // Unoptimized
    // O(n^m) Time
    // O(m) Space
    // m = targetSum
    // n = numbers array length
    private static bool BruteCanSum(int targetSum, int[] numbers)
    {
        if (targetSum == 0) return true;
        if (targetSum < 0) return false;
        foreach (int num in numbers)
        {
            int remainder = targetSum - num;
            if (BruteCanSum(remainder, numbers))
            {
                return true;
            };
        }
        return false;
    }
}