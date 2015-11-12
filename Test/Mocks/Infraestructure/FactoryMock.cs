using System;

namespace Test.Mocks.Infraestructure
{
    public class FactoryMock
    {
        public static MockObject<T> CreateMock<T>() where T: class
        {
            return new MockObject<T>();
        }

        public static T Get<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}
