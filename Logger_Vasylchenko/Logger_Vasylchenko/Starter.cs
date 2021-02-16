using System;
using System.IO;

namespace Logger_Vasylchenko
{
    public class Starter
    {
        private readonly int _minRandomAction = 1;
        private readonly int _maxRandomAction = 4;
        private readonly Random _random = new Random();
        private readonly Actions _actions = new Actions();
        private readonly Logger _logger = Logger.Instance();

        public void Run()
        {
            for (var i = 1; i <= 100; i++)
            {
                Result result = new Result();

                var randomLog = _random.Next(_minRandomAction, _maxRandomAction);
                switch (randomLog)
                {
                    case 1:
                        result.Status = _actions.CreateInfo();
                        break;
                    case 2:
                        result.Status = _actions.CreateWarning();
                        break;
                    case 3:
                        (result.Status, result.MessageAboutStatus) = _actions.CreateError();
                        break;
                }

                if (!result.Status)
                {
                    _logger.Write($"{DateTime.UtcNow}: {TypeLog.Error} Action failed by a reason:: {result.MessageAboutStatus}");
                }
            }

            File.WriteAllText("log.txt", _logger.Read());
        }
    }
}
