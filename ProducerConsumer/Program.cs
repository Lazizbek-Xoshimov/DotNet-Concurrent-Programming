namespace ProducerConsumer;

public class Program
{
    private static List<int> numbers = new List<int>();

    public static void Main(string[] args)
    {
        Thread Producer = new Thread(AddNumbers);
        Thread Consumer = new Thread(RemoveAndPrintNumbers);

        Producer.Start();
        Producer.Join();
        
        Consumer.Start();
    }

    public static void AddNumbers()
    {
        lock (numbers)
        {
            for (int i = 0; i < 10; i ++)
                numbers.Add(i);
        }
    }

    public static void RemoveAndPrintNumbers()
    {
        lock (numbers)
        {
            foreach (int number in numbers)
                Console.Write(number + " ");

            numbers.Clear();
        }
    }
}