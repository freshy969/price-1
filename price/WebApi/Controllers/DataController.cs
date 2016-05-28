using BusinessLogic.ServiceInterfaces;
using Model.GoogleChart;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class DataController : ApiController
    {
        private readonly IPricePointService _service;

        public DataController(IPricePointService service)
        {
            _service = service;
        }

        [HttpGet]
        public DataTable Get(string item, int from, int to)
        {
            return _service.GetItemPricesForYears(item, from, to);
        }
    }
}
