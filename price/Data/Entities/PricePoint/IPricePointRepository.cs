using System.Collections.Generic;
using Data.Generic;

namespace Data.Entities.PricePoint
{
    public interface IPricePointRepository : IGenericRepository<PricePointEntity>
    {
        //List<PricePointEntity> GetTopNewestPricePoints(int v);

        //PricePointEntity GetByUrl(string url);
    }
}
