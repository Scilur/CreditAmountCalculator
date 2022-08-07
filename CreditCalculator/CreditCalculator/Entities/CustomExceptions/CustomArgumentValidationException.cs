using System;

namespace CreditCalculator.Entities.CustomExceptions
{
    public class CustomArgumentValidationException : Exception
    {
        public CustomArgumentValidationException(string argumentName, string errorMessage)
            : base($"'{argumentName}' is invalid because of '{errorMessage}'")
        { }
    }
}
