using System.Collections.Generic;

namespace Business
{
    public interface IAnagramEngine
    {
        List<string> GetAnagrams(string input, List<string> words);
        List<string> GetContains(string input, List<string> words);
        List<string> GetContainsCharsInOrder(string input, List<string> words);
        List<string> GetContainsChars(string input, List<string> words);
    }
}
