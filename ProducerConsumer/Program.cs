namespace ProducerConsumer;

public class Program
{
    private static List<int> numbers = new List<int>();
    public static object numbersLock = new object();

    public static void Main(string[] args)
    {
        Thread Producer = new Thread(AddNumbers) { Name = "Producer thread" };
        Thread Consumer = new Thread(RemoveAndPrintNumbers) { Name = "Consumer thread" };

        Producer.Start();
        Producer.Join();
        
        Consumer.Start();
        Consumer.Join();
    }

    public static void AddNumbers()
    {
        lock (numbersLock)
        {
            Console.Write(Thread.CurrentThread.Name + ": ");

            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i * 10);
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }
    }

    public static void RemoveAndPrintNumbers()
    {
        lock (numbersLock)
        {
            Console.Write(Thread.CurrentThread.Name + ": ");

            while (numbers.Count > 0)
            {
                Console.Write(numbers.First() + " ");
                numbers.Remove(numbers.First());
            }

            Console.WriteLine();
        }
    }
}