using DynaPrograms.Extensions;

namespace DynaPrograms.M5_BestSum;

internal class Program
{
    private static void Main()
    {
        Console.Write("Press enter to start.");
        Console.ReadLine();
        Console.WriteLine(BestSum(7, new int[] { 5, 3, 4, 7 })    // [ 7 ]
            .IntArrayToString());
        Console.WriteLine(BestSum(8, new int[] { 2, 3, 5 })       // [ 3, 5 ]
            .IntArrayToString());
        Console.WriteLine(BestSum(8, new int[] { 1, 4, 5 })       // [ 4, 4 ]
            .IntArrayToString());
        Console.WriteLine(BestSum(100, new int[] { 1, 2, 5, 25 }) // [ 25, 25, 25, 25, ]
            .IntArrayToString());
        Console.WriteLine(BestSum(100, Array.Empty<int>())        // null
            .IntArrayToString());
        Console.Write("Done!");
        Console.ReadLine();
    }

    // Optimized
    // O(n*m^2) Time
    // O(m^2) Space
    // m = targetSum
    // n = numbers array length
    private static int[]? BestSum(int targetSum, int[] numbers, Dictionary<int, int[]?>? memo = null)
    {
        memo ??= new();
        if (memo.ContainsKey(targetSum)) return memo[targetSum];
        if (targetSum == 0) return Array.Empty<int>();
        if (targetSum < 0) return null;
        int[]? shortestCombination = null;
        foreach (int num in numbers)
        {
            int[]? remainderCombination = BestSum(targetSum - num, numbers, memo);
            if (remainderCombination != null)
            {
                int[] combination = remainderCombination.Append(num).ToArray();
                if (shortestCombination == null || combination.Length < shortestCombination.Length)
                {
                    shortestCombination = combination;
                }
            }
        }
        memo[targetSum] = shortestCombination;
        return shortestCombination;
    }

    // Unoptimized
    // O(n^m * m) Time
    // O(m^2) Space
    // m = targetSum
    // n = numbers array length
    private static int[]? BruteBestSum(int targetSum, int[] numbers)
    {
        if (targetSum == 0) return Array.Empty<int>();
        if (targetSum < 0) return null;
        int[]? shortestCombination = null;
        foreach (int num in numbers)
        {
            int remainder = targetSum - num;
            int[]? remainderCombination = BruteBestSum(remainder, numbers);
            if (remainderCombination != null)
            {
                int[] combination = remainderCombination.Append(num).ToArray();
                if (shortestCombination == null || combination.Length < shortestCombination.Length)
                {
                    shortestCombination = combination;
                }
            }
        }
        return shortestCombination;
    }
}