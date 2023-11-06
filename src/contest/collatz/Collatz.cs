class Collatz
{
    public static int CollatzSum(string path)
    {
        string[] inputs = File.ReadAllLines(path);

        int procedureCount = Convert.ToInt32(inputs[0].Split(' ')[1]);
        int[] numbers = Array.ConvertAll(inputs[1].Split(' '), Convert.ToInt32);

        int sum = 0;

        for(int i = 0; i < numbers.Length; i++)
        {
            for(int j = 0; j < procedureCount; j++) numbers[i] = (numbers[i] & 1) == 0 ? numbers[i] / 2 : 3 * numbers[i] + 1;
            sum += numbers[i];
        }

        return sum;
    }
}