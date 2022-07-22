using BethanysPieShop.Website.Models;
using BethanysPieShop.Website.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Website.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, 
            ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List() 
        {
            return View(new PieListViewModel(_pieRepository.AllPies, "Cheese cakes"));
        }

    }
}
