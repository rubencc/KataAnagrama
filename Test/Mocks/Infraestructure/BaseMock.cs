using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using Moq.Language.Flow;

namespace Test.Mocks.Infraestructure
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

        public ISetup<T, List<string>> Setup(Expression<Func<T, List<string>>> expression)
        {
            return this.objectMock.Setup(expression);
        }

        public ISetup<T> Setup(Expression<Action<T>> expression)
        {
            return this.objectMock.Setup(expression);
        }

        public void Verify(Expression<Func<T, List<string>>> expression, Times times)
        {
            this.objectMock.Verify(expression, times);
        }

        public void Verify(Expression<Func<T, List<string>>> expression, Times times, string failMessage)
        {
            this.objectMock.Verify(expression, times, failMessage);
        }

        public void Verify(Expression<Action<T>> expression, Times times)
        {
            this.objectMock.Verify(expression, times);
        }

        public void Verify(Expression<Action<T>> expression, Times times, string failMessage)
        {
            this.objectMock.Verify(expression, times, failMessage);
        }
    }
}
