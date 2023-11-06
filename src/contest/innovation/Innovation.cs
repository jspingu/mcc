class Innovation
{
    public static long GetMaxPoints(string path)
    {
        string[] inputs = File.ReadAllLines(path);
        List<int[]> cards = new();

        int cardCount = Convert.ToInt32(inputs[0].Split(' ')[1]);

        for(int i = 1; i < inputs.Length; i++)
        {
            cards.Add(Array.ConvertAll(inputs[i].Split(' '), Convert.ToInt32));
        }

        long points = 0;

        List<int[]> cardBuffer = new();

        for(int i = 0; i < cardCount; i++)
        {
            int[] maxColumn = cards.MaxBy((card) => card[0] + card[1]);
            cardBuffer.Add(maxColumn);
            cards.Remove(maxColumn);
        }

        int maxRemainingSum = cards.Max(Enumerable.Sum);
        int[] maxRow = cardBuffer.MaxBy((card) => card[2] + card[3]);
        int[] minColumn = cardBuffer[^1];

        if(maxRemainingSum > maxRow[2] + maxRow[3] + minColumn[0] + minColumn[1])
        {
            points += maxRemainingSum;
            cardBuffer.Remove(minColumn);
        }
        else
        {
            points += maxRow.Sum();
            cardBuffer.Remove(maxRow);
        }

        foreach(int[] card in cardBuffer) points = points + card[0] + card[1];

        return points;
    }
}