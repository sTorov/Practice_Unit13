using System.Diagnostics;

class Program
{
    const string path = "D:\\VisualStudio\\repos\\Practice_Unit13\\Text1.txt";
    private static Stopwatch stopwatch = new Stopwatch();

    static void Main(string[] args)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("Файл не существует!");
            return;
        }

        string text = File.ReadAllText(path);
        char[] simbol = { ' ', '\n' };
        var words = text.Split(simbol, StringSplitOptions.RemoveEmptyEntries);

        TestInsertFirst(words);
        Console.WriteLine();
        TestInsertMiddle(words);
        Console.WriteLine();
        TestInsertLast(words);

        Console.ReadKey();
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в начало коллекции
    /// </summary>
    /// <param name="words"></param>
    static void TestInsertFirst(string[] words)
    {
        LinkedList<string> linkedList = new LinkedList<string>(words);
        double time = 0;

        Console.WriteLine("Вставка элемента в начало LinkedList<T>...");
        stopwatch.Start();

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(200);

            stopwatch.Restart();
            linkedList.AddFirst("Start");
            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
        }

        Console.WriteLine($"Среднее время {Math.Round(time / 10, 4)} мс");
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в середину коллекции
    /// </summary>
    /// <param name="words"></param>
    static void TestInsertMiddle(string[] words)
    {
        LinkedList<string> linkedList = new LinkedList<string>(words);
        LinkedListNode<string> node = linkedList.Find(words[words.Length / 2])!;
        double time = 0;

        Console.WriteLine("Вставка элемента в середину LinkedList<T>...");
        stopwatch.Start();

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(200);

            stopwatch.Restart();
            linkedList.AddBefore(node, "Middle");
            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
        }

        Console.WriteLine($"Среднее время {Math.Round(time / 10, 4)} мс");
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в конец коллекции
    /// </summary>
    /// <param name="words"></param>
    static void TestInsertLast(string[] words)
    {
        LinkedList<string> linkedList = new LinkedList<string>(words);
        double time = 0;

        Console.WriteLine("Вставка элемента в конец LinkedList<T>...");
        stopwatch.Start();

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(200);

            stopwatch.Restart();
            linkedList.AddLast("End");
            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
        }

        Console.WriteLine($"Среднее время {Math.Round(time / 10, 4)} мс");
    }
}