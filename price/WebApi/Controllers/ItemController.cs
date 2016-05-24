using BusinessLogic.ServiceInterfaces;
using Model.Item;
using System.Collections.Generic;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class ItemController : ApiController
    {
        private readonly IItemService _service;

        public ItemController(IItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public IList<ItemData> Get()
        {
            return new List<ItemData> { _service.GetItem(1) };
        }
    }
}
