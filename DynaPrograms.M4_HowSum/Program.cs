using DynaPrograms.Extensions;

namespace DynaPrograms.M4_HowSum;

internal class Program
{
    private static void Main()
    {
        Console.Write("Press enter to start.");
        Console.ReadLine();
        Console.WriteLine(HowSum(7, new int[] { 2, 3 })       // [ 3, 2, 2 ]
            .IntArrayToString());
        Console.WriteLine(HowSum(7, new int[] { 5, 3, 4, 7 }) // [ 4, 3 ]
            .IntArrayToString());
        Console.WriteLine(HowSum(7, new int[] { 2, 4 })       // null
            .IntArrayToString());
        Console.WriteLine(HowSum(8, new int[] { 2, 3, 5 })    // [ 2, 2, 2, 2 ]
            .IntArrayToString());
        Console.WriteLine(HowSum(8, new int[] { 3, 5, 2 })    // [ 2, 3, 3 ]
            .IntArrayToString());
        Console.WriteLine(HowSum(300, new int[] { 7, 14 })    // null
            .IntArrayToString());
        Console.WriteLine(HowSum(300, Array.Empty<int>())     // null
            .IntArrayToString());
        Console.Write("Done!");
        Console.ReadLine();
    }

    // Optimized
    // O(n*m^2) Time
    // O(m^2) Space
    // m = targetSum
    // n = numbers array length
    private static int[]? HowSum(int targetSum, int[] numbers, Dictionary<int, int[]?>? memo = null)
    {
        memo ??= new();
        if (memo.ContainsKey(targetSum)) return memo[targetSum];
        if (targetSum == 0) return Array.Empty<int>();
        if (targetSum < 0) return null;
        foreach (int num in numbers)
        {
            int[]? remainderResult = HowSum(targetSum - num, numbers, memo);
            if (remainderResult != null)
            {
                memo[targetSum] = remainderResult.Append(num).ToArray();
                return memo[targetSum];
            }
        }
        memo[targetSum] = null;
        return null;
    }

    // Unoptimized
    // O(n^m * m) Time
    // O(m) Space
    // m = targetSum
    // n = numbers array length
    private static int[]? BruteHowSum(int targetSum, int[] numbers)
    {
        if (targetSum == 0) return Array.Empty<int>();
        if (targetSum < 0) return null;
        foreach (int num in numbers)
        {
            int remainder = targetSum - num;
            int[]? remainderResult = BruteHowSum(remainder, numbers);
            if (remainderResult != null)
            {
                return remainderResult.Append(num).ToArray();
            }
        }
        return null;
    }
}