using CreditCalculator.Entities;
using System.Text;

namespace CreditCalculator.BLL
{
    public class CredtCalculationPresenter
    {
        public string GetView(CredtCalculationResult calcResult)
        {
            var sb = new StringBuilder();

            if (calcResult.IsSuccess)
            {
                sb.AppendLine("Credit Amount Calculation was Successfull:")
                    .AppendLine();

                sb.AppendLine("Score Calculation:");
                calcResult.ScoreCalculationResult.Portions.ForEach(
                    p => sb.AppendLine($"{p.Description,-50}: {p.Score}"));

                if (calcResult.ScoreCalculationResult.IsCorrectionApplied)
                {
                    sb.AppendLine($"Score before correction is {calcResult.ScoreCalculationResult.RawScore}");
                }
                sb.AppendLine($"Resulted Score is {calcResult.ScoreCalculationResult.ResultedScore}");

                sb.AppendLine()
                    .AppendLine($"Available Credit Amount is {calcResult.MaxCreditAmount}");
            }
            else
            {
                sb.AppendLine("Credit Amount Calculation was Failed:");
                calcResult.Errors.ForEach(error => sb.AppendLine(error));
            }

            return sb.ToString();
        }
    }
}
