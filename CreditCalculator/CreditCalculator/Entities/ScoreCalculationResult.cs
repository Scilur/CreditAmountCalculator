using System.Collections.Generic;

namespace CreditCalculator.Entities
{
    public class ScoreCalculationResult
    {
        public List<ScorePortion> Portions { get; set; } = new List<ScorePortion>();

        public int RawScore { get; set; } = 0;

        public int ResultedScore { get; set; } = 0;

        public bool IsCorrectionApplied { get; set; } = false;


        public void TakePortion(ScorePortion portion)
        {
            Portions.Add(portion);
            RawScore += portion.Score;
        }
    }
}
