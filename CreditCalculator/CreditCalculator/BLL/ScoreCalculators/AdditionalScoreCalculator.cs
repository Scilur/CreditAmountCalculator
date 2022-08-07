using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public abstract class AdditionalScoreCalculator : ScoreCalculator
    {
        protected virtual AdditionalScoreReason Reason { get; }
        protected virtual Func<PersonInfo, bool> GetIsApplied { get; }


        public AdditionalScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }


        public override ScorePortion GetScorePoints(PersonInfo personInfo)
        {
            var isApplied = this.GetIsApplied(personInfo);
            var score = this.Repository.GetAdditionalScore(this.Reason, isApplied);

            var result = new ScorePortion
            {
                Description = $"{$"{this.Reason}:",-30}{(isApplied ? "V" : "X")}",
                Score = score
            };

            return result;
        }
    }
}
