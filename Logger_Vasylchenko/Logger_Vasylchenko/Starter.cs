using System;
using System.IO;

namespace Logger_Vasylchenko
{
    public class Starter
    {
        private readonly int _minRandomAction = 1;
        private readonly int _maxRandomAction = 4;
        private int _iterationCounter = 1;
        private (bool Status, string MessageError) _valuesFromMethodsOfClassActions;
        private Actions _objectOfTypeActions = new Actions();
        private Logger _logger = Logger.Instance();

        public void Run()
        {
            while (_iterationCounter <= 100)
            {
                var randomLog = new Random().Next(_minRandomAction, _maxRandomAction);
                switch (randomLog)
                {
                    case 1:
                        _valuesFromMethodsOfClassActions.Status = _objectOfTypeActions.CreateInfo();
                        break;
                    case 2:
                        _valuesFromMethodsOfClassActions.Status = _objectOfTypeActions.CreateWarning();
                        break;
                    case 3:
                        _valuesFromMethodsOfClassActions = _objectOfTypeActions.CreateError();
                        break;
                }

                if (!_valuesFromMethodsOfClassActions.Status)
                {
                    _logger.Write(_valuesFromMethodsOfClassActions.Status, TypeLog.Error, _valuesFromMethodsOfClassActions.MessageError);
                }

                _iterationCounter++;
            }

            File.WriteAllText("log.txt", _logger.Read());
        }
    }
}
