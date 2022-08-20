using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const string path = "Text1.txt";
    private static Stopwatch stopwatch = new Stopwatch();
    
    static void Main(string[] args)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        string[] text = File.ReadAllLines(path);

        TestList(text);
        Console.WriteLine();
        TestLinkedList(text);

        Console.ReadKey();
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в коллекцию List
    /// </summary>
    /// <param name="lines"></param>
    static void TestList(string[] lines)
    {
        List<string> list = new List<string>();
        double time = 0;

        Console.WriteLine("Замер времени вставки в коллекцию List<T>...");

        stopwatch.Start();

        for (int i = 0; i < 10; i++)
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
        Console.WriteLine($"Среднее время вставки: {Math.Round(time / 10, 4)} мс");
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в коллекцию LinkedList
    /// </summary>
    /// <param name="lines"></param>
    static void TestLinkedList(string[] lines)
    {
        LinkedList<string> linkedList = new LinkedList<string>();
        double time = 0;

        Console.WriteLine("Замер времени вставки в коллекцию LinkedList<T>...");

        stopwatch.Start();

        for (int i = 0; i < 10; i++)
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
        Console.WriteLine($"Среднее время вставки: {Math.Round(time / 10, 4)} мс");
    }
}