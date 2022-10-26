using WebStore.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Website.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]   
        public IActionResult GetAll() 
        {
            var allPies = _pieRepository.AllPies;
            return Ok(allPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            var pieById = _pieRepository.GetPieById(id);
            
            if (pieById == null) return NotFound();

            return Ok(pieById);
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery) 
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (!string.IsNullOrEmpty(searchQuery)) 
            {
                pies = _pieRepository.SearchPies(searchQuery);
            }

            return new JsonResult(pies);
        }
    }
}
