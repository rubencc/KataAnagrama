using System.Collections.Generic;
using Business.Reader;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.Reader
{
    [TestClass]
    public class ReaderTest
    {
        [TestMethod]
        public void Leer_un_fichero()
        {
            FileReader reader = new FileReader();

            List<string> expected = new List<string>(){"fichero", "de", "prueba"};

            List<string> list = reader.Load("test.txt");

            Assert.AreEqual(3, list.Count, "El resultado deberia ser 3");
            CollectionAssert.AreEqual(expected, list, "Las listas no contiene los mismos elementos");
        }
    }
}
