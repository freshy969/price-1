using System;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace Infrastructure.NHibernate
{
    public class UnitOfWorkCallHandler : ICallHandler
    {
        
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            //If there is a running transaction, just run the method
            if (NhibernateUnitOfWork.Current != null)
            {
                return getNext().Invoke(input, getNext);
            }

            try
            {
                NhibernateUnitOfWork.Current = new NhibernateUnitOfWork(NHibernateHelper.SessionFactory);

                var unitOfWork = NhibernateUnitOfWork.Current;
                unitOfWork.BeginTransaction();
                
                IMethodReturn result = getNext().Invoke(input, getNext);
                if (result.Exception != null)
                {
                    unitOfWork.Rollback();
                }
                else
                {
                    try
                    {
                        unitOfWork.Commit();
                    }
                    catch(Exception exc)
                    {
                        unitOfWork.Rollback();

                        result.Exception = exc;
                    }
                }

                return result;
            }
            finally
            {
                NhibernateUnitOfWork.Current = null;
            }
        }

        public int Order { get; set; }
    }
}
