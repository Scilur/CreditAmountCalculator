using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class StationarPhoneExistsAdditionalScoreCalculator : AdditionalScoreCalculator
    {
        protected override AdditionalScoreReason Reason => AdditionalScoreReason.StationarPhoneExists;

        protected override Func<PersonInfo, bool> GetIsApplied => personInfo => personInfo.StationarPhoneExists;


        public StationarPhoneExistsAdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }
    }
}
