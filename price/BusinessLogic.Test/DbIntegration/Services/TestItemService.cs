using System.Linq;
using BusinessLogic.Services;
using NHibernate;
using NHibernate.Linq;
using Xunit;
using BusinessLogic.ServiceInterfaces;
using Test.Commons;
using Data.Entities.Item;
using Infrastructure.NHibernate;
using Model.Item;

namespace BusinessLogic.Test.DbIntegration.Service
{
    public class TestItemService //: TestBase
    {
        /*protected override void InitAfterFixture(IHasConfigurationAndSessionFactory fixture, ISession session)
        {
            foreach (var Item in _Items)
            {
                session.Save(Item);
            }
        }*/

        private readonly ItemEntity[] _Items = 
        {
            new ItemEntity {Id = 1, Url = "Text1", Text = "Text1"},
            new ItemEntity {Id = 2, Url = "Text2", Text = "Text2"},
            new ItemEntity {Id = 3, Url = "Text3", Text = "Text3"},
            new ItemEntity {Id = 4, Url = "Text4", Text = "Text4"},
            new ItemEntity {Id = 5, Url = "Text5", Text = "Text5"},
        };
        /*
        public TestItemService(DbSessionFixture fixture) : base(fixture)
        {
        }*/

        //[Fact]
        public void Can_Remove_Existing_Item_In_Service()
        {
            var prop = _Items[0];
            IItemService service = new ItemService(new ItemRepository());
            ItemData actual = service.GetItem(prop.Id);

            Assert.Equal(1, actual.Id);
        }
    }
}
