using System;
using System.Text;

namespace Logger_Vasylchenko
{
    public class Logger
    {
        private readonly StringBuilder _stringLogs;
        private static readonly Logger _instance = new Logger();

        private Logger()
        {
            _stringLogs = new StringBuilder();
        }

        public static Logger Instance() => _instance;
        public void Write(string text)
        {
            _stringLogs.AppendLine(text);
            Console.WriteLine(text);
        }

        public string Read()
        {
            return _stringLogs.ToString();
        }
    }
}
