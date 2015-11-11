using System.Collections.Generic;
using Business.Tracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test.Mocks;

namespace Test.Business
{
    [TestClass]
    public class TrackerTest
    {
        private Tracker tracker;
        private LoggerMock loggerMock;
        private AnagramEngineMock anagramEngineMock;
        private List<string> interestingWords;

        [TestInitialize]
        public void Setup()
        {
            this.interestingWords = new List<string>();
            this.loggerMock = new LoggerMock();
            this.anagramEngineMock = new AnagramEngineMock();
            this.tracker = new Tracker(this.anagramEngineMock.Mock, interestingWords, this.loggerMock.Mock);
        }

        [TestCleanup]
        public void Clean()
        {
            this.tracker = null;
        }

        [TestCategory("Tracking"), TestMethod]
        public void Se_detecta_palabra_interesante_en_el_input_arma()
        {
            string input = "arma";

            this.interestingWords.Add(input);

            this.anagramEngineMock.SetupGetAnagram(input, new List<string>());

            List<string> result = this.tracker.GetAnagrams(input, new List<string>());

            CollectionAssert.AreEqual(new List<string>(), result, "Se ha modificado el resultado de la funcion de obtener anagramas");

            this.anagramEngineMock.VerifyGetAnagram(input, Times.Once());
            this.loggerMock.VerifyLog(this.CreateLogString(input, "192.168.1.1", "España","Español (España)"), Times.Once());
        }

        [TestCategory("Tracking"), TestMethod]
        public void Se_detecta_palabra_interesante_en_el_resultado_rama()
        {
            string input = "rama";

            this.interestingWords.Add("arma");

            List<string> anagrams = new List<string>() {"arma"};

            this.anagramEngineMock.SetupGetAnagram(input, anagrams);

            List<string> result = this.tracker.GetAnagrams(input, new List<string>());

            CollectionAssert.AreEqual(anagrams, result, "Se ha modificado el resultado de la funcion de obtener anagramas");

            this.anagramEngineMock.VerifyGetAnagram(input, Times.Once());
            this.loggerMock.VerifyLog(this.CreateLogString(input, "192.168.1.1", "España", "Español (España)"), Times.Once());
        }

        [TestCategory("Tracking"), TestMethod]
        public void No_se_detecta_palabra_interesante()
        {
            string input = "marca";

            this.anagramEngineMock.SetupGetAnagram(input, new List<string>());

            List<string> result = this.tracker.GetAnagrams(input, new List<string>());

            CollectionAssert.AreEqual(new List<string>(), result, "Se ha modificado el resultado de la funcion de obtener anagramas");

            this.anagramEngineMock.VerifyGetAnagram(input, Times.Once());
            this.loggerMock.VerifyLogNever();
        }

        private string CreateLogString(string input, string ip, string country, string language)
        {
            return string.Format("Word: {0} --- IP: {1}, Country: {2}, Language: {3}", input, ip, country, language);
        }
    }
}
