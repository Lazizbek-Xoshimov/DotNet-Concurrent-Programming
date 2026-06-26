public class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        int tickets = 100;
        object ticketLock = new object();

        List<Thread> threads = new List<Thread>();

        for (int i = 0; i < 20; i ++)
            threads.Add(new Thread(() =>
            {
                int buy = random.Next(1, 10);
                Console.WriteLine($"{Thread.CurrentThread.Name} wants to buy {buy}");

                lock (ticketLock)
                {
                    if (tickets - buy >= 0)
                    {
                        tickets -= buy;
                        Console.WriteLine($"{Thread.CurrentThread.Name} bought {buy} tickets, {tickets} ticket left.");
                    }
                    else
                        Console.WriteLine($"{Thread.CurrentThread.Name} did not buy {buy} tickets, there were {tickets} tickets left.");
                }
            })
            {
               Name = $"Client {i}",
               IsBackground = false
            });

        foreach (Thread thread in threads)
        {
            thread.Start();
        }
    }
}