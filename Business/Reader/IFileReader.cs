using System.Collections.Generic;

namespace Business.Reader
{
    public interface IFileReader
    {
        List<string> Load(string fileName);
    }
}
