using CreditCalculator.DAL;
using CreditCalculator.Entities;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class ByCreditRankScoreCalculator : ScoreCalculator
    {
        public ByCreditRankScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }


        public override ScorePortion GetScorePoints(PersonInfo personInfo)
        {
            var score = this.Repository.GetScoreByCreditRank(personInfo.CreditRank);

            var result = new ScorePortion
            {
                Description = $"The Credit Rank is {personInfo.CreditRank}",
                Score = score
            };

            return result;
        }
    }
}
