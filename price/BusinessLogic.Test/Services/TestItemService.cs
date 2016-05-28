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
            new ItemEntity {Id = 1, Code = "Text1", Text = "Text1"},
            new ItemEntity {Id = 2, Code = "Text2", Text = "Text2"},
            new ItemEntity {Id = 3, Code = "Text3", Text = "Text3"},
            new ItemEntity {Id = 4, Code = "Text4", Text = "Text4"},
            new ItemEntity {Id = 5, Code = "Text5", Text = "Text5"},
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
            ItemDto actual = null;// service.GetItem(prop.Id);

            Assert.Equal("1", actual.Code);
        }
    }
}
