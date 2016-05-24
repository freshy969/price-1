using System;
using Infrastructure.NHibernate;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Infrastructure.Attributes
{
    /// <summary>
    /// This attribute is used to indicate that declaring method is transactional (atomic).
    /// A method that has this attribute is intercepted, a transaction starts before call the method.
    /// At the end of method call, transaction is commited if there is no exception, othervise it's rolled back.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : HandlerAttribute
    {
        private readonly int _order;

        public TransactionAttribute(int order = 1)
        {
            _order = order;
        }

        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            return new UnitOfWorkCallHandler { Order = _order };
        }
    }
}
