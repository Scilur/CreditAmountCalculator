using CreditCalculator;
using System;

namespace CreditCalculatorAPI
{
    public class ClassResolverAdapter : IClassResolver
    {
        private IServiceProvider ServiceProvider { get; set; }


        public ClassResolverAdapter(IServiceProvider serviceProvider)
        {
            this.ServiceProvider = serviceProvider;
        }


        public T Resolve<T>() where T : class
        {
            var result = (T)this.ServiceProvider.GetService(typeof(T));
            return result;
        }
    }
}
