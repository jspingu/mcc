class Mobile
{
    public static List<int> GetMinimumActions(string path)
    {
        string[] inputs = File.ReadAllLines(path);
        List<int> outputs = new();

        for(int i = 0; i < Convert.ToInt32(inputs[0]); i++)
        {
            int[] description = Array.ConvertAll(inputs[2 * i + 1].Split(' '), Convert.ToInt32);
            List<int> enemyLevels = Array.ConvertAll(inputs[2 * i + 2].Split(' '), Convert.ToInt32).ToList();
            
            int currentLevel = description[1];
            int targetLevel = description[2];

            int actionCount = 0;

            while(currentLevel < targetLevel)
            {
                List<int> killableEnemies = enemyLevels.FindAll((level) => level < currentLevel);
                if (killableEnemies.Count == 0)
                {
                    actionCount = -1;
                    break;
                }

                currentLevel += killableEnemies.Max();
                enemyLevels.Remove(killableEnemies.Max());

                actionCount++;
            }

            outputs.Add(actionCount);
        }

        return outputs;
    }
}