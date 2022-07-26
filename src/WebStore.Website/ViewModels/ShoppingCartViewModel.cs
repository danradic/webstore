﻿using WebStore.Website.Models;

namespace WebStore.Website.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCart.GetShoppingCartTotal();
        }

        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; set; }
    }
}
