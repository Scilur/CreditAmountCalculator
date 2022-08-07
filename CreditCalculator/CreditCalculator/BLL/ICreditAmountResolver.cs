namespace CreditCalculator.BLL
{
    public interface ICreditAmountResolver
    {
        decimal CalcCreditAmount(int score);
    }
}
