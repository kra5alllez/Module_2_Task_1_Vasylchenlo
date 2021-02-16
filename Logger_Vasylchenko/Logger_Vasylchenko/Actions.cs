namespace Logger_Vasylchenko
{
    public class Actions
    {
        private Logger _logger = Logger.Instance();
        private Result _result = new Result();

        public bool CreateInfo()
        {
            _result.Status = true;
            _logger.Write(_result.Status, TypeLog.Info, nameof(CreateInfo));
            return _result.Status;
        }

        public bool CreateWarning()
        {
            _result.Status = true;
            _logger.Write(_result.Status, TypeLog.Warning, nameof(CreateWarning));
            return _result.Status;
        }

        public (bool, string) CreateError()
        {
            _result.Status = false;
            return (_result.Status, _result.MessageAboutStatus);
        }
    }
}
