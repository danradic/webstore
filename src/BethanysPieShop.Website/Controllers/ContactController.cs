using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Website.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
