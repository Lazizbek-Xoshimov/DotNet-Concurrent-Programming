using System.Drawing;

public class Program
{
    public static object colorLock = new object();
    public static ConsoleKeyInfo button = new ConsoleKeyInfo();
    public static bool isRunning = true;
    public static CurrentLight light = CurrentLight.Red;

    public static void Main(string[] args)
    {
        Thread redThread = new Thread(RedLight)
        {
            Name = "Red Thread",
            IsBackground = false
        };

        Thread yellowThread = new Thread(YellowLight)
        {
            Name = "Yellow Thread",
            IsBackground = false
        };

        Thread greenThread = new Thread(GreenLight)
        {
            Name = "Green Thread",
            IsBackground = false
        };

        redThread.Start();
        yellowThread.Start();
        greenThread.Start(); 

        Console.WriteLine("Press ESC to stop...");
        button = Console.ReadKey(true);

        while (!button.Key.Equals(ConsoleKey.Escape))
        {
        }

        isRunning = false;

        redThread.Join();
        yellowThread.Join();
        greenThread.Join();

        Console.WriteLine("Simulation stopped.");
    }

    public static void RedLight()
    {
        while (isRunning)
        {
            lock (colorLock)
            {
                if (light.Equals(CurrentLight.Red))
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    light = CurrentLight.Yellow;
                }
            }

            Thread.Sleep(20);
        }
    }

    public static void YellowLight()
    {
        while (isRunning)
        {
            lock (colorLock)
            {
                if (light.Equals(CurrentLight.Yellow))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    light = CurrentLight.Green;
                }
            }

            Thread.Sleep(20);
        }
    }

    public static void GreenLight()
    {
        while (isRunning)
        {
            lock (colorLock)
            {
                if (light.Equals(CurrentLight.Green))
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(Thread.CurrentThread.Name);
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    light = CurrentLight.Red;
                }
            }

            Thread.Sleep(20);
        }
    }
}

public enum CurrentLight
{
    Red,
    Yellow,
    Green
}