using System;
using System.Collections.Generic;
using UserManagment;

namespace Business.Tracker
{
    public class Tracker : IAnagramEngine
    {
        private readonly IAnagramEngine root;
        private readonly List<string> interestingWords;

        public Tracker(IAnagramEngine root, List<string> interestingWords)
        {
            if (root == null || interestingWords == null)
            {
                throw new ArgumentNullException();
            }

            this.root = root;
            this.interestingWords = interestingWords;
        }

        public List<string> GetAnagrams(string input, List<string> words)
        {
            List<string> result = this.root.GetAnagrams(input, words);

            this.AnalyzeQuery(input, result);

            return result;
        }

        public List<string> GetContains(string input, List<string> words)
        {
            List<string> result = this.root.GetContains(input, words);
            this.AnalyzeQuery(input, result);

            return result;
        }

        public List<string> GetContainsCharsInOrder(string input, List<string> words)
        {
            List<string> result = this.root.GetContainsCharsInOrder(input, words);

            this.AnalyzeQuery(input, result);

            return result;
        }

        public List<string> GetContainsChars(string input, List<string> words)
        {
            List<string> result = this.root.GetContainsChars(input, words);

            this.AnalyzeQuery(input, result);

            return result;
        }

        private void AnalyzeQuery(string input, List<string> result)
        {
            if (this.ContainsWords(input, result))
            {
                this.TrackQuery(input);
            }
        }

        private bool ContainsWords(string input, List<string> result)
        {
            return this.interestingWords.Contains(input) || this.interestingWords.FindAll(result.Contains).Count > 0;
        }

        private void TrackQuery(string input)
        {
            IUserInfo userInfo = UserInfo.Instance;

            Console.WriteLine("Word: {4} --- IP: {0}, Country: {1}, Language: {2}, SearchTime: {3}", userInfo.Ip, userInfo.Country, userInfo.Language, userInfo.Time, input);
        }
    }
}
