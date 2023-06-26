using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;

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

        [Authorize]
        [HttpGet]
        public IActionResult Checkout() 
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int orderItensTotal = 0;
            decimal orderPriceTotal = 0.0m;

            //obter os itens do carrinho de compra do cliente
            List<CartItem> items = _cart.GetCartItens(); 
            _cart.CartItems = items;

            //verifica se existem itens de pedido
            if (_cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio, que tal incluir um lanche...");
            }

            //calcular o total de itens e o total do pedido 
            foreach (var item in items)
            {
                orderItensTotal += item.Quantity;
                orderPriceTotal += (item.Snack.Price * item.Quantity);
            }

            //atribuir os valores obtidos ao pedido
            order.TotalOrderItems = orderItensTotal;
            order.TotalOrder = orderPriceTotal;

            //validar os dados do pedido
            if (ModelState.IsValid)
            {
                //criar o pedido e os detalhes
                _orderRepository.createOrder(order);

                //define mensagens ao cliente
                ViewBag.CheckoutCompleteMessage = "Obrigado pelo seu pedido :)";
                ViewBag.TotalOrder = _cart.GetCartTotal();

                //limpa o carrinho do cliente
                _cart.ClearCart();

                //exibe a view com os dados do cliente e do pedido
                return View("~/Views/Order/CompleteCheckout.cshtml", order);
            }

            return View(order);
        }

    }

}
