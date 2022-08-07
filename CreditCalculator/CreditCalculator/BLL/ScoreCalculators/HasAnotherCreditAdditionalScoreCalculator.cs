using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class HasAnotherCreditAdditionalScoreCalculator : AdditionalScoreCalculator
    {
        protected override AdditionalScoreReason Reason => AdditionalScoreReason.HasAnotherCredit;

        protected override Func<PersonInfo, bool> GetIsApplied => personInfo => personInfo.HasAnotherCredit;


        public HasAnotherCreditAdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }
    }
}
