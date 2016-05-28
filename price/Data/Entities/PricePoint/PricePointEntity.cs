using Data.Generic;
using System;

namespace Data.Entities.PricePoint
{
    public class PricePointEntity : IGenericEntity
    {
        public virtual long Id { get; set; }

        public virtual long ItemId { get; set; }

        public virtual decimal Price { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int Year { get; set; }

        public virtual int Month { get; set; }

        public virtual int Day { get; set; }

        public virtual long? SourceId { get; set; }

        public virtual DateTime DateEntered { get; set; }

        public static PricePointEntity Create(long itemId, decimal price, DateTime date, long? sourceId = null)
        {
            return new PricePointEntity
            {
                ItemId = itemId,
                Price = price,
                Date = date,
                Year = date.Year,
                Month = date.Month,
                Day = date.Day,
                DateEntered = DateTime.UtcNow,
                SourceId = sourceId
            };
        }
    }
}
