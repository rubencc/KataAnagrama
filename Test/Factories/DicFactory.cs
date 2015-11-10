using System.Collections.Generic;
using Business.Reader;

namespace Test.Factories
{
    public class DicFactory
    {
        public static List<string> GetDic()
        {
            FileReader reader = new FileReader("dic.txt");

            return reader.Load();
        }
    }
}
