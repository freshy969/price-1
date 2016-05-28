using Data.Entities.Item;
using Infrastructure.NHibernate;
using NHibernate;
using Test.Commons;
using Xunit;

namespace Data.Test.Entities.Item
{
    [Collection("DB")]
    public class TestItemEntity : TestBase
    {
        public TestItemEntity(DbSessionFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public void Test_Item_Creation()
        {
            using (ISession session = NHibernateHelper.GetSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                var prop = new ItemEntity();
                prop.Id = 1;
                prop.Code = "1";
                prop.Text = "1";

                session.Save(prop);

                transaction.Commit();
            }
        }
    }
}
