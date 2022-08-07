using CreditCalculator.Entities;
using CreditCalculator.Entities.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCalculator.BLL
{
    public class PersonInfoValidator : IPersonInfoValidator
    {
        public void ThrowIfIsNotValid(PersonInfo personInfo)
        {
            var exceptions = new List<Exception>();

            if (personInfo.Age < 16 || personInfo.Age > 100)
                exceptions.Add(new CustomArgumentValidationException(nameof(PersonInfo.Age), "Person can not be yanger than 16 and older than 100 years"));

            if (personInfo.CreditRank < 0 || personInfo.CreditRank > 100)
                exceptions.Add(new CustomArgumentValidationException(nameof(PersonInfo.CreditRank), $"Credit Rank has incorrect value {personInfo.CreditRank}. It must be from 0 to 100."));

            if (exceptions.Any())
                throw new CustomValidationException(exceptions);
        }
    }
}
