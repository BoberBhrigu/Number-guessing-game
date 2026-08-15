using System;

public class GuessNumberGame
{
    int[] easy = { 1, 100 };
    int[] medium = { 1, 1000 };
    int[] hard = { 1, 10000 };

    Random random = new Random();

    int RandomNumber(int min, int max)
    {
        max++;
        return random.Next(min, max);
    }

    public void Run()
    {
        ConsolePrinter.PrintText("Hi! This is the \"Guess the Number\" game. Ready to start?");
        ConsolePrinter.PrintText("Press the space to start.");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Spacebar)
            {
                break;
            }
        }

        ConsolePrinter.PrintText("Choose a difficulty level: 1 (easy) to 3 (hard).");

        int difficultyLevel = ConsolePrinter.ReadInt("Enter a number from 1 to 3.", 1, 3);

        ConsolePrinter.PrintText($"You chose difficulty level {difficultyLevel}.");
        int[] selectedRange;

        if (difficultyLevel == 1)
        {
            selectedRange = easy;
            ConsolePrinter.PrintText($"You chose Easy. I picked a number between {easy[0]} and {easy[1]}.");
        }
        else if (difficultyLevel == 2)
        {
            selectedRange = medium;
            ConsolePrinter.PrintText($"You chose Medium. I picked a number between {medium[0]} and {medium[1]}.");
        }
        else
        {
            selectedRange = hard;
            ConsolePrinter.PrintText($"You chose Hard. I picked a number between {hard[0]} and {hard[1]}.");
        }

        int secretNumber = RandomNumber(selectedRange[0], selectedRange[1]);

        ConsolePrinter.PrintText("ok, let's start the game!");
        Console.Clear();

        int attempts = 0;
        string[] wrongComments = { "Nope!", "Try again...", "Wrong!", "Not even close 😴", "Nah.", "Keep trying..." };

        while (true)
        {
            string? input = Console.ReadLine();
            int guess;

            if (!int.TryParse(input, out guess))
            {
                ConsolePrinter.PrintText("Enter a valid number!");
                continue;
            }

            attempts++;

            if (guess < secretNumber)
            {
                ConsolePrinter.PrintText($"{wrongComments[attempts % wrongComments.Length]} Too low!");
            }
            else if (guess > secretNumber)
            {
                ConsolePrinter.PrintText($"{wrongComments[attempts % wrongComments.Length]} Too high!");
            }
            else
            {
                ConsolePrinter.PrintText($"Correct! The number was {secretNumber}.");
                ConsolePrinter.PrintText($"You guessed it in {attempts} attempts!");
                break;
            }
        }
    }
}