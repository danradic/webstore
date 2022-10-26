using WebStore.Website.Models;
using WebStore.Website.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Website.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = shoppingCartItems;

            return View(new ShoppingCartViewModel(_shoppingCart));
        }
    }
}
