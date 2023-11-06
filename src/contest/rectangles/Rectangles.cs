class Rectangles
{
    // Task 2 solution: max height * total width
    // public static long GetMinimumArea(string path)
    // {
    //     string[] inputs = File.ReadAllLines(path);

    //     List<long> heightList = new();
    //     List<long> widthList = new();

    //     for(int i = 1; i < inputs.Length; i++)
    //     {
    //         heightList.Add(Convert.ToInt64(inputs[i].Split(' ')[0]));
    //         widthList.Add(Convert.ToInt64(inputs[i].Split(' ')[1]));
    //     }

    //     return heightList.Max() * widthList.Sum();
    // }

    // Task 4 solution: Sum of all rectangle areas
    // public static long GetMinimumArea(string path)
    // {
    //     string[] inputs = File.ReadAllLines(path);

    //     List<long> heightList = new();
    //     List<long> widthList = new();

    //     for(int i = 1; i < inputs.Length; i++)
    //     {
    //         heightList.Add(Convert.ToInt64(inputs[i].Split(' ')[0]));
    //         widthList.Add(Convert.ToInt64(inputs[i].Split(' ')[1]));
    //     }

    //     long areaSum = 0;

    //     for(int i = 0; i < heightList.Count; i++)
    //     {
    //         areaSum += heightList[i] * widthList[i];
    //     }

    //     return areaSum;
    // }

    // General solution: make series of optimal cuts
    // doesnt work in all situations
    public static long GetMinimumArea(string path)
    {
        string[] inputs = File.ReadAllLines(path);
        long divisionCount = Convert.ToInt64(inputs[0].Split(' ')[1]) - 1;

        List<Rectangle> rectangles = new();

        for(int i = 1; i < inputs.Length; i++)
        {
            rectangles.Add(new Rectangle(
                Convert.ToInt64(inputs[i].Split(' ')[0]), 
                Convert.ToInt64(inputs[i].Split(' ')[1])
            ));
        }

        List<int> subdivisions = new List<int> {0, rectangles.Count};

        long minimumArea = rectangles.Max((rect) => rect.Height) * rectangles.Sum((rect) => rect.Width);

        for(int i = 0; i < divisionCount; i++)
        {
            if(subdivisions.Count - 1 == rectangles.Count) break;

            int bestDivisionIndex = 0;
            long maxAreaLoss = 0;

            for(int j = 0; j < subdivisions.Count - 1; j++)
            {
                long currentSubdivisionArea = GetSubdivisionArea(rectangles, subdivisions[j], subdivisions[j + 1]);

                for(int k = subdivisions[j] + 1; k < subdivisions[j + 1]; k++)
                {
                    long partitionedArea = GetSubdivisionArea(rectangles, subdivisions[j], k) + GetSubdivisionArea(rectangles, k, subdivisions[j + 1]);

                    if(currentSubdivisionArea - partitionedArea >= maxAreaLoss)
                    {
                        maxAreaLoss = currentSubdivisionArea - partitionedArea;
                        bestDivisionIndex = k;
                    }
                }
            }

            minimumArea -= maxAreaLoss;

            subdivisions.Add(bestDivisionIndex);
            subdivisions.Sort();
        }

        return minimumArea;
    }

    static long GetSubdivisionArea(List<Rectangle> rectangles, int leftBound, int rightBound)
    {
        List<Rectangle> subdivision = rectangles.GetRange(leftBound, rightBound - leftBound);
        return subdivision.Max((rect) => rect.Height) * subdivision.Sum((rect) => rect.Width);
    }
}

struct Rectangle
{
    public long Height;
    public long Width;

    public Rectangle(long height, long width)
    {
        Height = height;
        Width = width;
    }
}