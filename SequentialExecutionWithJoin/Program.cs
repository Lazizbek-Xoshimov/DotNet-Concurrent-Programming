namespace SequentialExecutionWithJoin;

public class Program
{
    public static void Main(string[] args)
    {
        Thread threadFirst = new Thread(TopTen) { Name = "First thread" };
        Thread threadSecond = new Thread(SecondDecade) { Name = "Second thread" };
        Thread threadThird = new Thread(ThirdDecimalPlace) { Name = "Third thread" };

        threadFirst.Start();
        threadFirst.Join();
        
        threadSecond.Start();
        threadSecond.Join();

        threadThird.Start();
        threadThird.Join();
    }

    public static void TopTen()
    {
        Console.Write(Thread.CurrentThread.Name + ": ");

        for(int i = 1; i <= 10; i ++)
            Console.Write(i + " ");

        Console.WriteLine();
    }

    public static void SecondDecade()
    {
        Console.Write(Thread.CurrentThread.Name + ": ");

        for(int i = 11; i <= 20; i ++)
            Console.Write(i + " ");

        Console.WriteLine();
    }

    public static void ThirdDecimalPlace()
    {
        Console.Write(Thread.CurrentThread.Name + ": ");

        for(int i = 21; i <= 30; i ++)
            Console.Write(i + " ");

        Console.WriteLine();
    }
}