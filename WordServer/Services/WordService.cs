using Grpc.Core;
using WordServer;

public class WordService : DailyWord.DailyWordBase
{
    private readonly string wordleJsonPath = "wordle.json";
    private List<string> words;
    private string currentWord;
    private DateTime currentDate;
    private int numForDay;

    public WordService()
    {
        LoadWords();
        currentDate = DateTime.Today;
        currentWord = GetWordForDate(currentDate);
    }

    private void LoadWords()
    {
        try
        {
            string json = File.ReadAllText(wordleJsonPath);
            words = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading words: " + ex.Message);
            words = new List<string>();
        }
    }

    private string GetWordForDate(DateTime date)
    {
        numForDay = date.Year + date.Month + date.Day; 
        Random random = new (numForDay);
        return words[random.Next(words.Count)];
    }

    public override Task<WordResponse> GetWord(Empty request, ServerCallContext context)
    {
        if (DateTime.Today != currentDate)
        {
            currentDate = DateTime.Today;
            currentWord = GetWordForDate(currentDate);
        }

        return Task.FromResult(new WordResponse { Word = currentWord });
    }

    public override Task<ValidateResponse> ValidateWord(WordRequest request, ServerCallContext context)
    {
        bool isValid = words.Exists(w => w.Equals(request.Word, StringComparison.OrdinalIgnoreCase));
        return Task.FromResult(new ValidateResponse { IsValid = isValid });
    }
}
