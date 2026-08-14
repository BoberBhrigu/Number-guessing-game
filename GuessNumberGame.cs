using System;

public class GuessNumberGame
{
    private readonly Random _random = new();

    private readonly int[] _easy = { 1, 100 };
    private readonly int[] _medium = { 1, 1000 };
    private readonly int[] _hard = { 1, 10000 };

    private readonly string[] _wrongComments =
    {
        "Nope!", "Try again...", "Wrong!",
        "Not even close 😴", "Nah.", "Keep trying..."
    };

    public void Run()
    {
        ShowIntro();
        int[] range = SelectDifficulty();
        int secretNumber = _random.Next(range[0], range[1] + 1);

        ConsolePrinter.Print("Ok, let's start the game!");
        Console.Clear();

        PlayRound(secretNumber);
    }

    private void ShowIntro()
    {
        ConsolePrinter.Print("Hi! This is the \"Guess the Number\" game. Ready to start?");
        ConsolePrinter.Print("Press the space to start.");
        ConsolePrinter.WaitForKey(ConsoleKey.Spacebar);
    }

    private int[] SelectDifficulty()
    {
        ConsolePrinter.Print("Choose a difficulty level: 1 (easy) to 3 (hard).");
        int level = ConsolePrinter.ReadInt("", 1, 3);

        int[] range = level switch
        {
            1 => _easy,
            2 => _medium,
            _ => _hard
        };

        ConsolePrinter.Print($"You chose difficulty level {level}.");
        ConsolePrinter.Print($"I picked a number between {range[0]} and {range[1]}.");

        return range;
    }

    private void PlayRound(int secretNumber)
    {
        int attempts = 0;

        while (true)
        {
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                ConsolePrinter.Print("Enter a valid number!");
                continue;
            }

            attempts++;

            if (guess < secretNumber)
            {
                ConsolePrinter.Print($"{_wrongComments[attempts % _wrongComments.Length]} Too low!");
            }
            else if (guess > secretNumber)
            {
                ConsolePrinter.Print($"{_wrongComments[attempts % _wrongComments.Length]} Too high!");
            }
            else
            {
                ConsolePrinter.Print($"Correct! The number was {secretNumber}.");
                ConsolePrinter.Print($"You guessed it in {attempts} attempts!");
                break;
            }
        }
    }
}