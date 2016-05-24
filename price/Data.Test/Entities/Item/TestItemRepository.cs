using Infrastructure.NHibernate;
using NHibernate;
using Xunit;
using Test.Commons;
using Data.Entities.Item;
using System.Linq;
using System.Collections.Generic;

namespace Data.Test.Entities.Item
{
    [Collection("DB")]
    public class TestItemRepository : TestBase
    {

        private readonly ItemEntity[] _Items =
        {
            new ItemEntity ("Melon"),
            new ItemEntity ("Pear"),
            new ItemEntity ("Apple")
        };

        private IItemRepository repository;

        public TestItemRepository(DbSessionFixture fixture) : base(fixture)
        {
            repository = new ItemRepository();
        }

        protected override void InitAfterFixture(IHasConfigurationAndSessionFactory fixture, ISession session)
        {
            foreach (var Item in _Items)
            {
                session.Save(Item);
            }
        }

        [Fact]
        public void Add_WhenIdIsZero_SavesANewEntity()
        {
            var prop = new ItemEntity();
            prop.Url = "Item4";
            prop.Text = "Item4";

            repository.Add(prop);
            NhibernateUnitOfWork.Current.Commit();

            // use session to try to load the product
            using (ISession session = Fixture.SessionFactory.OpenSession())
            {
                var fromDb = session.Get<ItemEntity>(prop.Id);

                // Test that the product was successfully inserted
                Assert.NotNull(fromDb);
                Assert.NotSame(prop, fromDb);
                Assert.Equal("Item4", fromDb.Url);
                Assert.Equal("Item4", fromDb.Text);
                Assert.True(fromDb.Id > 3);
            }
        }

        [Fact]
        public void Add_ThrowsAnException_WhenSettingTheSameUrl()
        {
            var prop = new ItemEntity();
            prop.Url = "pear";
            prop.Text = "Pears";

            Assert.ThrowsAny<NHibernate.Exceptions.GenericADOException>(() => repository.Add(prop));
        }

        [Fact]
        public void Add_ThrowsAnException_WhenFieldValueIsNull()
        {
            var prop = new ItemEntity();
            prop.Url = "orange";
            prop.Text = null;

            Assert.ThrowsAny<PropertyValueException>(() => repository.Add(prop));
        }

        [Fact]
        public void Add_ThrowsAnException_WhenEmptyObject()
        {
            var prop = new ItemEntity();

            Assert.ThrowsAny<PropertyValueException>(() => repository.Add(prop));
        }

        [Fact]
        public void Update_ExistingItem_WhenFound()
        {
            ItemEntity prop = _Items[0];
            prop.Url = "Changed url";

            repository.Update(prop);

            var fromDb = NhibernateUnitOfWork.Current.Session.Get<ItemEntity>(prop.Id);
            Assert.Equal("Changed url", fromDb.Url);
        }

        [Fact]
        public void Update_ThrowsException_WhenExecutedOnANewObject()
        {
            var first = repository.GetAll().First();

            ItemEntity prop = new ItemEntity()
            {
                Id = first.Id,
                Url = "Changed url",
                Text = "Melon"
            };

            Assert.ThrowsAny<NonUniqueObjectException>(() => repository.Update(prop));
        }

        [Fact]
        public void Remove_ExistingItem_WhenFound()
        {
            var prop = _Items[0];
            repository.Delete(prop.Id);

            var fromDb = NhibernateUnitOfWork.Current.Session.Get<ItemEntity>(prop.Id);
            Assert.Null(fromDb);
        }

        [Fact]
        public void Remove_ExistingItem_WhenNotFound()
        {
            Assert.Throws<ObjectNotFoundException>(() => repository.Delete(_Items.Last().Id + 1));
        }

        [Fact]
        public void GetById_ReturnsARecord_WhenFound()
        {
            var fromDb = repository.GetById(_Items.Last().Id);

            Assert.NotNull(fromDb);
            Assert.NotSame(_Items[1], fromDb);
            Assert.Equal("Apple", fromDb.Url);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenNotFound()
        {
            var fromDb = repository.GetById(_Items.Last().Id + 1);

            Assert.Null(fromDb);
        }

        [Fact]
        public void GetAll_ReturnsAllRecords()
        {
            List<ItemEntity> fromDb = repository.GetAll().ToList();

            Assert.NotNull(fromDb);
            Assert.Equal(3, fromDb.Count);
        }

        [Fact]
        public void GetByUrl_ReturnsARecord_WhenFound()
        {
            ItemEntity fromDb = repository.GetByUrl("Apple");

            Assert.NotNull(fromDb);
            Assert.Equal(_Items.Last().Id, fromDb.Id);
        }

        [Fact]
        public void GetByUrl_ReturnsNull_WhenNotFound()
        {
            ItemEntity fromDb = repository.GetByUrl("Apples");

            Assert.Null(fromDb);
        }
    }
}
