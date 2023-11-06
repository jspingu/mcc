class Tichu
{
    public static long GetLongestRun(string path)
    {
        string[] inputs = File.ReadAllLines(path);
        long wildcardCount = Convert.ToInt32(inputs[0].Split(' ')[1]);

        long[] sortedCards = Array.ConvertAll(inputs[1].Split(' '), Convert.ToInt64);
        Array.Sort(sortedCards);

        long maxRunLength = 1;

        for(int i = 0; i < sortedCards.Length - 1; i++)
        {
            long currentRunLength = 1;
            long wildcardsUsed = 0;

            for(int j = 1; j < sortedCards.Length - i; j++)
            {
                long gap = sortedCards[i + j] - sortedCards[i + j - 1];

                if(gap <= 1) currentRunLength += gap;
                else if(gap - 1 <= wildcardCount - wildcardsUsed)
                {
                    currentRunLength += gap;
                    wildcardsUsed += gap - 1;
                }
                else break;
            }

            if(wildcardsUsed < wildcardCount) currentRunLength += wildcardCount - wildcardsUsed;

            maxRunLength = Math.Max(maxRunLength, currentRunLength);
        }

        return maxRunLength;
    }
}