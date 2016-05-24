using Infrastructure.NHibernate;
using NHibernate;
using System;
using Test.Commons;

namespace Data.Test
{
    public abstract class TestBase : IDisposable
    {
        protected IHasConfigurationAndSessionFactory Fixture;

        protected TestBase(IHasConfigurationAndSessionFactory fixture)
        {
            SetFixture(fixture);
            // this is needed to start transaction for repositories
            NhibernateUnitOfWork.Current.BeginTransaction();
        }

        private void SetFixture(IHasConfigurationAndSessionFactory data)
        {
            Fixture = data;

            // create a session for the initialization of data
            using (ISession session = data.SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var tableCleaner = new TableCleaner();
                tableCleaner.ClearAllTables(session);

                InitAfterFixture(Fixture, session);
                transaction.Commit();
            }
        }

        protected virtual void InitAfterFixture(IHasConfigurationAndSessionFactory fixture, ISession session)
        {
        }

        public void Dispose()
        {
            var session = NhibernateUnitOfWork.Current.Session;
            if (session != null && session.IsOpen)
            {
                session.Close();
            }
        }
    }
}
