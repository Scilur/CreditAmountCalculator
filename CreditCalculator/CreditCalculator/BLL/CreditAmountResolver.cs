using CreditCalculator.DAL;

namespace CreditCalculator.BLL
{
    public class CreditAmountResolver : ICreditAmountResolver
    {
        protected IEntitiesRepository Repository { get; set; }


        public CreditAmountResolver(IEntitiesRepository repository)
        {
            this.Repository = repository;
        }


        public decimal CalcCreditAmount(int score)
        {
            var amaunt = this.Repository.GetAmountByScore(score);
            return amaunt;
        }
    }
}
