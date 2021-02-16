using System;
using System.IO;

namespace Logger_Vasylchenko
{
    public class Starter
    {
        private readonly int _minRandomAction = 1;
        private readonly int _maxRandomAction = 4;
        private Actions _objectOfTypeActions = new Actions();
        private Logger _logger = Logger.Instance();

        public void Run()
        {
            Result valuesFromMethodsOfClassActions = new Result();

            for (int i = 1; i <= 100; i++)
            {
                var randomLog = new Random().Next(_minRandomAction, _maxRandomAction);
                switch (randomLog)
                {
                    case 1:
                        valuesFromMethodsOfClassActions.Status = _objectOfTypeActions.CreateInfo();
                        break;
                    case 2:
                        valuesFromMethodsOfClassActions.Status = _objectOfTypeActions.CreateWarning();
                        break;
                    case 3:
                        (valuesFromMethodsOfClassActions.Status, valuesFromMethodsOfClassActions.MessageAboutStatus) = _objectOfTypeActions.CreateError();
                        break;
                }

                if (!valuesFromMethodsOfClassActions.Status)
                {
                    _logger.Write($"{DateTime.UtcNow}: {TypeLog.Error} Action failed by a reason:: {valuesFromMethodsOfClassActions.MessageAboutStatus}");
                }
            }

            File.WriteAllText("log.txt", _logger.Read());
        }
    }
}
