using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const string path = "Text1.txt";
    private static Stopwatch stopwatch = new Stopwatch();
    
    static void Main(string[] args)
    {
        string text = File.ReadAllText(path);
        char[] simbol = { ' ', '\n' };
        var words = text.Split(simbol, StringSplitOptions.RemoveEmptyEntries);

        TestList(words);

        Console.WriteLine();

        TestLinkedList(words);

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

        stopwatch.Restart();
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

    /// <summary>
    /// Проверка скорости вставки новых элементов в коллекцию LinkedList
    /// </summary>
    /// <param name="words"></param>
    static void TestLinkedList(string[] words)
    {
        LinkedList<string> linkedList = new LinkedList<string>(words);
        LinkedListNode<string> node = linkedList.Find(words[words.Length / 2])!;

        stopwatch.Restart();
        linkedList.AddBefore(node, "Middle");
        stopwatch.Stop();
        Console.WriteLine("Вставка элемента в середину LinkedList<T>: " + stopwatch.Elapsed.TotalMilliseconds);

        stopwatch.Restart();
        linkedList.AddFirst("Start");
        stopwatch.Stop();
        Console.WriteLine("Вставка элемента в начало LinkedList<T>: " + stopwatch.Elapsed.TotalMilliseconds);

        stopwatch.Restart();
        linkedList.AddLast("End");
        stopwatch.Stop();
        Console.WriteLine("Вставка элемента в конец LinkedList<T>: " + stopwatch.Elapsed.TotalMilliseconds);
    }
}