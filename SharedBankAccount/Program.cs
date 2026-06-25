namespace SharedBankAccount;

public class Program
{
    private static int balance = 1000;
    private static readonly object balanceLock = new ();

    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < 5; i ++)
            threads.Add(new Thread(Withdraw)
            {
                Name = $"Thread {i}"
            });

        foreach (Thread thread in threads)
        {
            thread.Start();
            thread.Join();
        }

        Console.WriteLine($"Current balance: {balance}");
        Console.ReadKey();
    }

    public static void Withdraw()
    {
        lock (balanceLock)
        {
            balance -= 100;
            Console.WriteLine($"{Thread.CurrentThread.Name}: {balance}");
        }
    }
}