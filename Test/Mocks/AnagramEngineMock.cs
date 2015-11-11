using System.Collections.Generic;
using Business;
using Moq;

namespace Test.Mocks
{
    public class AnagramEngineMock : BaseMock<IAnagramEngine>
    {
        public void SetupGetAnagram(string input, List<string> result)
        {
            this.objectMock.Setup(mock => mock.GetAnagrams(input, It.IsAny<List<string>>())).Returns(result);
        }

        public void VerifyGetAnagram(string input, Times times)
        {
            this.objectMock.Verify(mock => mock.GetAnagrams(input, It.IsAny<List<string>>()), times);
        }
    }
}
