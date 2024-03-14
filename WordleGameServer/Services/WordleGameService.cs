using Grpc.Core;
using WordleGameServer;

namespace WordleGameServer.Services
{
    public class WordleGameService: WordleGameServer.WordleGameServerBase
    {
        private readonly WordServer.DailyWord.DailyWordBase words;

        public override async Task Play(IAsyncStreamReader<GuessRequest> requestStream, IServerStreamWriter<GuessResponse> responseStream, ServerCallContext context)
        {
            string wordToGuess = await GetWordToGuess();

            int turnsUsed = 0;
            bool gameWon = false;
            char[] results = new char[5];

            while (!gameWon && await requestStream.MoveNext() && turnsUsed < 6)
            {
                turnsUsed++;
                string wordPlayed = requestStream.Current.Guess;

                if (wordPlayed == wordToGuess)
                {
                    gameWon = true;
                    Array.Fill(results, '*');
                }
                else
                {
                    Dictionary<char, int> matches = new Dictionary<char, int>()
            {
                {'a', 0}, {'b', 0}, {'c', 0}, {'d', 0}, {'e', 0}, {'f', 0}, {'g', 0}, {'h', 0}, {'i', 0},
                {'j', 0}, {'k', 0}, {'l', 0}, {'m', 0}, {'n', 0}, {'o', 0}, {'p', 0}, {'q', 0}, {'r', 0},
                {'s', 0}, {'t', 0}, {'u', 0}, {'v', 0}, {'w', 0}, {'x', 0}, {'y', 0}, {'z', 0}
            };

                    // Search word-played for letters that are in the correct position
                    for (int i = 0; i < wordPlayed.Length; i++)
                    {
                        char letter = wordPlayed[i];
                        if (letter == wordToGuess[i])
                        {
                            results[i] = '*';
                            matches[letter]++;
                        }
                    }

                    // Search word-played for additional correct letters that are not in the correct position
                    for (int i = 0; i < wordPlayed.Length; i++)
                    {
                        char letter = wordPlayed[i];
                        if (wordToGuess.Count(c => c == letter) == 0)
                        {
                            results[i] = 'x';
                        }
                        else if (letter != wordToGuess[i])
                        {
                            if (matches[letter] < wordToGuess.Count(c => c == letter))
                            {
                                results[i] = '?';
                                matches[letter]++;
                            }
                        }
                    }
                }

                // Send response to client
                await responseStream.WriteAsync(new GuessResponse
                {
                    IsCorrect = gameWon,
                    CorrectLetters = new List<string>(results.Select(c => c.ToString()))
                });
            }
        }

        private async Task<string> GetWordToGuess()
        {
            // Call the WordServer to get the word-to-guess
            var wordResponse = await words.GetWord(new WordServer.Empty());
            return wordResponse.Word;
        }


    }
}
