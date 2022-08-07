using CreditCalculator;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CreditCalculatorTest.Helpers
{
    public class CustomIoc : IClassResolver
    {
        private static CustomIoc _Insatnce;
        public static CustomIoc Container => _Insatnce;


        private ConcurrentDictionary<Type, Type> Mappings { get; set; } = new ConcurrentDictionary<Type, Type>();


        static CustomIoc()
        {
            _Insatnce = new CustomIoc();
        }

        private CustomIoc()
        { }


        public CustomIoc AddImplementation<TInterface, TImplementation>()
        {
            this.Mappings.AddOrUpdate(typeof(TInterface), typeof(TImplementation),
                (key, oldValue) => typeof(TImplementation));

            this.Mappings.AddOrUpdate(typeof(TImplementation), typeof(TImplementation),
                (key, oldValue) => typeof(TImplementation));

            return this;
        }

        public CustomIoc AddClass<TClass>()
        {
            return this.AddImplementation<TClass, TClass>();
        }

        public T Resolve<T>()
            where T : class
        {
            var instance = (T)Resolve(typeof(T));
            return instance;
        }

        public object Resolve(Type srcType)
        {
            object instance = null;

            if(!_Insatnce.Mappings.TryGetValue(srcType, out var type))
                return instance;

            var emptyCtor = type.GetConstructor(new Type[] { });
            if (emptyCtor != null)
            {
                instance = emptyCtor.Invoke(new object[] { });
            }
            else
            {
                var complexCtor = type.GetConstructors()
                    .OrderByDescending(c => c.GetParameters().Length)
                    .Where(c =>
                    {
                        var paramenters = c.GetParameters();
                        var canBeResolved = paramenters.All(p => _Insatnce.Mappings.ContainsKey(p.ParameterType));
                        return canBeResolved;
                    })
                    .FirstOrDefault();

                if (complexCtor != null)
                {
                    var args = new List<object>();

                    complexCtor.GetParameters().ToList().ForEach(p =>
                    {
                        var arg = Resolve(p.ParameterType);
                        args.Add(arg);
                    });

                    instance = complexCtor.Invoke(args.ToArray());
                }
            }

            return instance;
        }
    }
}
