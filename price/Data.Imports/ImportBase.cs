using Infrastructure.NHibernate;
using System;
using Test.Commons;

namespace Data.Test
{
    public abstract class ImportBase : IDisposable
    {
        protected IHasConfigurationAndSessionFactory Fixture;

        protected ImportBase(IHasConfigurationAndSessionFactory fixture)
        {
            SetFixture(fixture);
            // this is needed to start transaction for repositories
            NhibernateUnitOfWork.Current.BeginTransaction();
        }

        private void SetFixture(IHasConfigurationAndSessionFactory data)
        {
            Fixture = data;
        }

        public void Dispose()
        {
            NhibernateUnitOfWork.Current.Commit();
            var session = NhibernateUnitOfWork.Current.Session;
            if (session != null && session.IsOpen)
            {
                session.Close();
            }
        }
    }
}
