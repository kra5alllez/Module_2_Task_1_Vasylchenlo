using System;

namespace Logger_Vasylchenko
{
    public class Actions
    {
        private readonly Logger _logger = Logger.Instance();

        public bool CreateInfo()
        {
            Result result = new Result();
            result.Status = true;
            _logger.Write($"{DateTime.UtcNow}: {TypeLog.Info} Start method: {nameof(CreateInfo)}");
            return result.Status;
        }

        public bool CreateWarning()
        {
            Result result = new Result();
            result.Status = true;
            _logger.Write($"{DateTime.UtcNow}: {TypeLog.Warning} Skipped logic in method: {nameof(CreateWarning)}");
            return result.Status;
        }

        public (bool, string) CreateError()
        {
            Result result = new Result();
            result.Status = false;
            result.MessageAboutStatus = "I broke a logic";
            return (result.Status, result.MessageAboutStatus);
        }
    }
}
