using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Factories;

namespace Test.Business
{
    [TestClass]
    public class AnagramEngineTest
    {

        private AnagramEngine anagramEngine;

        [TestInitialize]
        public void Setup()
        {
            this.anagramEngine = new AnagramEngine();
        }

        [TestCleanup]
        public void Clean()
        {
            this.anagramEngine = null;
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Anagramas_de_roma()
        {
            List<string> dic = DicFactory.GetDic();

            string input = "roma";

            List<string> expected = new List<string>() { "amor", "maro", "mora", "ramo" };

            List<string> anagrams = this.anagramEngine.GetAnagrams(input, dic);

            AssertWords(4, anagrams, expected);
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Palabras_que_contienen_roma()
        {
            List<string> dic = new List<string>(){"reroma", "metro", "calzada", "broma"};

            string input = "roma";

            List<string> expected = new List<string>() { "reroma", "broma"};

            List<string> contains = this.anagramEngine.GetContains(input, dic);

            AssertWords(2, contains, expected);
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Palabras_que_contienen_los_caractees_de_roma_en_el_mismo_orden()
        {
            List<string> dic = new List<string>() { "ramo", "armo", "calzada", "broma", "rompa" };

            string input = "roma";

            List<string> expected = new List<string>() { "broma","rompa"};

            List<string> contains = this.anagramEngine.GetContainsCharsInOrder(input, dic);

            AssertWords(2, contains, expected);
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Palabras_que_contienen_los_caracteres_de_roma()
        {
            List<string> dic = new List<string>() { "ramo", "armo", "calzada", "broma", "rompa", "mejorar", "romo" };

            string input = "roma";

            List<string> expected = new List<string>() { "ramo", "armo", "broma", "rompa", "mejorar" };

            List<string> contains = this.anagramEngine.GetContainsChars(input, dic);

            AssertWords(5, contains, expected);
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Anagramas_de_empty()
        {
            List<string> dic = DicFactory.GetDic();

            List<string> expected = new List<string>();

            List<string> anagrams = this.anagramEngine.GetAnagrams(string.Empty, dic);

            AssertWords(0, anagrams, expected);
        }

        private void AssertWords(int count, List<string> anagrams, List<string> expected)
        {
            Assert.AreEqual(count, anagrams.Count, "El numero de palabras no es correcto. Deberia ser {0}", count);
            CollectionAssert.AreEqual(expected, anagrams, "Los elementos no coinciden");
        }
    }
}
