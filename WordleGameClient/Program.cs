using Grpc.Core;
using Grpc.Net.Client;
using WordServer;

try
{
    // The URL of the gRPC server.
    var channel = GrpcChannel.ForAddress("http://localhost:5045");
    var client = new DailyWord.DailyWordClient(channel);

    try
    {
        // Call the GetWord RPC method.
        var response = await client.GetWordAsync(new Empty());
        Console.WriteLine("Received word of the day: " + response.Word);
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred: " + ex.Message);
    }

    Console.ReadLine(); // Keep console window open
}
catch(RpcException)
{
    Console.WriteLine("\nERROR: The math quiz service is not currently available.");
}

/*public class Program
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
*/