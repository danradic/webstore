using BethanysPieShop.Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Website.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository,
            IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order) 
        {
            if(!ModelState.IsValid) return View(order);

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (!_shoppingCart.ShoppingCartItems.Any()) 
            {
                ModelState.AddModelError("", "Your cart is empty, please add some pies first");
                return View(order);
            }

            _orderRepository.CreateOrder(order);
            _shoppingCart.ClearCart();

            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou() 
        {
            ViewBag.ThankYouMessage = "Thank you for your order. You'll soon enjoy our delicios pies!";
            return View();
        }

    }
}
