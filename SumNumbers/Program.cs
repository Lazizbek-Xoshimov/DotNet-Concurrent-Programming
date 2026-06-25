namespace SumNumbers;

public class Program
{
    protected static long sum = 0;
    static long sumA = 0;
    static long sumB = 0;
    static long sumC = 0;
    static long sumD = 0;

    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();

        threads.Add(new Thread(PartialFirst));
        threads.Add(new Thread(PartialSecond));
        threads.Add(new Thread(PartialThird));
        threads.Add(new Thread(PartialFourth));

        foreach (var thread in threads)
        {
            thread.Start();
            thread.Join();
        }

        Console.WriteLine($"The last sum: {sumA + sumB + sumC + sumD}");
    }

    public static void PartialFirst()
    {
        for (long i = 1; i < 250000; i ++)
            sumA += i;
    }

    public static void PartialSecond()
    {
        for (long i = 250000; i < 500000; i ++)
            sumB += i;
    }

    public static void PartialThird()
    {
        for (long i = 500000; i < 750000; i ++)
            sumC += i;
    }

    public static void PartialFourth()
    {
        for (long i = 750000; i <= 1000000; i ++)
            sumD += i;
    }
}