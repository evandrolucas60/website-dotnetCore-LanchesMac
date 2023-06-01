using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using LanchesMac.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class CartController : Controller
    {
        private readonly ISnackRepository _snackRepository;
        private readonly Cart _cart;

        public CartController(ISnackRepository snackRepository, Cart cart)
        {
            _snackRepository = snackRepository;
            _cart = cart;
        }

        public IActionResult Index()
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

        public IActionResult AddItemToCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks
                .FirstOrDefault(p => p.SnackId == snackId);

            if (selectedSnack != null)
            {
                _cart.AddToCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemToCart(int snackId)
        {
            var selectedSnack = _snackRepository.Snacks
                .FirstOrDefault(p => p.SnackId == snackId);

            if (selectedSnack != null)
            {
                _cart.RemoveFromCart(selectedSnack);
            }

            return RedirectToAction("Index");
        }
    }
}
 