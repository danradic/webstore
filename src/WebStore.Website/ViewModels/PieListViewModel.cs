using WebStore.Website.Models;

namespace WebStore.Website.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; }
        public string? CurrentCategory { get; }

        public PieListViewModel(IEnumerable<Pie> pies, string? category)
        {
            Pies = pies;
            CurrentCategory = category;
        }
    }
}
