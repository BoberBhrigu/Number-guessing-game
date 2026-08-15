using System;
using System.Threading;

public static class ConsolePrinter
{
    public static int LetterSpeed = 70;
    public static int CommaDelay = 250;
    public static int SentenceEndDelay = 250;

    public static void PrintText(string text)
    {
        for (int i = 0; i < text.Length; i++)
        {
            Console.Write(text[i]);

            if (i == text.Length - 1)
            {
                Console.WriteLine();
                return;
            }

            if (text[i] == ',')
            {
                Thread.Sleep(CommaDelay);
            }
            else if (text[i] == '.' || text[i] == '!' || text[i] == '?')
            {
                Thread.Sleep(SentenceEndDelay);
            }
            else
            {
                Thread.Sleep(LetterSpeed);
            }
        }
    }

    public static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            PrintText(prompt);

            if (int.TryParse(Console.ReadLine(), out int value) &&
                value >= min &&
                value <= max)
            {
                return value;
            }

            PrintText("Enter a valid number!");
        }
    }
}