namespace CreditCalculator
{
    public interface IClassResolver
    {
        T Resolve<T>() where T : class;
    }
}
