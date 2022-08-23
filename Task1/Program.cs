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
        
        string text = File.ReadAllText(path);
        char[] simbol = { ' ', '\n' };
        var words = text.Split(simbol, StringSplitOptions.RemoveEmptyEntries);
        int n = 10;

        var dataList = TestInsertList(words.ToList(), n);
        var dataLinkedList = TestInsertLinkedList(words, n);
        
        Console.WriteLine("\n");

        PrintResult(dataList, dataLinkedList);

        Console.ReadKey();
    }

    /// <summary>
    /// Сбор данных о скорости вставки новых элементов в начало, середину и конец коллекции List
    /// </summary>
    /// <param name="list"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    static (double[] first, double[] middle, double[] last) TestInsertList(List<string> list, int n)
    {
        var data = (first: new double[n], middle: new double[n], last: new double[n]);
        double[]? tempArray = null;
        int count = 0;
        int index = 0;
        int middlePoint = list.Count / 2;

        Console.WriteLine("Сбор данных о времени вставки List<T>...");

        while (count < 3)
        {
            List<string> temp = list;

            switch (count)
            {
                case 0:
                    index = 0;
                    tempArray = data.first;
                    break;
                case 1:
                    index = middlePoint;
                    tempArray = data.middle;
                    break;
                case 2:
                    index = list.Count - 1;
                    tempArray = data.last;
                    break;
            }

            stopwatch.Start();

            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(100);

                stopwatch.Restart();
                temp.Insert(index, $"{i}");
                stopwatch.Stop();

                tempArray![i] = stopwatch.Elapsed.TotalMilliseconds;
            }
            count++;
        }

        return data;
    }

    /// <summary>
    /// Сбор данных о скорости вставки новых элементов в начало, середину и конец коллекции LinkedList
    /// </summary>
    /// <param name="words"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    static (double[] first, double[] middle, double[] last) TestInsertLinkedList(string[] words, int n)
    {
        Func<string, LinkedListNode<string>>? func = default;
        LinkedListNode<string>? middleNode = default;
        var data = (first: new double[n], middle: new double[n], last: new double[n]);
        double[]? tempArray = null;
        int count = 0;

        Console.WriteLine("Сбор данных о времени вставки LinkedList<T>...");

        while (count < 3)
        {
            LinkedList<string> linkedList = new LinkedList<string>(words);

            switch (count)
            {
                case 0:
                    func += linkedList.AddFirst;
                    tempArray = data.first;
                    break;
                case 1:
                    middleNode = linkedList.Find(words[words.Length / 2])!;
                    tempArray = data.middle;
                    break;
                case 2:
                    func -= linkedList.AddFirst;
                    func += linkedList.AddLast;
                    tempArray = data.last;
                    break;
            }

            stopwatch.Start();

            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(100);

                if (count == 1)
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

                tempArray![i] = stopwatch.Elapsed.TotalMilliseconds;
            }
            count++;
        }

        return data;
    }

    /// <summary>
    /// Вывод данных в виде таблицы
    /// </summary>
    /// <param name="list"></param>
    /// <param name="linkedList"></param>
    static void PrintResult((double[] first, double[] middle, double[] last)list, (double[] first, double[] middle, double[] last)linkedList)
    {
        int count = 0;
        double[]? tempList = null;
        double[]? tempLinkedList = null;
        string lable = string.Empty;
        int n = list.first.Length;

        while(count < 3)
        {
            switch (count)
            {
                case 0:
                    tempList = list.first;
                    tempLinkedList = linkedList.first;
                    lable = "Вставка в начало списка";
                    break;
                case 1:
                    tempList = list.middle;
                    tempLinkedList = linkedList.middle;
                    lable = "Вставка в середину списка";
                    break;
                case 2:
                    tempList = list.last;
                    tempLinkedList = linkedList.last;
                    lable = "Вставка в конец списка";
                    break;
            }

            Console.WriteLine($"{lable, 35}\n");
            Console.WriteLine($"{"List<T>", 27}{"LinkedList<T>", 18}\n");

            for (int i = 0; i < n; i++)
               Console.WriteLine($"{tempList![i], 27}{tempLinkedList![i], 18}");

            Console.WriteLine($"\nСреднее значение {Math.Round(tempList!.Average(), 4), 10}{Math.Round(tempLinkedList!.Average(), 4), 18}");

            Console.WriteLine("\n");
            count++;
        }
    }
}