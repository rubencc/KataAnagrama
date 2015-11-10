using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Business.Reader
{
    public class FileReader : IFileReader
    {

        private readonly string fileName;
        private readonly string pattern = @"^[a-zA-Z]+$";

        public FileReader(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException();
            }

            this.fileName = fileName;
        }

        public List<string> Load()
        {
            List<string> list = new List<string>();
            try
            {
                string line;
                StreamReader file = new StreamReader(@".\Dictionary\" + this.fileName);

                while ((line = file.ReadLine()) != null)
                {
                    if(this.IsLetter(line))
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

        private bool IsLetter(string input)
        {
            return Regex.IsMatch(input, pattern);
        }
    }
}
