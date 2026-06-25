namespace ParallelCounter;

public class Program
{
    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();

        threads.Add(new Thread(DisplayNumbers));
        threads.Add(new Thread(DisplayNumbers));
        threads.Add(new Thread(DisplayNumbers));

        foreach (Thread thread in threads)
        {
            thread.Start();
        }
    }

    public static void DisplayNumbers()
    {
        for (int i = 1; i <= 100; i ++)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000);
        }
    }
}