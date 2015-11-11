using System;

namespace Business.Log
{
    public class Logger : ILogger
    {
        public void Log(string toLog)
        {
            Console.WriteLine(toLog);
        }
    }
}
