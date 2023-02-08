using KnutMorrisPratt;
using System.Diagnostics;

static class Programm
{
    static int T = 1000;
    static string sub = "Twenty men were convicted";
    public static void Main()
    {
       SearchInBook();
    }

    static void SearchInBook()
    {
        string text = GetBook();
        string substring = sub;

        FSM fSM = new FSM();

        Console.WriteLine($"ПОИСК СТРОКИ, КОТОРАЯ ВСТРЕЧАЕТСЯ В КНИГЕ");
        //Console.WriteLine($"Поиск строки, длинной {substring.Length}, в тексте, длинной {text.Length}, " +
        //    $"методом FSM занимает {Search(fSM.Search, substring, text)} мс.");

        KMP kMP = new KMP();

        Console.WriteLine($"Поиск строки, длинной {substring.Length}, в тексте, длинной {text.Length}, " +
                   $"методом SlowPrefixFunc занимает {Search(kMP.SearchSlow, substring, text)} мс.");

        Console.WriteLine($"Поиск строки, длинной {substring.Length}, в тексте, длинной {text.Length}, " +
                  $"методом FastPrefixFunc занимает {Search(kMP.SearchFast, substring, text)} мс.");
        Console.WriteLine();

        substring = "Такой подстроки в тексте нет";
        Console.WriteLine($"ПОИСК СТРОКИ, КОТОРАЯ НЕ ВСТРЕЧАЕТСЯ В КНИГЕ");

        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, " +
            $"методом SlowPrefixFunc занимает {Search(kMP.SearchSlow, substring, text)} мс.");

        Console.WriteLine($"Поиск строки, длиной {substring.Length}, в тексте, длиной {text.Length}, " +
            $"методом FastPrefixFunc занимает {Search(kMP.SearchFast, substring, text)} мс.");
        Console.ReadLine();
    }

    static long Search(Func<string, string, int> searchMethod, string substring, string text)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int count = 0;
        while (count < T)
        {
            var pos = searchMethod.Invoke(substring, text);
            count++;
        }
        sw.Stop();
        return sw.ElapsedMilliseconds;
    }
    static string GetBook()
    {
        string path = Environment.CurrentDirectory + @"\text.doc";
        return File.ReadAllText(path);
    }

}
