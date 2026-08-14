using System;

public static class ConsolePrinter
{
    public static int LetterSpeed { get; set; } = 70;
    public static int CommaDelay { get; set; } = 250;
    public static int SentenceEndDelay { get; set; } = 250;

    public static void Print(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);

            if (i == text.Length - 1)
            {
                Console.WriteLine();
                return;
            }

            int delay = text[i] switch
            {
                ',' => CommaDelay,
                '.' or '!' or '?' => SentenceEndDelay,
                _ => LetterSpeed
            };

            System.Threading.Thread.Sleep(delay);
        }
    }

    public static void WaitForKey(ConsoleKey key)
    {
        while (Console.ReadKey(true).Key != key) { }
    }

    public static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Print(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                return value;

            Print("Enter a valid number!");
        }
    }
}