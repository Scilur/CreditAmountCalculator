using CreditCalculator.Entities;

namespace CreditCalculator.BLL
{
    public class ScoreCorrector : IScoreCorrector
    {
        private const int MIN_SCORE = 0;
        private const int MAX_SCORE = 100;

        public ScoreCalculationResult CorrectScore(ScoreCalculationResult scoreCalculation)
        {
            var score = scoreCalculation.RawScore;

            if (score < MIN_SCORE)
            {
                score = MIN_SCORE;
                scoreCalculation.IsCorrectionApplied = true;
            }

            if (score > MAX_SCORE)
            {
                score = MAX_SCORE;
                scoreCalculation.IsCorrectionApplied = true;
            }

            scoreCalculation.ResultedScore = score;

            return scoreCalculation;
        }
    }
}
