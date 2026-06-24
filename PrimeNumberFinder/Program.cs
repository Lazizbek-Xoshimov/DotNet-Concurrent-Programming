namespace PrimeNumberFinder;

public class Program
{
    public static void Main(string[] args)
    {
        Thread threadFirst = new Thread(FirstRange);
        Thread threadSecond = new Thread(SecondRange);
        Thread threadThird = new Thread(ThirdRange);
        Thread threadFourth = new Thread(FourthRange);

        threadFirst.Start();
        threadFirst.Join();

        threadSecond.Start();
        threadSecond.Join();

        threadThird.Start();
        threadThird.Join();

        threadFourth.Start();
        threadFourth.Join();
    }

    public static void FirstRange()
    {
        foreach (int number in PrimeNumbers(1, 25000))
            Console.Write(number + " ");    
    }

    public static void SecondRange()
    {
        foreach (int number in PrimeNumbers(25000, 50000))
            Console.Write(number + " "); 
    }

    public static void ThirdRange()
    {
        foreach (int number in PrimeNumbers(50000, 75000))
            Console.Write(number + " "); 
    }

    public static void FourthRange()
    {
        foreach (int number in PrimeNumbers(75000, 100000))
            Console.Write(number + " "); 
    }

    public static List<int> PrimeNumbers(int first, int last)
    {
        List<int> numbers = new List<int>();

        for (int i = first; i < last; i++)
        {
            int count = 0;

            for (int j = first; j < i; j++)
            {
                if (i % j == 0)
                    count ++;
            }

            if (count == 1)
                numbers.Add(i);
        }

        return numbers;
    }
}