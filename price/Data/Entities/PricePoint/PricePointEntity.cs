using Data.Generic;
using System;

namespace Data.Entities.PricePoint
{
    public class PricePointEntity : IGenericEntity
    {
        public virtual long Id { get; set; }

        public virtual long Item { get; set; }

        public virtual decimal Price { get; set; }

        public virtual DateTime Date { get; set; }

        public virtual int Year { get; set; }

        public virtual int Month { get; set; }

        public virtual long Source { get; set; }

        public virtual DateTime DateEntered { get; set; }
    }
}
