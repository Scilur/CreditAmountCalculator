using CreditCalculator.Entities;

namespace CreditCalculator.BLL
{
    public class DefaultCorrector : IScoreCorrector
    {
        public ScoreCalculationResult CorrectScore(ScoreCalculationResult scoreCalculation)
        {
            scoreCalculation.ResultedScore = scoreCalculation.RawScore;
            return scoreCalculation;
        }
    }
}
