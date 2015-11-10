using System;
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

            return words.Where(x =>
            {
                List<char> wordAsChar = x.ToList();
                wordAsChar.RemoveAll( c => !inputAsChar.Contains(c));
                string word = String.Concat(wordAsChar);

                return word == input;
            }).ToList();
        }

        public List<string> GetContainsChars(string input, List<string> words)
        {
            List<char> inputAsChar = input.ToList();
            return words.FindAll(v => inputAsChar.TrueForAll(v.Contains));
        }
    }
}
