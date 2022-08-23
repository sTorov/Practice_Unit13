using System.Diagnostics;
using System.Text;

class Program
{
    const string path = "D:\\VisualStudio\\repos\\Practice_Unit13\\Text1.txt";
    private static Stopwatch stopwatch = new Stopwatch();

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        if(!File.Exists(path))
        {
            Console.WriteLine("Файл не существует!");
            return;
        }

        string text = File.ReadAllText(path);
        char[] simbol = { ' ', '\n' };
        var words = text.Split(simbol, StringSplitOptions.RemoveEmptyEntries);
        int n = 10;        

        TestInsert(words, n);

        Console.ReadKey();
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в начало, середину и конец коллекции
    /// </summary>
    /// <param name="words"></param>
    /// <param name="n"></param>
    static void TestInsert(string[] words, int n)
    {
        Func<string, LinkedListNode<string>>? func = default;
        LinkedListNode<string>? middleNode = default;
        double time = 0;
        int count = 0;
        string lable = string.Empty;

        while(count < 3)
        {
            LinkedList<string> linkedList = new LinkedList<string>(words);
            time = 0;

            switch (count)
            {
                case 0:
                    lable = "Вставка элемента в начало LinkedList<T>...";
                    func += linkedList.AddFirst;
                    break;
                case 1:
                    lable = "Вставка элемента в середину LinkedList<T>...";
                    middleNode = linkedList.Find(words[words.Length / 2])!;
                    break;
                case 2:
                    lable = "Вставка элемента в конец LinkedList<T>...";
                    func -= linkedList.AddFirst;
                    func += linkedList.AddLast;
                    break;
            }

            Console.WriteLine(lable);
            stopwatch.Start();

            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(200);

                if(count == 1)
                {
                    stopwatch.Restart();
                    linkedList.AddBefore(middleNode!, $"{i}");
                    stopwatch.Stop();
                }
                else
                {
                    stopwatch.Restart();
                    func!($"{i}");
                    stopwatch.Stop();
                }

                time += stopwatch.Elapsed.TotalMilliseconds;
                Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
            }

            Console.WriteLine($"Среднее время {Math.Round(time / n, 4)} мс");
            Console.WriteLine();

            count++;
        }        
    }
}