class Program
{
    static void Main()
    {
        while(true)
        {
            Console.Write("Path: ");
            string path = Console.ReadLine();

            long output = SumK.GetScoreSum(path);

            Console.Write("Output: ");
            Console.WriteLine(output);
        }
    }
}