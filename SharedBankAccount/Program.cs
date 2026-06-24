namespace SharedBankAccount;

public class Program
{
    private static int balance = 1000;
    private static readonly object balanceLock = new ();

    public static void Main(string[] args)
    {
        Thread threadFirst = new Thread(Withdraw);
        Thread threadSecond = new Thread(Withdraw);
        Thread threadThird = new Thread(Withdraw);
        Thread threadFourth = new Thread(Withdraw);
        Thread threadFifth = new Thread(Withdraw);

        threadFirst.Start();
        threadSecond.Start();
        threadThird.Start();
        threadFourth.Start();
        threadFifth.Start();

        Console.WriteLine($"Current balance: {balance}");
    }

    public static void Withdraw()
    {
        lock (balanceLock)
        {
            if (balance > 0)
                balance -= 100;
        }
    }
}