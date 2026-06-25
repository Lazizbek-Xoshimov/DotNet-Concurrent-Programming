namespace ThreadSafeLogger;

public class Program
{
    public static readonly object fileLock = new ();

    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < 10; i ++)
            threads.Add(new Thread(WriteToFile) { Name = $"Thread {i}" });

        foreach (Thread thread in threads)
        {
            thread.Start();
            thread.Join();
        }
    }

    public static void WriteToFile()
    {   
        lock (fileLock)
        {
            using StreamWriter writer = new StreamWriter("message.txt", append: true);
            writer.Write(Thread.CurrentThread.Name + ": ");
            for (int i = 0; i < 100; i++)
            {
                writer.Write(i + " ");
            }
            writer.WriteLine();
        }
    }
}