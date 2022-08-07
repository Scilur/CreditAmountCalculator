using CreditCalculator.Entities.Enums;

namespace CreditCalculator.DAL
{
    public interface IEntitiesRepository
    {
        int GetScoreByAge(int age);

        int GetScoreByCreditRank(int creditRank);

        int GetAdditionalScore(AdditionalScoreReason reason, bool isApplied);

        decimal GetAmountByScore(int score);
    }
}
