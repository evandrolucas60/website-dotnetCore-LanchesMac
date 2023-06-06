using LanchesMac.Models;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Components
{
    public class ResumeShoppingCart : ViewComponent
    {
        private readonly Cart _cart;

        public ResumeShoppingCart(Cart cart)
        {
            _cart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var itens = _cart.GetCartItens();

            _cart.CartItems = itens;

            var cartVM = new CartViewModel
            {
                Cart = _cart,
                CartTotal = _cart.GetCartTotal()
            };

            return View(cartVM);
        }
    }
}
