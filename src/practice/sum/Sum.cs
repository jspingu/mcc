using System.Text.RegularExpressions;

partial class Sum
{
    public static void SumInput(string path)
    {
        using StreamReader reader = File.OpenText(path);
        reader.ReadLine();

        string numbers = reader.ReadLine();

        string[] numberArr = Space().Split(numbers);

        int sum = 0;

        foreach(string num in numberArr)
        {
            sum += Convert.ToInt32(num);
        }

        Console.WriteLine(sum);
    }

    [GeneratedRegex(@"\s")]
	private static partial Regex Space();
}