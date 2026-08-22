
using System;

public class GuessNumberGame
{
    private readonly int[] easy = { 1, 100 };
    private readonly int[] medium = { 1, 1000 };
    private readonly int[] hard = { 1, 10000 };

    private readonly Random random = new Random();

    private int RandomNumber(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    public void Run()
    {
        while (true)
        {
            ConsolePrinter.PrintText(
                "Hi! This is the \"Guess the Number\" game. Ready to start?"
            );

            ConsolePrinter.PrintText("0 exit 1 start 2 settings");

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D0:
                    Environment.Exit(0);
                    break;

                case ConsoleKey.D1:
                    StartGame();
                    break;

                case ConsoleKey.D2:
                    OpenSettings();
                    break;

                default:
                    ConsolePrinter.PrintText("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void StartGame()
    {
        ConsolePrinter.PrintText(
            "Choose difficulty: 1 easy 2 medium 3 hard"
        );

        int difficulty = ConsolePrinter.ReadInt(
            "Enter difficulty (1-3): ",
            1,
            3
        );

        int min;
        int max;

        switch (difficulty)
        {
            case 1:
                min = easy[0];
                max = easy[1];
                break;

            case 2:
                min = medium[0];
                max = medium[1];
                break;

            case 3:
                min = hard[0];
                max = hard[1];
                break;

            default:
                return;
        }

        int numberToGuess = RandomNumber(min, max);
        int attempts = 0;

        ConsolePrinter.PrintText(
            $"I have chosen a number between {min} and {max}. Try to guess it!"
        );

        while (true)
        {
            int playerGuess = ConsolePrinter.ReadInt(
                $"Enter your guess ({min}-{max}): ",
                min,
                max
            );

            attempts++;

            if (playerGuess < numberToGuess)
            {
                ConsolePrinter.PrintText("Too low! Try again.");
            }
            else if (playerGuess > numberToGuess)
            {
                ConsolePrinter.PrintText("Too high! Try again.");
            }
            else
            {
                ConsolePrinter.PrintText(
                    $"Congratulations! You've guessed the number {numberToGuess} in {attempts} attempts."
                );

                break;
            }
        }
    }

    private void OpenSettings()
    {
        while (true)
        {
            ConsolePrinter.PrintText(
                "1 Set letter speed 2 Set comma delay 3 Set sentence end delay 4 Exit"
            );

            ConsoleKeyInfo settingsKey = Console.ReadKey(true);

            switch (settingsKey.Key)
            {
                case ConsoleKey.D1:
                    int newSpeed = ConsolePrinter.ReadInt(
                        "Enter new letter speed (ms): ",
                        0,
                        1000
                    );

                    ConsolePrinter.LetterSpeed = newSpeed;

                    ConsolePrinter.PrintText(
                        $"Letter speed set to {newSpeed} ms."
                    );
                    break;

                case ConsoleKey.D2:
                    int newDelay = ConsolePrinter.ReadInt(
                        "Enter new comma delay (ms): ",
                        0,
                        1000
                    );

                    ConsolePrinter.CommaDelay = newDelay;

                    ConsolePrinter.PrintText(
                        $"Comma delay set to {newDelay} ms."
                    );
                    break;

                case ConsoleKey.D3:
                    int newEndDelay = ConsolePrinter.ReadInt(
                        "Enter new sentence end delay (ms): ",
                        0,
                        1000
                    );

                    ConsolePrinter.SentenceEndDelay = newEndDelay;

                    ConsolePrinter.PrintText(
                        $"Sentence end delay set to {newEndDelay} ms."
                    );
                    break;

                case ConsoleKey.D4:
                    return;

                default:
                    ConsolePrinter.PrintText(
                        "Invalid option. Please try again."
                    );
                    break;
            }
        }
    }
}