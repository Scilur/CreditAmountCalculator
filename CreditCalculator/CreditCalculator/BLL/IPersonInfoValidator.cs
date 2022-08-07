using CreditCalculator.Entities;

namespace CreditCalculator.BLL
{
    public interface IPersonInfoValidator
    {
        void ThrowIfIsNotValid(PersonInfo personInfo);
    }
}
