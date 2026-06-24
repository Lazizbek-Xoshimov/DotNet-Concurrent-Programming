namespace ThreadSafeLogger;

public class Program
{
    public static readonly object fileLock = new ();

    public static void Main(string[] args)
    {
        Thread threadFirst = new Thread(WriteToFile);
        Thread threadSecond = new Thread(WriteToFile);
        Thread threadThird = new Thread(WriteToFile);
        Thread threadFourth = new Thread(WriteToFile);
        Thread threadFifth = new Thread(WriteToFile);
        Thread threadSixth = new Thread(WriteToFile);
        Thread threadSeventh = new Thread(WriteToFile);
        Thread threadEighth = new Thread(WriteToFile);
        Thread threadNinth = new Thread(WriteToFile);
        Thread threadTenth = new Thread(WriteToFile);

        threadFirst.Start();
        threadSecond.Start();
        threadThird.Start();
        threadFourth.Start();
        threadFifth.Start();
        threadSixth.Start();
        threadSeventh.Start();
        threadEighth.Start();
        threadNinth.Start();
        threadTenth.Start();
    }

    public static void WriteToFile()
    {
        lock (fileLock)
        {
            using StreamWriter writer = new StreamWriter("message.txt", append: true);

            for (int i = 0; i < 100; i ++)
                writer.Write(i + " ");
            
            writer.WriteLine();
        }
    }
}