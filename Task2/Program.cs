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
        Dictionary<string, int> dictionary = new();

        for(int i = 0; i < words.Length; i++)
        {
            if(dictionary.ContainsKey(words[i]))
                dictionary[words[i]]++;
            else
                dictionary.Add(words[i], 1);
        }

        var sortedDictionary = dictionary.OrderByDescending(x => x.Value);

        Console.WriteLine("10 самых часто используемых слов в тексте\n");
        Console.WriteLine("{0, -6} | {1, -11}", "Слово", "Повторений");
        Console.WriteLine("===================");

        int j = 0;
        foreach (var pair in sortedDictionary)
        {
            if (j == 10)
                break;
            Console.WriteLine($"{pair.Key, -6} | {pair.Value, -11}");
            j++;
        }    

        Console.ReadKey();
    }
}