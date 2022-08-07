using System;

namespace CreditCalculator
{
    public interface IClassResolver
    {
        T Resolve<T>() where T : class;

        object Resolve(Type type);
    }
}
