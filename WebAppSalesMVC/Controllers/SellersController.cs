using Microsoft.AspNetCore.Mvc;

namespace WebAppSalesMVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}