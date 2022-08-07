using System.Collections.Generic;
using System.Linq;

namespace CreditCalculator.Entities
{
    public class CredtCalculationResult
    {
        public decimal MaxCreditAmount { get; set; } = 0.0M;

        public List<string> Errors { get; set; } = new List<string>();

        public bool IsSuccess => Errors == null || !Errors.Any();

        public ScoreCalculationResult ScoreCalculationResult { get; set; }
    }
}
