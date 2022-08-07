using CreditCalculator.Entities;

namespace CreditCalculator.BLL
{
    public interface IScoreCorrector
    {
        ScoreCalculationResult CorrectScore(ScoreCalculationResult scoreCalculation);
    }
}
