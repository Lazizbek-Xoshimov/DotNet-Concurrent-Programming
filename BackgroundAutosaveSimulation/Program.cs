namespace BackgroundAutosaveSimulation;

public class Program
{
    public static void Main(string[] args)
    {
        Thread.CurrentThread.Name = "Main Thread";

        Console.Write($"{Thread.CurrentThread.Name}: ");
        Console.WriteLine("User is typing...");

        Thread backThread = new Thread(() => 
        {
            Console.Write($"{Thread.CurrentThread.Name}: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine("Data saved.");

            Console.WriteLine($"{Thread.CurrentThread.Name} has ended.");
        })
        {
            Name = "Background Thread",
            IsBackground = true
        };

        backThread.Start();

        Thread.Sleep(11000);
        Console.WriteLine($"{Thread.CurrentThread.Name} has ended.");
    }
}