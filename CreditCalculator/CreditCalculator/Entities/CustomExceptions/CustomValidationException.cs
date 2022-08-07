using System;
using System.Collections.Generic;

namespace CreditCalculator.Entities.CustomExceptions
{
    public class CustomValidationException : AggregateException
    {
        public CustomValidationException(List<Exception> exceptions)
            : base(exceptions)
        { }
    }
}
