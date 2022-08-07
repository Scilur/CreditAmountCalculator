using CreditCalculator.BLL.ScoreCalculators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CreditCalculator.BLL
{
    public class CreditCalculatorBuilder
    {
        private IClassResolver ClassResolver { get; set; }

        private Dictionary<Type, IScoreCalculator> ScoreCalculators { get; set; }
            = new Dictionary<Type, IScoreCalculator>();

        private IScoreCorrector ScoreCorrector { get; set; }

        private ICreditAmountResolver CreditAmountResolver { get; set; }


        private CreditCalculatorBuilder(IClassResolver classResolver)
        {
            ClassResolver = classResolver;
        }


        public static CreditCalculatorBuilder Set(IClassResolver classResolver)
        {
            return new CreditCalculatorBuilder(classResolver);
        }

        public CreditCalculatorBuilder FromConfig(CreditAmountCalculatorConfig config)
        {
            foreach(var typeName in config.ScoreCalculatorsTypes)
            {
                var resolvedInstance =
                    this.ResolveStringAsInstance<IScoreCalculator>(typeName);
                if (resolvedInstance.Instance != null)
                    this.ScoreCalculators[ resolvedInstance.Type] = resolvedInstance.Instance;
            }

            if (!string.IsNullOrWhiteSpace(config.ScoreCorrectorType))
            {
                this.ScoreCorrector = 
                    this.ResolveStringAsInstance<IScoreCorrector>(config.ScoreCorrectorType).Instance;
            }
            else
            {
                this.ScoreCorrector = new DefaultCorrector();
            }

            if (!string.IsNullOrWhiteSpace(config.CreditAmountResolverType))
            {
                this.CreditAmountResolver = 
                    this.ResolveStringAsInstance<ICreditAmountResolver>(config.CreditAmountResolverType).Instance;
            }

            return this;
        }

        private (Type Type, T Instance) ResolveStringAsInstance<T>(string typeFullName)
            where T : class
        {
            var type = Type.GetType(typeFullName);
            var instance = this.ClassResolver.Resolve(type) as T;
            return (Type: type, Instance: instance);
        }

        public CreditCalculatorBuilder AddScoreCalculator<T>()
            where T : class, IScoreCalculator
        {
            var calculator = this.ClassResolver.Resolve<T>();

            if (!this.ScoreCalculators.ContainsKey(typeof(T)))
                this.ScoreCalculators.Add(typeof(T), calculator);

            return this;
        }

        public CreditCalculatorBuilder SetScoreCorrector<T>()
            where T : class, IScoreCorrector
        {
            var corrector = this.ClassResolver.Resolve<T>();
            this.ScoreCorrector = corrector;

            return this;
        }

        public CreditCalculatorBuilder SetCreditAmountResolver<T>()
            where T : class, ICreditAmountResolver
        {
            var resolver = this.ClassResolver.Resolve<T>();
            this.CreditAmountResolver = resolver;

            return this;
        }

        public ICreditCalculator Build()
        {
            var creditCalculator = this.ClassResolver.Resolve<CreditAmountCalculator>();
            creditCalculator.SetSteps(
                this.ScoreCalculators.Values, this.ScoreCorrector, this.CreditAmountResolver);

            return creditCalculator;
        }
    }
}
