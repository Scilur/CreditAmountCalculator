using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class WasConvictedAdditionalScoreCalculator : AdditionalScoreCalculator
    {
        protected override AdditionalScoreReason Reason => AdditionalScoreReason.WasConvicted;

        protected override Func<PersonInfo, bool> GetIsApplied => personInfo => personInfo.WasConvicted;


        public WasConvictedAdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }
    }
}
