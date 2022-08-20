using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const string path = "D:\\VisualStudio\\repos\\Practice_Unit13\\Text1.txt";
    private static Stopwatch stopwatch = new Stopwatch();
    
    static void Main(string[] args)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }
        
        string text = File.ReadAllText(path);
        char[] simbol = { ' ', '\n' };
        var words = text.Split(simbol, StringSplitOptions.RemoveEmptyEntries).ToList();

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
    /// <param name="list"></param>
    static void TestInsertFirst(List<string> list)
    {
        List<string> temp = list;
        double time = 0;

        Console.WriteLine("Вставка элемента в начало List<T>...");
        stopwatch.Start();

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(200);

            stopwatch.Restart();
            temp.Insert(0, "Start");
            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
        }

        Console.WriteLine($"Среднее время {Math.Round(time / 10, 4)} мс");
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в середину коллекции
    /// </summary>
    /// <param name="list"></param>
    static void TestInsertMiddle(List<string> list)
    {
        List<string> temp = list;
        int middlePoint = list.Count / 2;
        double time = 0;

        Console.WriteLine("Вставка элемента в середину List<T>...");
        stopwatch.Start();

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(200);

            stopwatch.Restart();
            temp.Insert(middlePoint, "Middle");
            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
        }

        Console.WriteLine($"Среднее время {Math.Round(time / 10, 4)} мс");
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в конец коллекции
    /// </summary>
    /// <param name="list"></param>
    static void TestInsertLast(List<string> list)
    {
        List<string> temp = list;
        double time = 0;

        Console.WriteLine("Вставка элемента в конец List<T>...");
        stopwatch.Start();

        for (int i = 0; i < 10; i++)
        {
            Thread.Sleep(200);

            stopwatch.Restart();
            temp.Insert(temp.Count - 1, "Start");
            stopwatch.Stop();

            time += stopwatch.Elapsed.TotalMilliseconds;
            Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
        }

        Console.WriteLine($"Среднее время {Math.Round(time / 10, 4)} мс");
    }
}