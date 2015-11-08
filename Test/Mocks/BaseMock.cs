using Moq;

namespace Test.Mocks
{
    public abstract class BaseMock<T> where T : class
    {
        protected Mock<T> objectMock;

        public BaseMock()
        {
           this.objectMock = new Mock<T>();
        }

        public T Mock
        {
            get { return this.objectMock.Object; }
        } 
    }
}
