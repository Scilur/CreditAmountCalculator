using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class HasHouseAdditionalScoreCalculator : AdditionalScoreCalculator
    {
        protected override AdditionalScoreReason Reason => AdditionalScoreReason.HasHouse;

        protected override Func<PersonInfo, bool> GetIsApplied => personInfo => personInfo.HasHouse;


        public HasHouseAdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }
    }
}
