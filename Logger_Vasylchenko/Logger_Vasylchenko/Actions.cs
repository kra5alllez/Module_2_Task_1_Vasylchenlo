using System;

namespace Logger_Vasylchenko
{
    public class Actions
    {
        private Logger _logger = Logger.Instance();
        private Result _result = new Result();

        public bool CreateInfo()
        {
            _result.Status = true;
            _logger.Write($"{DateTime.UtcNow}: {TypeLog.Info} Start method: {nameof(CreateInfo)}");
            return _result.Status;
        }

        public bool CreateWarning()
        {
            _result.Status = true;
            _logger.Write($"{DateTime.UtcNow}: {TypeLog.Warning} Skipped logic in method: {nameof(CreateWarning)}");
            return _result.Status;
        }

        public (bool, string) CreateError()
        {
            _result.Status = false;
            _result.MessageAboutStatus = "I broke a logic";
            return (_result.Status, _result.MessageAboutStatus);
        }
    }
}
