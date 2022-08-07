using System;

namespace CreditCalculator.Entities.CustomExceptions
{
    public class CustomConfigurationException : Exception
    {
        public CustomConfigurationException(string message)
            : base(message)
        { }
    }
}
