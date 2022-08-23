using System.Diagnostics;
using System.Text;

class Program
{
    const string path = "D:\\VisualStudio\\repos\\Practice_Unit13\\Text1.txt";
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
        var words = text.Split(simbol, StringSplitOptions.RemoveEmptyEntries).ToList();
        int n = 10;

        TestInsertList(words, n);

        Console.ReadKey();
    }

    /// <summary>
    /// Проверка скорости вставки новых элементов в начало, середину и конец коллекции
    /// </summary>
    /// <param name="list"></param>
    /// <param name="n"></param>
    static void TestInsertList(List<string> list, int n)
    {
        string lable = string.Empty;
        int count = 0;
        int index = 0;
        int middlePoint = list.Count / 2;

        while (count < 3)
        {
            List<string> temp = list;
            double time = 0;

            switch (count)
            {
                case 0:
                    index = 0;
                    lable = "Вставка элемента в начало List<T>...";
                    break;
                case 1:
                    index = middlePoint;
                    lable = "Вставка элемента в середину List<T>...";
                    break;
                case 2:
                    index = list.Count - 1;
                    lable = "Вставка элемента в конец List<T>...";
                    break;
            }

            Console.WriteLine(lable);
            stopwatch.Start();

            for (int i = 0; i < n; i++)
            {
                Thread.Sleep(200);

                stopwatch.Restart();
                temp.Insert(index, $"{i}");
                stopwatch.Stop();

                time += stopwatch.Elapsed.TotalMilliseconds;
                Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds + " мс");
            }

            Console.WriteLine($"Среднее время {Math.Round(time / n, 4)} мс");
            Console.WriteLine();

            count++;
        }        
    }
}