namespace SequentialExecutionWithJoin;

public class Program
{
    public static void Main(string[] args)
    {
        Thread threadFirst = new Thread(TopTen);
        Thread threadSecond = new Thread(SecondDecade);
        Thread threadThird = new Thread(ThirdDecimalPlace);

        threadFirst.Start();
        threadFirst.Join();
        
        threadSecond.Start();
        threadSecond.Join();

        threadThird.Start();
        threadThird.Join();        
    }

    public static void TopTen()
    {
        for(int i = 1; i <= 10; i ++)
            Console.Write(i + " ");
    }

    public static void SecondDecade()
    {
        for(int i = 11; i <= 20; i ++)
            Console.Write(i + " ");
    }

    public static void ThirdDecimalPlace()
    {
        for(int i = 21; i <= 30; i ++)
            Console.Write(i + " ");
    }
}