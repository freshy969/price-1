using System.Web.Mvc;
using BusinessLogic.ServiceInterfaces;
using System.Collections.Generic;
using Model.Item;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _ItemService;
        
        public HomeController(IItemService ItemService)
        {
            _ItemService = ItemService;
        }

        public ActionResult Index()
        {
            ViewBag.NewestItems = new List<ItemDto>();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}