using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Xunit;

namespace Data.Test
{
    public class TestGenerateSchema
    {
        [Fact]
        public void Can_Generate_Schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            
            new SchemaExport(cfg).Execute(true, true, false);
        }
    }
}
