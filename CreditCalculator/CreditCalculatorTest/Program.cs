using CreditCalculator.BLL;
using CreditCalculator.BLL.ScoreCalculators;
using CreditCalculator.DAL;
using CreditCalculator.Entities;
using CreditCalculatorTest.Helpers;
using System;

namespace CreditCalculatorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup IoC Container (custom implementation is used here just for demonstration purposess)
            CustomIoc.Container
                .AddImplementation<IEntitiesContext, EntitiesContext>()
                .AddImplementation<IEntitiesRepository, EntitiesRepository>()
                .AddImplementation<IScoreCorrector, ScoreCorrector>()
                .AddImplementation<ICreditAmountResolver, CreditAmountResolver>()
                .AddClass<ByAgeScoreCalculator>()
                .AddClass<ByCreditRankScoreCalculator>()
                .AddClass<FamilyExistsAdditionalScoreCalculator>()
                .AddClass<StationarPhoneExistsAdditionalScoreCalculator>()
                .AddClass<HasVisasAdditionalScoreCalculator>()
                .AddClass<HasHouseAdditionalScoreCalculator>()
                .AddClass<HasCarAdditionalScoreCalculator>()
                .AddClass<WasConvictedAdditionalScoreCalculator>()
                .AddClass<HasAnotherCreditAdditionalScoreCalculator>()
                .AddImplementation<IPersonInfoValidator, PersonInfoValidator>()
                .AddClass<CreditAmountCalculator>();

            // Create Credit Calculator from set of rules (it can be done on the basic of configuration from DB)
            var creditCalculator = CreditCalculatorBuilder.Set(CustomIoc.Container)
                .AddScoreCalculator<ByAgeScoreCalculator>()
                .AddScoreCalculator<ByCreditRankScoreCalculator>()
                .AddScoreCalculator<FamilyExistsAdditionalScoreCalculator>()
                .AddScoreCalculator<StationarPhoneExistsAdditionalScoreCalculator>()
                .AddScoreCalculator<HasVisasAdditionalScoreCalculator>()
                .AddScoreCalculator<HasHouseAdditionalScoreCalculator>()
                .AddScoreCalculator<HasCarAdditionalScoreCalculator>()
                .AddScoreCalculator<WasConvictedAdditionalScoreCalculator>()
                .AddScoreCalculator<HasAnotherCreditAdditionalScoreCalculator>()
                .SetScoreCorrector<IScoreCorrector>()
                .SetCreditAmountResolver<ICreditAmountResolver>()
                .Build();

            // Set test arguments
            var personInfo = new PersonInfo
            {
                Age = 45,
                CreditRank = 88,

                FamilyExists = true,
                StationarPhoneExists = true,
                HasVisas = false,
                HasHouse = true,
                HasCar = false,
                WasConvicted = false,
                HasAnotherCredit = true
            };

            // Calculate of maximum credit amount
            var credit = creditCalculator.CalcCreditAmount(personInfo);

            // Show result and explanation
            var presenter = new CredtCalculationPresenter();
            var text = presenter.GetView(credit);
            Console.WriteLine(text);
        }
    }
}
