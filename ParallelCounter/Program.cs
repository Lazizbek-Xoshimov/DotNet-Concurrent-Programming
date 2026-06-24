namespace ParallelCounter;

public class Program
{
    public static void Main(string[] args)
    {
        Thread threadA = new Thread(DisplayNumbers);
        Thread threadB = new Thread(DisplayNumbers);
        Thread threadC = new Thread(DisplayNumbers);

        threadA.Start();
        threadB.Start();
        threadC.Start();
    }

    public static void DisplayNumbers()
    {
        for (int i = 1; i <= 100; i ++)
            Console.Write(i + " ");

        Thread.Sleep(2000);
    }
}