using CreditCalculator.Entities;
using System.Linq;


namespace CreditCalculator.DAL
{
    public interface IEntitiesContext
    {
        IQueryable<ScoreByAgeRecord> ScoreByAgeDataSet { get; }

        IQueryable<ScoreByCreditRankRecord> ScoreByCreditRankDataSet { get; }

        IQueryable<AdditionalScoreReasonRecord> AdditionalScoreReasonDataSet { get; }

        IQueryable<AmountByScoreRecord> AmountByScoreDataSet { get; }
    }
}
