using System;
using System.Text;

namespace Logger_Vasylchenko
{
    public class Logger
    {
        private StringBuilder _stringLogs;
        private static Logger _instance;

        private Logger()
        {
            _stringLogs = new StringBuilder();
        }

        public static Logger Instance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }

            return _instance;
        }

        public void Write(bool propertyStatus, TypeLog typeLog, string statusMessage)
        {
            if (propertyStatus)
            {
                if (typeLog == TypeLog.Info)
                {
                    _stringLogs.AppendLine($"{DateTime.UtcNow}: {typeLog} Start method: {statusMessage}");
                    Console.WriteLine($"{DateTime.UtcNow}: {typeLog} Start method: {statusMessage}");
                }
                else
                {
                    _stringLogs.AppendLine($"{DateTime.UtcNow}: {typeLog} Skipped logic in method: {statusMessage}");
                    Console.WriteLine($"{DateTime.UtcNow}: {typeLog} Skipped logic in method: {statusMessage}");
                }
            }
            else
            {
                _stringLogs.AppendLine($"{DateTime.UtcNow}: {typeLog} Action failed by a reason:: {statusMessage}");
                Console.WriteLine($"{DateTime.UtcNow}: {typeLog} Action failed by a reason:: {statusMessage}");
            }
        }

        public string Read()
        {
            return _stringLogs.ToString();
        }
    }
}
