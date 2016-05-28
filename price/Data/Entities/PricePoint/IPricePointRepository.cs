using System.Collections.Generic;
using Data.Generic;

namespace Data.Entities.PricePoint
{
    public interface IPricePointRepository : IGenericRepository<PricePointEntity>
    {
        IList<PricePointEntity> GetItemPricesForYears(long itemId, int fromYear, int toYear);
    }
}
