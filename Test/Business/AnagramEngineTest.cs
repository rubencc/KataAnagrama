using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Factories;

namespace Test.Business
{
    [TestClass]
    public class AnagramEngineTest
    {
        [TestCategory("User Story 91221"), TestMethod]
        public void Anagramas_de_roma()
        {
            List<string> dic = DicFactory.GetDic();

            List<char> inputAsChar = "roma".ToList();

            List<string> expected = new List<string>() { "amor", "maro", "mora", "ramo" };

            List<string> anagrams = dic.FindAll(v => inputAsChar.TrueForAll(v.Contains) && v.Length == inputAsChar.Count);

            AssertWords(4, anagrams, expected);
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Palabras_que_contienen_roma()
        {
            List<string> dic = new List<string>(){"reroma", "metro", "calzada", "broma"};

            string input = "roma";

            List<string> expected = new List<string>() { "reroma", "broma"};

            List<string> contains = dic.FindAll(v => v.Contains(input));

            AssertWords(2, contains, expected);
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Palabras_que_contienen_los_caractees_de_roma_en_el_mismo_orden()
        {
            List<string> dic = new List<string>() { "ramo", "armo", "calzada", "broma", "rompa" };

            List<char> inputAsChar = "roma".ToList();

            List<string> expected = new List<string>() { "broma","rompa"};

            List<string> contains = dic.FindAll(v => inputAsChar.TrueForAll(v.Contains)).Where(x =>
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

            AssertWords(2, contains, expected);
        }

        [TestCategory("User Story 91221"), TestMethod]
        public void Palabras_que_contienen_los_caractees_de_roma()
        {
            List<string> dic = new List<string>() { "ramo", "armo", "calzada", "broma", "rompa", "mejorar", "romo" };

            List<char> inputAsChar = "roma".ToList();

            List<string> expected = new List<string>() { "ramo", "armo", "broma", "rompa", "mejorar" };

            List<string> contains = dic.FindAll(v => inputAsChar.TrueForAll(v.Contains));

            AssertWords(5, contains, expected);
        }

        private void AssertWords(int count, List<string> anagrams, List<string> expected)
        {
            Assert.AreEqual(count, anagrams.Count, "El numero de anagramas no es correcto. Deberia ser {0}", count);
            CollectionAssert.AreEqual(expected, anagrams, "Los elementos no coinciden");
        }
    }
}
