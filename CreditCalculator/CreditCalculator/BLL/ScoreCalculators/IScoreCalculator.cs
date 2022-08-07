using CreditCalculator.Entities;

namespace CreditCalculator.BLL.ScoreCalculators
{
    public interface IScoreCalculator
    {
        ScorePortion GetScorePoints(PersonInfo personInfo);
    }
}
