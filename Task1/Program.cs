using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const string path = "D:\\VisualStudio\\repos\\Practice_Unit13\\Text1.txt";
    private static Stopwatch stopwatch = new Stopwatch();
    
    static void Main(string[] args)
    {
        string text = File.ReadAllText(path);
        char[] simbol = { ' ', '\n' };
        var words = text.Split(simbol, StringSplitOptions.RemoveEmptyEntries);

        TestList(words);

        Console.ReadKey();
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в коллекцию List
    /// </summary>
    /// <param name="words"></param>
    static void TestList(string[] words)
    {
        List<string> list = words.ToList();
        int middlePoint = list.Count / 2;

        stopwatch.Start();
        list.Insert(middlePoint, "Middle");
        stopwatch.Stop();
        Console.WriteLine("Вставка элемента в середину List<T>: " + stopwatch.Elapsed.TotalMilliseconds);

        stopwatch.Restart();
        list.Insert(0, "Start");
        stopwatch.Stop();
        Console.WriteLine("Вставка элемента в начало List<T>: " + stopwatch.Elapsed.TotalMilliseconds);

        stopwatch.Restart();
        list.Insert(list.Count - 1, "End");
        stopwatch.Stop();
        Console.WriteLine("Вставка элемента в конец List<T>: " + stopwatch.Elapsed.TotalMilliseconds);
    }
}