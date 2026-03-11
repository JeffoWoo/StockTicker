namespace StockTicker.Application.Exceptions
{
    [Serializable]
    internal class ValidationException : Exception
    {
        private List<ValidationError> validationErrors;

        public ValidationException()
        {
        }

        public ValidationException(List<ValidationError> validationErrors)
        {
            this.validationErrors = validationErrors;
        }

        public ValidationException(string? message) : base(message)
        {
        }

        public ValidationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}