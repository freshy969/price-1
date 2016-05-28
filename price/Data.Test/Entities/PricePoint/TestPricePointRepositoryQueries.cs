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
    public class TestPricePointRepositoryQueries : TestBase
    {

        private readonly PricePointEntity[] _Items =
        {
            PricePointEntity.Create(1, 20.4m, new DateTime(2016, 1, 1)),
            PricePointEntity.Create(2, 11.1m, new DateTime(2016, 1, 1)),
            PricePointEntity.Create(3, 10m, new DateTime(2016, 1, 1)),

            PricePointEntity.Create(3, 8m, new DateTime(2014, 1, 1)),
            PricePointEntity.Create(1, 20.4m, new DateTime(2014, 2, 1)),

            PricePointEntity.Create(3, 9m, new DateTime(2015, 8, 1)),
            PricePointEntity.Create(1, 20.4m, new DateTime(2015, 9, 1)),

            
        };

        private IPricePointRepository repository;

        public TestPricePointRepositoryQueries(DbSessionFixture fixture) : base(fixture)
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
        public void GetItemPricesForYears_ReturnsAllRecords()
        {
            IList<PricePointEntity> fromDb = repository.GetItemPricesForYears(3, 2014, 2016);

            Assert.Equal(3, fromDb.Count);
            Assert.Equal(8m, fromDb[0].Price);
            Assert.Equal(9m, fromDb[1].Price);
            Assert.Equal(10m, fromDb[2].Price);
        }
    }
}
