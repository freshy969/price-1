using NHibernate;
using NHibernate.Cfg;

namespace Test.Commons
{
    public interface IHasConfigurationAndSessionFactory
    {
        Configuration Configuration { get; }

        ISessionFactory SessionFactory { get; }
    }
}
