using System;
using System.Collections.Generic;
using Business.Log;
using UserManagment;

namespace Business.Tracker
{
    public class Tracker : IAnagramEngine
    {
        private readonly IAnagramEngine root;
        private readonly List<string> interestingWords;
        private readonly ILogger logger;

        public Tracker(IAnagramEngine root, List<string> interestingWords, ILogger logger)
        {
            if (root == null || interestingWords == null || logger == null)
            {
                throw new ArgumentNullException();
            }

            this.root = root;
            this.interestingWords = interestingWords;
            this.logger = logger;
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

            string toLog = string.Format("Word: {0} --- IP: {1}, Country: {2}, Language: {3}", input,
                userInfo.Ip, userInfo.Country, userInfo.Language);

            this.logger.Log(toLog);
        }
    }
}
