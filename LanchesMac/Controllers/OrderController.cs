using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository orderRepository, Cart cart)
        {
            _orderRepository = orderRepository;
            _cart = cart;
        }

        [HttpGet]
        public IActionResult Checkout() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            return View();
        }

    }

}
