using NHibernate;
using NHibernate.AspNet.Identity;
using NHibernate.AspNet.Identity.Helpers;
using NHibernate.Cfg;

namespace Infrastructure.NHibernate
{
    public sealed class NHibernateHelper
    {
        private static Configuration _configuration;

        public static Configuration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    var configuration = new Configuration();

                    configuration.Configure();
                    var myEntities = new[] {
                        typeof(IdentityUser)
                    };
                    configuration.AddDeserializedMapping(MappingHelper.GetIdentityMappings(myEntities), null);

                    _configuration = configuration;
                }
                return _configuration;
            }
        }

        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}