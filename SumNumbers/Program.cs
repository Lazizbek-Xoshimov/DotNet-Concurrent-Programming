namespace SumNumbers;

public class Program
{
    protected static long sum = 0;
    public static void Main(string[] args)
    {
        Thread threadFirst = new Thread(PartialFirst);
        Thread threadSecond = new Thread(PartialSecond);
        Thread threadThird = new Thread(PartialThird);
        Thread threadFourth = new Thread(PartialFourth);

        threadFirst.Start();
        threadSecond.Start();
        threadThird.Start();
        threadFourth.Start();

        threadFirst.Join();
        threadSecond.Join();
        threadThird.Join();
        threadFourth.Join();

        Console.WriteLine($"The last sum: {sum}");
    }

    public static void PartialFirst()
    {
        for (long i = 1; i < 250000; i ++)
            sum += i;
    }

    public static void PartialSecond()
    {
        for (long i = 250000; i < 500000; i ++)
            sum += i;
    }

    public static void PartialThird()
    {
        for (long i = 500000; i < 750000; i ++)
            sum += i;
    }

    public static void PartialFourth()
    {
        for (long i = 750000; i <= 1000000; i ++)
            sum += i;
    }
}