using System;
using BusinessLogic.ServiceInterfaces;
using Data.Entities.PricePoint;
using Infrastructure.Attributes;
using Model.GoogleChart;
using System.Collections.Generic;
using Data.Entities.Item;

namespace BusinessLogic.Services
{
    public class PricePointService : IPricePointService
    {
        private readonly IPricePointRepository _rep;
        private readonly IItemRepository _itemRep;

        public PricePointService(IPricePointRepository repository, IItemRepository itemRepository)
        {
            _rep = repository;
            _itemRep = itemRepository;
        }

        [Transaction]
        public DataTable GetItemPricesForYears(string itemCode, int fromYear, int toYear)
        {
            var item = _itemRep.GetByCode(itemCode);
            if (item == null)
            {
                throw new Exception("Item not found.");
            }
            var points = _rep.GetItemPricesForYears(item.Id, fromYear, toYear);

            var result = new DataTable();

            result.Cols = new List<TableColumn>
            {
                new TableColumn { Id = "date", Label = "Laikas", Type = "date" },
                new TableColumn { Id = "data", Label = item.Text, Type = "number" }
            };

            var rows = new List<TableRow>();
            foreach(var point in points)
            {
                var row = new TableRow();
                row.Cells = new List<TableCell>
                {
                    new TableCell { Value = point.Date },
                    new TableCell { Value = point.Price }
                };
                rows.Add(row);
            }
            result.Rows = rows;

            return result;
        }
    }
}
