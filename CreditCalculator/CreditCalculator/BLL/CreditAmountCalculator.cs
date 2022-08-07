using CreditCalculator.BLL.ScoreCalculators;
using CreditCalculator.Entities;
using CreditCalculator.Entities.CustomExceptions;
using System.Collections.Generic;
using System.Linq;

namespace CreditCalculator.BLL
{
    public class CreditAmountCalculator : ICreditCalculator
    {
        private List<IScoreCalculator> ScoreCalculators { get; set; } = new List<IScoreCalculator>();

        private IScoreCorrector ScoreCorrector { get; set; }

        private ICreditAmountResolver CreditAmountResolver { get; set; }

        private IPersonInfoValidator PersonInfoValidator { get; set; }


        public CreditAmountCalculator(IPersonInfoValidator personInfoValidator)
        {
            this.PersonInfoValidator = personInfoValidator;
        }


        public void SetSteps(
            ICollection<IScoreCalculator> scoreCalculators,
            IScoreCorrector scoreCorrector,
            ICreditAmountResolver creditAmountResolver)
        {
            if (!scoreCalculators.Any())
                throw new CustomConfigurationException("At least one ScoreCalculator must be added to the Credit Calculator configuration");

            if (creditAmountResolver == null)
                throw new CustomConfigurationException("Credit Amount Resolver is required for the correct Credit Calculator configuration");

            this.ScoreCalculators.AddRange(scoreCalculators);
            this.ScoreCorrector = scoreCorrector ?? new DefaultCorrector();
            this.CreditAmountResolver = creditAmountResolver;
        }


        public CredtCalculationResult CalcCreditAmount(PersonInfo personInfo)
        {
            var result = new CredtCalculationResult();

            try
            {
                this.PersonInfoValidator.ThrowIfIsNotValid(personInfo);

                var scoreCalculation = new ScoreCalculationResult();

                this.ScoreCalculators.ForEach(calculator =>
                {
                    scoreCalculation.TakePortion(calculator.GetScorePoints(personInfo));
                });

                scoreCalculation = this.ScoreCorrector.CorrectScore(scoreCalculation);
                result.ScoreCalculationResult = scoreCalculation;

                var amount = this.CreditAmountResolver.CalcCreditAmount(scoreCalculation.ResultedScore);

                result.MaxCreditAmount = amount;
            }
            catch (CustomValidationException ex)
            {
                result.Errors.AddRange(ex.InnerExceptions.Select(x => x.Message));
            }

            return result;
        }
    }
}
