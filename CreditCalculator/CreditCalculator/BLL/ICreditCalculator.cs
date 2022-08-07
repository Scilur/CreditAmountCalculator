using CreditCalculator.Entities;

namespace CreditCalculator.BLL
{
    public interface ICreditCalculator
    {
        CredtCalculationResult CalcCreditAmount(PersonInfo personInfo);
    }
}
