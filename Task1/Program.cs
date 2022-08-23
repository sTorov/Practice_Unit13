using System.Diagnostics;
using System.Text;

class Program
{
    const string path = "Text1.txt";
    private static Stopwatch stopwatch = new();
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        if(!File.Exists(path))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        string[] text = File.ReadAllLines(path);
        int n = 10;

        TestList(text, n);
        Console.WriteLine();
        TestLinkedList(text, n);

        Console.ReadKey();
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в коллекцию List
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="n"></param>
    static void TestList(string[] lines, int n)
    {
        List<string> list = new();
        double time = 0;

        Console.WriteLine("Замер времени вставки в коллекцию List<T>...");

        stopwatch.Start();

        for (int i = 0; i < n; i++)
        {
            Thread.Sleep(200);
            stopwatch.Restart();

            foreach (var line in lines)
                list.Add(line);

            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
            list.Clear();
        }
        Console.WriteLine($"Среднее время вставки: {Math.Round(time / n, 4)} мс");
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в коллекцию LinkedList
    /// </summary>
    /// <param name="lines"></param>
    /// <param name="n"></param>
    static void TestLinkedList(string[] lines, int n)
    {
        LinkedList<string> linkedList = new();
        double time = 0;

        Console.WriteLine("Замер времени вставки в коллекцию LinkedList<T>...");

        stopwatch.Start();

        for (int i = 0; i < n; i++)
        {
            Thread.Sleep(200);
            stopwatch.Restart();

            foreach (var line in lines)
                linkedList.AddLast(line);

            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
            linkedList.Clear();
        }
        Console.WriteLine($"Среднее время вставки: {Math.Round(time / n, 4)} мс");
    }
}