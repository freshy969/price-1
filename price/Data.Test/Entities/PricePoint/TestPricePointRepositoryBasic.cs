using Infrastructure.NHibernate;
using NHibernate;
using Xunit;
using Test.Commons;
using System.Linq;
using System.Collections.Generic;
using Data.Entities.PricePoint;
using System;

namespace Data.Test.Entities.PricePoint
{
    [Collection("DB")]
    public class TestPricePointRepositoryBasic : TestBase
    {

        private readonly PricePointEntity[] _Items =
        {
            PricePointEntity.Create(1, 20.4m, new DateTime(2016, 1, 1)),
            PricePointEntity.Create(2, 11.1m, new DateTime(2016, 1, 1)),
            PricePointEntity.Create(3, 10m, new DateTime(2016, 1, 1)),
        };

        private IPricePointRepository repository;

        public TestPricePointRepositoryBasic(DbSessionFixture fixture) : base(fixture)
        {
            repository = new PricePointRepository();
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
            var point = PricePointEntity.Create(3, 5m, new DateTime(2016, 1, 1));

            repository.Add(point);
            NhibernateUnitOfWork.Current.Commit();

            // use session to try to load the product
            using (ISession session = Fixture.SessionFactory.OpenSession())
            {
                Assert.True(point.Id > 3);
                var fromDb = session.Get<PricePointEntity>(point.Id);

                // Test that the product was successfully inserted
                Assert.NotNull(fromDb);
                Assert.Equal(fromDb.Id, point.Id);
                Assert.NotSame(point, fromDb);
                Assert.Equal(3, fromDb.ItemId);
                Assert.Equal(5m, fromDb.Price);
                Assert.Equal(new DateTime(2016, 1, 1, 0, 0, 0, DateTimeKind.Utc), fromDb.Date);
                Assert.Equal(2016, fromDb.Year);
                Assert.Equal(1, fromDb.Month);
                Assert.Equal(1, fromDb.Day);
            }
        }

        [Fact]
        public void Update_ExistingItem_WhenFound()
        {
            PricePointEntity point = _Items[0];
            point.Price = 123m;

            repository.Update(point);

            var fromDb = NhibernateUnitOfWork.Current.Session.Get<PricePointEntity>(point.Id);
            Assert.Equal(123m, fromDb.Price);
        }

        [Fact]
        public void Update_ThrowsException_WhenExecutedOnANewObject()
        {
            var first = repository.GetAll().First();

            PricePointEntity point = new PricePointEntity()
            {
                Id = first.Id
            };

            Assert.ThrowsAny<NonUniqueObjectException>(() => repository.Update(point));
        }

        [Fact]
        public void Remove_ExistingItem_WhenFound()
        {
            var point = _Items[0];
            repository.Delete(point.Id);

            var fromDb = NhibernateUnitOfWork.Current.Session.Get<PricePointEntity>(point.Id);
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
            Assert.NotSame(_Items[2], fromDb);
            Assert.Equal(3, fromDb.ItemId);
            Assert.Equal(10m, fromDb.Price);
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
            List<PricePointEntity> fromDb = repository.GetAll().ToList();

            Assert.NotNull(fromDb);
            Assert.Equal(3, fromDb.Count);
        }
    }
}
