using System.Collections.Generic;
using System.Linq;
using Data.Generic;

namespace Data.Entities.PricePoint
{
    public class PricePointRepository : GenericRepository<PricePointEntity>, IPricePointRepository
    {
        /*public List<PricePointEntity> GetTopNewestPricePoints(int limit)
        {
            return GetAll().ToList();
        }*/

        /*public PricePointEntity GetByItem(string url)
        {
            return Session
                .QueryOver<PricePointEntity>()
                .Where(c => c.Url == url)
                .SingleOrDefault();
        }*/
    }
}
