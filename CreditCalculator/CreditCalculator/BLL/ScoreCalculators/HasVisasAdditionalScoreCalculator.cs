using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class HasVisasAdditionalScoreCalculator : AdditionalScoreCalculator
    {
        protected override AdditionalScoreReason Reason => AdditionalScoreReason.HasVisas;

        protected override Func<PersonInfo, bool> GetIsApplied => personInfo => personInfo.HasVisas;


        public HasVisasAdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }
    }
}
