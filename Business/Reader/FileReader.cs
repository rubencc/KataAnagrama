using System;
using System.Collections.Generic;
using System.IO;

namespace Business.Reader
{
    public class FileReader : IFileReader
    {

        public List<string> Load(string fileName)
        {
            List<string> list = new List<string>();
            try
            {
                string line;
                StreamReader file = new StreamReader(@".\Dictionary\" + fileName);

                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }

                file.Close();
            }
            catch
            {
                return new List<string>();
            }

            return list;
        }
    }
}
