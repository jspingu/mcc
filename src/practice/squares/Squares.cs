using System.Text.RegularExpressions;

partial class Squares
{
    static double Frac(double d) => d - (int)d;

    public static void GetPerfectSquareCount(string path)
    {
        using StreamReader reader = File.OpenText(path);
        reader.ReadLine();

        string numbers = reader.ReadLine();

        string[] numberArr = Space().Split(numbers);

        int perfectSquareCount = 0;

        foreach(string num in numberArr)
        {
            bool isPerfectSquare = Frac(Math.Sqrt(Convert.ToInt32(num))) < double.Epsilon * 100;
            if(isPerfectSquare) perfectSquareCount++;
        }

        Console.WriteLine(perfectSquareCount);
    }

    [GeneratedRegex(@"\s")]
	private static partial Regex Space();
}