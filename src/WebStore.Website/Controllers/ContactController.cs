using Microsoft.AspNetCore.Mvc;

namespace WebStore.Website.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
