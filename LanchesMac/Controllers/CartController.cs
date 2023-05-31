using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
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
            return View();
        }
    }
}
