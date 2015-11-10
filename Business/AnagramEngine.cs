using System.Collections.Generic;
using System.Linq;
namespace Business
{
    public class AnagramEngine : IAnagramEngine
    {
        public List<string> GetAnagrams(string input, List<string> words)
        {
            List<char> inputAsChar = input.ToList();
            return words.FindAll(v => inputAsChar.TrueForAll(v.Contains) && v.Length == inputAsChar.Count);
        }

        public List<string> GetContains(string input, List<string> words)
        {
            return words.FindAll(v => v.Contains(input));
        }

        public List<string> GetContainsCharsInOrder(string input, List<string> words)
        {
            List<char> inputAsChar = input.ToList();

            return words.FindAll(v => inputAsChar.TrueForAll(v.Contains)).Where(x =>
            {
                int wordLength = x.Length;
                int inputLength = inputAsChar.Count;

                for (int i = 0; i < wordLength; i++)
                {
                    for (int j = 0; j < inputLength; j++)
                    {
                        if (x[i] == inputAsChar[j] && i < j)
                            return false;
                    }
                }
                return true;
            }).ToList();
        }

        public List<string> GetContainsChars(string input, List<string> words)
        {
            List<char> inputAsChar = input.ToList();
            return words.FindAll(v => inputAsChar.TrueForAll(v.Contains));
        }
    }
}
