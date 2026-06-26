namespace DownloadManagerSimulation;

public class Program
{
    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();
        Random random = new Random();
        object threadLock = new object();

        Console.Clear();
        Console.WriteLine("Files downloading...");

        for (int i = 0; i < 5; i++)
        {
            threads.Add(new Thread(() =>
            {
                lock (threadLock)
                {
                    for (int j = 10; j <= 100; j += 10)
                    {
                        Console.SetCursorPosition(0, int.Parse(Thread.CurrentThread.Name) + 1);
                        Console.WriteLine($"File {Thread.CurrentThread.Name} -> {j} %");
                        Thread.Sleep(random.Next(1, 10) * 100);
                    }
                }
            })
            {
                Name = $"{i}",
                IsBackground = false
            });
        }
        
        foreach (Thread thread in threads)
            thread.Start();

        foreach (Thread thread in threads)
            thread.Join();

        Console.SetCursorPosition(0, 6);
        Console.WriteLine("Files downloaded.");
    }
}