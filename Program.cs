using System;

int LetterSpeed = 70; // Speed of letters in milliseconds
int CommaDelay = 250; // Delay after a comma in milliseconds
int sentenceEndDelay = 250; // Delay after a sentence-ending punctuation in milliseconds (., !, ?)

int[] easy = { 1, 100 };
int[] medium = { 1, 1000 };
int[] hard = { 1, 10000 };

Random random = new Random();

void PrintText(string text)
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
            System.Threading.Thread.Sleep(CommaDelay);
        }
        else if (text[i] == '.' || text[i] == '!' || text[i] == '?')
        {
            System.Threading.Thread.Sleep(sentenceEndDelay);
        }
        else
        {
            System.Threading.Thread.Sleep(LetterSpeed);
        }
    }
}

int RandomNumber(int min, int max)
{
    max++; // Increment max to make it inclusive
    return random.Next(min, max);
}

PrintText("Hi! This is the \"Guess the Number\" game. Ready to start?");
PrintText("Press the space to start.");

while (true)
{
    ConsoleKeyInfo key = Console.ReadKey(true);

    if (key.Key == ConsoleKey.Spacebar)
    {
        break;
    }
}

PrintText("Choose a difficulty level: 1 (easy) to 3 (hard).");

int difficultyLevel;
while (!int.TryParse(Console.ReadLine(), out difficultyLevel) || difficultyLevel < 1 || difficultyLevel > 3)
{
    PrintText("Enter a number from 1 to 3.");
}


PrintText($"You chose difficulty level {difficultyLevel}.");
int[] selectedRange;

if (difficultyLevel == 1)
{
    selectedRange = easy;
    PrintText($"You chose Easy. I picked a number between {easy[0]} and {easy[1]}.");
}
else if (difficultyLevel == 2)
{
    selectedRange = medium;
    PrintText($"You chose Medium. I picked a number between {medium[0]} and {medium[1]}.");
}
else
{
    selectedRange = hard;
    PrintText($"You chose Hard. I picked a number between {hard[0]} and {hard[1]}.");
}

int secretNumber = RandomNumber(selectedRange[0], selectedRange[1]);

PrintText("ok, let's start the game!");
Console.Clear();

int attempts = 0;
string[] wrongComments = { "Nope!", "Try again...", "Wrong!", "Not even close 😴", "Nah.", "Keep trying..." };

while (true)
{
    string? input = Console.ReadLine();
    int guess;

    if (!int.TryParse(input, out guess))
    {
        PrintText("Enter a valid number!");
        continue;
    }

    attempts++;

    if (guess < secretNumber)
    {
        PrintText($"{wrongComments[attempts % wrongComments.Length]} Too low!");
    }
    else if (guess > secretNumber)
    {
        PrintText($"{wrongComments[attempts % wrongComments.Length]} Too high!");
    }
    else
    {
        PrintText($"Correct! The number was {secretNumber}.");
        PrintText($"You guessed it in {attempts} attempts!");
        break;
    }
}
