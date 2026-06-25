namespace PrimeNumberFinder;

public class Program
{
    public static void Main(string[] args)
    {
        List<Thread> threads = new List<Thread>();

        threads.Add(new Thread(() =>
        {
            Console.Write(Thread.CurrentThread.Name + ": ");
            foreach (long number in PrimeNumbers(1, 20_000))
                Console.Write(number + " ");
            Console.WriteLine();
        }) { Name = "Thread 1" });

        threads.Add(new Thread(() =>
        {
            Console.Write(Thread.CurrentThread.Name + ": ");
            foreach (long number in PrimeNumbers(20_000, 40_000))
                Console.Write(number + " ");
            Console.WriteLine();
        }) { Name = "Thread 2" });

        threads.Add(new Thread(() =>
        {
            Console.Write(Thread.CurrentThread.Name + ": ");
            foreach (long number in PrimeNumbers(40_000, 60_000))
                Console.Write(number + " ");
            Console.WriteLine();
        }) { Name = "Thread 3" });

        threads.Add(new Thread(() =>
        {
            Console.Write(Thread.CurrentThread.Name + ": ");
            foreach (long number in PrimeNumbers(60_000, 80_000))
                Console.Write(number + " ");
            Console.WriteLine();
        }) { Name = "Thread 4" });

        threads.Add(new Thread(() =>
        {
            Console.Write(Thread.CurrentThread.Name + ": ");
            foreach (long number in PrimeNumbers(80_000, 100_000))
                Console.Write(number + " ");
            Console.WriteLine();
        }) { Name = "Thread 5" });

        foreach (Thread thread in threads)
        {
            thread.Start();
            thread.Join();
        }
    }

    public static List<long> PrimeNumbers(long first, long last)
    {
        List<long> numbers = new List<long>();

        for (long i = Math.Max(first, 2); i < last; i++)
        {
            bool isPrime = true;

            for (long j = 2; j < i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
                numbers.Add(i);
        }

        return numbers;
    }
}