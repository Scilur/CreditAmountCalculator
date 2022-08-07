using CreditCalculator.DAL;
using CreditCalculator.Entities;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public class ByAgeScoreCalculator : ScoreCalculator
    {
        public ByAgeScoreCalculator(IEntitiesRepository repository)
            : base(repository)
        { }


        public override ScorePortion GetScorePoints(PersonInfo personInfo)
        {
            var score = this.Repository.GetScoreByAge(personInfo.Age);

            var result = new ScorePortion
            {
                Description = $"Person age is {personInfo.Age}",
                Score = score
            };

            return result;
        }
    }
}
