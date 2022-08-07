using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class HasCarAdditionalScoreCalculator : AdditionalScoreCalculator
    {
        protected override AdditionalScoreReason Reason => AdditionalScoreReason.HasCar;

        protected override Func<PersonInfo, bool> GetIsApplied => personInfo => personInfo.HasCar;


        public HasCarAdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }
    }
}
