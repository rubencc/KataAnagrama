using Business.Log;
using Moq;
using Test.Mocks.Infraestructure;

namespace Test.Mocks
{
    public class LoggerMock : BaseMock<ILogger>
    {
        public void VerifyLog(string toLog, Times times)
        {
            this.objectMock.Verify(mock => mock.Log(toLog), times);
        }

        public void VerifyLogNever()
        {
            this.objectMock.Verify(mock => mock.Log(It.IsAny<string>()), Times.Never);
        }
    }
}
