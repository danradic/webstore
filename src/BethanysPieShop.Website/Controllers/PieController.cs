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

        public IActionResult List(string category) 
        {
            var pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category);

            return View(new PieListViewModel(pies, category));
        }

        public IActionResult Details(int id) 
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null) return NotFound();

            return View(pie);
        }

    }
}
