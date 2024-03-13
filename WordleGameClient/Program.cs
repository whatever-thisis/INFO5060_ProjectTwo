public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("+------------+");
        Console.WriteLine("|   WORDLE   |");
        Console.WriteLine("+------------+");
        Console.WriteLine("\nYou have 6 chances to guess a 5-letter word.");
        Console.WriteLine("\nEach guess must be a 5-letter word.");
        Console.WriteLine("\nAfter a guess the game will display a series of characters to show how good your guess was.");
        Console.WriteLine("\nx - means the letter above is not in the word.");
        Console.WriteLine("\n? - means the letter should be in another spot.");
        Console.WriteLine("\n* - means the letter is correct in this spot.");
    }
}
