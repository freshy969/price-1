using Xunit;
using Test.Commons;
using Data.Entities.PricePoint;
using System.IO;
using System.Collections.Generic;
using Data.Entities.Item;
using System.Globalization;
using BusinessLogic.ServiceInterfaces;
using BusinessLogic.Services;
using System;
using BusinessLogic.Utils;

namespace Data.Test.Entities.PricePoint
{
    [Collection("DB")]
    public class TestImportCsvData : ImportBase
    {
        private IPricePointRepository _pricePointRepository;
        private IItemService _itemService;

        public TestImportCsvData(DbSessionFixture fixture) : base(fixture)
        {
            _pricePointRepository = new PricePointRepository();
            _itemService = new ItemService(new ItemRepository());
        }

        //[Fact]
        public void GetItemPricesForYears_ReturnsAllRecords()
        {
            string dir = Directory.GetCurrentDirectory();
            int binIndex = dir.IndexOf("\\bin\\");
            dir = dir.Substring(0, binIndex);
            string path = Path.Combine(dir, "DepartmentOfStatistics\\CSV\\Eksportuota matricinė lentelė.csv");

            var reader = new StreamReader(File.OpenRead(path));
            List<string> listA = new List<string>();
            List<string> listB = new List<string>();
            List<string> listC = new List<string>();
            string itemName = null;
            var now = DateTime.UtcNow;
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                if (!string.IsNullOrWhiteSpace(values[0]))
                {
                    itemName = values[0];
                }
                if (string.IsNullOrWhiteSpace(itemName))
                {
                    continue;
                }

                int year;
                var yearOk = int.TryParse(values[1], out year);
                decimal priceInLtl;
                var priceOk = decimal.TryParse(values[2], NumberStyles.Number, CultureInfo.InvariantCulture, out priceInLtl);

                if (yearOk && priceOk)
                {
                    var item = _itemService.EnsureItemWithUnit(itemName);

                    PricePointEntity pricePoint = new PricePointEntity
                    {
                        Date = new DateTime(year, 10, 1),
                        DateEntered = now,
                        Year = year,
                        Month = 10,
                        Day = 1,
                        ItemId = item.Id,
                        SourceId = 1,
                        Price = CurrencyUtils.ConvertToEur(priceInLtl)
                    };
                    _pricePointRepository.Add(pricePoint);
                }
            }
        }
    }
}
