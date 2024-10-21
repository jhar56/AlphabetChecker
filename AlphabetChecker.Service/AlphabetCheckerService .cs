using AlphabetChecker.Service.Interface;
using Microsoft.Extensions.Logging;


namespace AlphabetChecker.Service
{
    public class AlphabetCheckerService : IAlphabetCheckerService
    {
        private readonly ILogger<AlphabetCheckerService> _logger;

        public AlphabetCheckerService(ILogger<AlphabetCheckerService> logger)
        {
            _logger = logger;
        }

        public bool ContainsAllLetters(string input)
        {
            _logger.LogInformation("Checking input string for all letters of the alphabet: {input}", input);

            if (string.IsNullOrEmpty(input))
            {
                _logger.LogWarning("Input string is null or empty.");
                return false;
            }

            // Normalize input by converting to lower case and filtering letters
            var normalizedInput = new string(input.ToLower().Where(char.IsLetter).ToArray());

            // Check if it contains all letters (a-z)
            var result = "abcdefghijklmnopqrstuvwxyz".All(normalizedInput.Contains);

            if (result)
            {
                _logger.LogInformation("The input string contains all the letters of the alphabet.");
            }
            else
            {
                _logger.LogWarning("The input string does not contain all the letters of the alphabet.");
            }

            return result;
        }
    }
}
