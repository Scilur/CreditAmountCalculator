using System.Collections.Generic;

namespace CreditCalculator.BLL
{
    public class CreditAmountCalculatorConfig
    {
        public List<string> ScoreCalculatorsTypes { get; set; } = new List<string>();
        
        public string ScoreCorrectorType { get; set; }

        public string CreditAmountResolverType { get; set; }

        // It can be read from config file or DB as JSON and deserialized to the form like this:
        public static CreditAmountCalculatorConfig Default { get; set; } =
            new CreditAmountCalculatorConfig
            {
                ScoreCalculatorsTypes = new List<string>
                {
                    "CreditCalculator.BLL.ScoreCalculators.ByAgeScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.ByCreditRankScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.FamilyExistsAdditionalScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.StationarPhoneExistsAdditionalScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.HasVisasAdditionalScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.HasHouseAdditionalScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.HasCarAdditionalScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.WasConvictedAdditionalScoreCalculator, CreditCalculator",
                    "CreditCalculator.BLL.ScoreCalculators.HasAnotherCreditAdditionalScoreCalculator, CreditCalculator"
                },
                ScoreCorrectorType = "CreditCalculator.BLL.IScoreCorrector, CreditCalculator",
                CreditAmountResolverType = "CreditCalculator.BLL.ICreditAmountResolver, CreditCalculator"
            };
    }
}
