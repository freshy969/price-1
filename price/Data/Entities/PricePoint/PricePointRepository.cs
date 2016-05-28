using System;
using System.Collections.Generic;
using System.Linq;
using Data.Generic;

namespace Data.Entities.PricePoint
{
    public class PricePointRepository : GenericRepository<PricePointEntity>, IPricePointRepository
    {
        public IList<PricePointEntity> GetItemPricesForYears(long itemId, int fromYear, int toYear)
        {
            return Session.QueryOver<PricePointEntity>()
                .Where(a => a.ItemId == itemId && a.Year >= fromYear && a.Year <= toYear)
                .OrderBy(a => a.Date).Asc
                .List();
        }
    }
}
