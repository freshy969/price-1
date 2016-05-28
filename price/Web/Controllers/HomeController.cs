using System.Web.Mvc;
using BusinessLogic.ServiceInterfaces;
using System.Collections.Generic;
using Model.Item;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemService _itemService;
        
        public HomeController(IItemService itemService)
        {
            _itemService = itemService;
        }

        public ActionResult Index()
        {
            ViewBag.ItemList = _itemService.GetAll();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}