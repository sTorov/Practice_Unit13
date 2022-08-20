using System.Text;

class Program
{
    const string path = "Text1.txt";

    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        
        if(!File.Exists(path))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        string text = File.ReadAllText(path).ToLower();
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        char[] ch = { ' ', '\n' };
        string[] words = noPunctuationText.Split(ch, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> dictionary = new Dictionary<string, int>();

        for(int i = 0; i < words.Length; i++)
        {
            if(dictionary.ContainsKey(words[i]))
                dictionary[words[i]]++;
            else
                dictionary.Add(words[i], 1);
        }

        var sortedDictionary = dictionary.OrderByDescending(x => x.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        Console.WriteLine("{0} | {1, 22}", "Слово", "Количество повторений");
        Console.WriteLine("================");

        int j = 0;
        foreach (var pair in sortedDictionary)
        {
            if (j == 10)
                break;
            Console.WriteLine($"{pair.Key, 5} | {pair.Value, 5}");
            j++;
        }    

        Console.ReadKey();
    }
}