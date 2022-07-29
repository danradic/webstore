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
            IEnumerable<Pie> pies = _pieRepository.AllPies.OrderBy(p => p.Name);
            string? currentCategory;

            if (pies == null || !pies.Any()) return NotFound();

            if (string.IsNullOrEmpty(category))
            {
                currentCategory = "All pies";
                return View(new PieListViewModel(pies, currentCategory)); 
            }

            pies = pies.Where(p => p.Category.CategoryName == category);
            currentCategory = pies.FirstOrDefault(p => p.Category.CategoryName == category)?
                .Category.CategoryName;

            return View(new PieListViewModel(pies, currentCategory));
        }

        public IActionResult Details(int id) 
        {
            var pie = _pieRepository.GetPieById(id);

            if (pie == null) return NotFound();

            return View(pie);
        }

        public IActionResult Search()
        {
            return View();
        }

    }
}
