
using StockTicker.Application.Exceptions;

namespace StockTicker.Application.Abstractions.Bevhaviours
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationError> errors)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationError> Errors { get; }
    }
}
