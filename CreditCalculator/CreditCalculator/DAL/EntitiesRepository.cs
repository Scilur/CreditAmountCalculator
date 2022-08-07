using CreditCalculator.Entities.Enums;
using System.Linq;


namespace CreditCalculator.DAL
{
    public class EntitiesRepository : IEntitiesRepository
    {
        protected IEntitiesContext Context { get; set; }


        public EntitiesRepository(IEntitiesContext context = null)
        {
            this.Context = context ?? new EntitiesContext();
        }


        public int GetScoreByAge(int age)
        {
            var record = this.Context.ScoreByAgeDataSet
                .First(x => (x.AgeFrom == null || x.AgeFrom.Value <= age)
                            && (x.AgeTo == null || age <= x.AgeTo.Value));

            var result = record.Score;
            return result;
        }

        public int GetScoreByCreditRank(int creditRank)
        {
            var record = this.Context.ScoreByCreditRankDataSet
                .First(x => x.CreditRankFrom <= creditRank && creditRank <= x.CreditRankTo);

            var result = record.Score;
            return result;
        }

        public int GetAdditionalScore(AdditionalScoreReason reason, bool isApplied)
        {
            if (!isApplied)
                return 0;

            var record = this.Context.AdditionalScoreReasonDataSet
                .FirstOrDefault(x => x.Reason == reason);

            if (record == null)
                return 0;

            var result = record.Score;
            return result;
        }

        public decimal GetAmountByScore(int score)
        {
            var record = this.Context.AmountByScoreDataSet
                .FirstOrDefault(x => x.ScoreFrom <= score && score <= x.ScoreTo);

            var result = record.Amount;
            return result;
        }
    }
}
