using Infrastructure.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;

namespace Test.Commons
{
    public class DbSessionFixture : IHasConfigurationAndSessionFactory, IDisposable
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly Configuration _configuration;

        public ISessionFactory SessionFactory
        {
            get
            {
                return _sessionFactory;
            }
        }

        public Configuration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        public DbSessionFixture()
        {
            _configuration = NHibernateHelper.Configuration;
            _sessionFactory = NHibernateHelper.SessionFactory;

            // Deletes all data in the database
            new SchemaExport(_configuration).Execute(true, true, false);

            NhibernateUnitOfWork.Current = new NhibernateUnitOfWork(_sessionFactory);
        }

        public void Dispose()
        {
            try
            {
                NhibernateUnitOfWork.Current.Commit();
            }
            catch (Exception)
            {
                try
                {
                    NhibernateUnitOfWork.Current.Rollback();
                }
                catch
                {

                }
            }
            finally
            {
                NhibernateUnitOfWork.Current = null;
            }
        }
    }
}
