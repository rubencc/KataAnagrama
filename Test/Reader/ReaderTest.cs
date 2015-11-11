using System;
using System.Collections.Generic;
using Business.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Reader
{
    
    [TestClass]
    public class ReaderTest
    {
        [TestCategory("Leer fichero"), TestMethod]
        public void Leer_un_fichero()
        {
            FileReader reader = new FileReader("test.txt");

            List<string> expected = this.GetDictionary();

            List<string> list = reader.Load();

            AssertDic(3, list, expected);
        }

        [TestCategory("Leer fichero"), TestMethod]
        public void Leer_un_fichero_que_no_existe()
        {
            FileReader reader = new FileReader("notfound.txt");

            List<string> expected = new List<string>();

            List<string> list = reader.Load();

            AssertDic(0, list, expected);
        }

        [TestCategory("Leer fichero"), TestMethod]
        public void Leer_un_fichero_vacio()
        {
            FileReader reader = new FileReader("empty.txt");

            List<string> expected = new List<string>();

            List<string> list = reader.Load();

            AssertDic(0, list, expected);
        }

        [TestCategory("Leer fichero"), TestMethod]
        public void Leer_un_fichero_con_caracteres_no_validos()
        {
            FileReader reader = new FileReader("otherChars.txt");

            List<string> expected = new List<string>(){"presente"};

            List<string> list = reader.Load();

            AssertDic(1, list, expected);
        }

        [TestCategory("Leer fichero"), TestCategory("Bug 66066"), TestMethod]
        public void Inicializar_la_clase_FileReader_con_valor_null()
        {
            try
            {
                FileReader reader = new FileReader(null);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestCategory("Leer fichero"), TestCategory("Bug 66066"), TestMethod]
        public void Inicializar_la_clase_FileReader_con_valor_empty()
        {
            try
            {
                FileReader reader = new FileReader(String.Empty);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        private List<string> GetDictionary()
        {
            return new List<string>() { "fichero", "de", "prueba" };
        }

        private void AssertDic(int count, List<string> list, List<string> expected)
        {
            Assert.AreEqual(count, list.Count, "El resultado deberia ser {0}", count);
            CollectionAssert.AreEqual(expected, list, "Las listas no contiene los mismos elementos");
        }
    }
}
