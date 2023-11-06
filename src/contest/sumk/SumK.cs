class SumK
{
    public static long GetScoreSum(string path)
    {
        string[] inputs = File.ReadAllLines(path);
        int exp = Convert.ToInt32(inputs[0].Split(' ')[1]);

        long[] set = Array.ConvertAll(inputs[1].Split(' '), Convert.ToInt64);

        long sum = 0;

        for(int choose = 1; choose <= set.Length; choose++)
        {
            int[] combination = new int[choose];
            for(int j = 0; j < combination.Length; j++) combination[j] = j;

            do
            {
                sum += (long)Math.Pow(combination.Sum((index) => set[index]), exp);
                sum %= 998244353;
            }
            while(IncrementCombination(combination, choose - 1, set.Length) != choose - 1);
        }

        return sum;
    }

    public static int IncrementCombination(int[] arr, int index, int setSize)
    {
        if(index == -1) return -1;

        if(arr[index] < setSize - (arr.Length - index)) arr[index]++;
        else arr[index] = IncrementCombination(arr, index - 1, setSize) + 1;

        return arr[index];
    }
}