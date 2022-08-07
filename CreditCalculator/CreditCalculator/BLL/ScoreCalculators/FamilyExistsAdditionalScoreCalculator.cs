using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class FamilyExistsAdditionalScoreCalculator : AdditionalScoreCalculator
    {
        protected override AdditionalScoreReason Reason => AdditionalScoreReason.FamilyExists;

        protected override Func<PersonInfo, bool> GetIsApplied => personInfo => personInfo.FamilyExists;


        public FamilyExistsAdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }
    }
}
