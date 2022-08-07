using CreditCalculator.DAL;
using CreditCalculator.Entities;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public abstract class ScoreCalculator : IScoreCalculator
    {
        protected IEntitiesRepository Repository { get; set; }


        public ScoreCalculator(IEntitiesRepository repository)
        {
            this.Repository = repository;
        }


        public abstract ScorePortion GetScorePoints(PersonInfo personInfo);
    }
}
