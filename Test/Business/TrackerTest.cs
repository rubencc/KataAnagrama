using System;
using System.Collections.Generic;
using Business.Log;
using Business.Tracker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Test.Mocks;
using Test.Mocks.Infraestructure;

namespace Test.Business
{
    [TestClass]
    public class TrackerTest
    {
        private Tracker tracker;
        private MockObject<ILogger> loggerMock;
        private AnagramEngineMock anagramEngineMock;
        private List<string> interestingWords;

        [TestInitialize]
        public void Setup()
        {
            this.interestingWords = new List<string>();
            //Mock creados con la factoria
            this.loggerMock = FactoryMock.CreateMock<ILogger>(); // Mock generico que tiene los metodos basicos
            this.anagramEngineMock = FactoryMock.Get<AnagramEngineMock>(); //Clase de mock que ademas tiene los metodos que hemos creado
            this.tracker = new Tracker(this.anagramEngineMock.Mock, interestingWords, this.loggerMock.Mock);
        }

        [TestCleanup]
        public void Clean()
        {
            this.tracker = null;
        }

        [TestCategory("Tracking"), TestMethod]
        public void Crear_objeto_con_anagramengine_nulo()
        {
            try
            {
                Tracker tracker = new Tracker(null, new List<string>(), this.loggerMock.Mock);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestCategory("Tracking"), TestMethod]
        public void Crear_objeto_con_interestingwords_nulo()
        {
            try
            {
                Tracker tracker = new Tracker(this.anagramEngineMock.Mock, null, this.loggerMock.Mock);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }

        [TestCategory("Tracking"), TestMethod]
        public void Crear_objeto_con_logger_nulo()
        {
            try
            {
                Tracker tracker = new Tracker(this.anagramEngineMock.Mock, null, null);
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
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
            this.loggerMock.Verify(mock => mock.Log(this.CreateLogString(input, "192.168.1.1", "España","Español (España)")), Times.Once());
        }

        [TestCategory("Tracking"), TestMethod]
        public void Se_detecta_palabra_interesante_en_el_resultado_para_rama()
        {
            string input = "rama";

            this.interestingWords.Add("arma");

            List<string> anagrams = new List<string>() { "arma" };

            //Uso de los metodos de la clase de mock
            this.anagramEngineMock.SetupGetAnagram(input, anagrams);

            List<string> result = this.tracker.GetAnagrams(input, new List<string>());

            CollectionAssert.AreEqual(anagrams, result, "Se ha modificado el resultado de la funcion de obtener anagramas");

            this.anagramEngineMock.Verify(mock => mock.GetAnagrams(input, It.IsAny<List<string>>()), Times.Once());
            this.loggerMock.Verify(mock => mock.Log(this.CreateLogString(input, "192.168.1.1", "España", "Español (España)")), Times.Once());
        }

        [TestCategory("Tracking"), TestMethod]
        public void No_se_detecta_palabra_interesante()
        {
            string input = "marca";

            //Uso de los metodos de la clase base de mock 
            this.anagramEngineMock.Setup(mock => mock.GetAnagrams(input, It.IsAny<List<string>>()))
                .Returns(new List<string>());

            List<string> result = this.tracker.GetAnagrams(input, new List<string>());

            CollectionAssert.AreEqual(new List<string>(), result, "Se ha modificado el resultado de la funcion de obtener anagramas");

            this.anagramEngineMock.VerifyGetAnagram(input, Times.Once());
            this.loggerMock.Verify(mock => mock.Log(It.IsAny<string>()), Times.Never());
        }

        private string CreateLogString(string input, string ip, string country, string language)
        {
            return string.Format("Word: {0} --- IP: {1}, Country: {2}, Language: {3}", input, ip, country, language);
        }
    }
}
