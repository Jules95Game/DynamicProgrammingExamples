namespace DynaPrograms.Extensions;

public static class ArrayExtensions
{
    public static string IntArrayToString(this int[]? array)
    {
        if (array == null) return "null";
        if (array == Array.Empty<int>()) return "[]";
        string output = "[";
        foreach (int num in array)
        {
            output += $" {num},";
        }
        output = output.Remove(output.Length - 1);
        return output += " ]";
    }
}