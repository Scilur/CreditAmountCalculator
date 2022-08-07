using CreditCalculator.Entities;
using CreditCalculator.Entities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CreditCalculator.DAL
{
    public class EntitiesContext : IEntitiesContext
    {
        private static readonly IQueryable<ScoreByAgeRecord> _ScoreByAgeDataSetValue =
            new List<ScoreByAgeRecord>()
            {
                new ScoreByAgeRecord { AgeFrom = 16,   AgeTo = 25,   Score = 10  },
                new ScoreByAgeRecord { AgeFrom = 26,   AgeTo = 50,   Score = 30  },
                new ScoreByAgeRecord { AgeFrom = 51,   AgeTo = 60,   Score = 20  },
                new ScoreByAgeRecord { AgeFrom = 61,   AgeTo = null, Score = -50 }
            }.AsQueryable();

        private static readonly IQueryable<ScoreByCreditRankRecord> _ScoreByCreditRankDataSetValue =
            new List<ScoreByCreditRankRecord>()
            {
                new ScoreByCreditRankRecord { CreditRankFrom = 0,  CreditRankTo = 30,  Score = -30 },
                new ScoreByCreditRankRecord { CreditRankFrom = 31, CreditRankTo = 70,  Score = 0   },
                new ScoreByCreditRankRecord { CreditRankFrom = 71, CreditRankTo = 100, Score = 30  }
            }.AsQueryable();

        private static readonly IQueryable<AdditionalScoreReasonRecord> _AdditionalScoreReasonDataSetValue =
            new List<AdditionalScoreReasonRecord>()
            {
                new AdditionalScoreReasonRecord { Reason = AdditionalScoreReason.FamilyExists,         Score = 10  },
                new AdditionalScoreReasonRecord { Reason = AdditionalScoreReason.StationarPhoneExists, Score = 5   },
                new AdditionalScoreReasonRecord { Reason = AdditionalScoreReason.HasVisas,             Score = 5   },
                new AdditionalScoreReasonRecord { Reason = AdditionalScoreReason.HasHouse,             Score = 15  },
                new AdditionalScoreReasonRecord { Reason = AdditionalScoreReason.HasCar,               Score = 15  },
                new AdditionalScoreReasonRecord { Reason = AdditionalScoreReason.WasConvicted,         Score = -30 },
                new AdditionalScoreReasonRecord { Reason = AdditionalScoreReason.HasAnotherCredit,     Score = -20 }
            }.AsQueryable();

        private static readonly IQueryable<AmountByScoreRecord> _AmountByScoreDataSetValue =
            new List<AmountByScoreRecord>()
            {
                new AmountByScoreRecord { ScoreFrom = 0,  ScoreTo = 20,  Amount = 0.00M     },
                new AmountByScoreRecord { ScoreFrom = 21, ScoreTo = 60,  Amount = 1000.00M  },
                new AmountByScoreRecord { ScoreFrom = 61, ScoreTo = 80,  Amount = 10000.00M },
                new AmountByScoreRecord { ScoreFrom = 81, ScoreTo = 100, Amount = 50000.00M }
            }.AsQueryable();

        public IQueryable<ScoreByAgeRecord> ScoreByAgeDataSet { get; } = _ScoreByAgeDataSetValue;

        public IQueryable<ScoreByCreditRankRecord> ScoreByCreditRankDataSet { get; } = _ScoreByCreditRankDataSetValue;

        public IQueryable<AdditionalScoreReasonRecord> AdditionalScoreReasonDataSet { get; } = _AdditionalScoreReasonDataSetValue;

        public IQueryable<AmountByScoreRecord> AmountByScoreDataSet { get; } = _AmountByScoreDataSetValue;
    }
}
