using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;

namespace LanchesMac.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly Cart _cart;

        public OrderRepository(AppDbContext appDbContext, Cart cart)
        {
            _appDbContext = appDbContext;
            _cart = cart;
        }

        public void createOrder(Order order)
        {
           order.OrderDispatched = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var carItems = _cart.CartItems;

            foreach (var item in carItems) 
            {
                var orderDetail = new OrderDetail()
                {
                    Quantity = item.Quantity,
                    SnackId = item.Snack.SnackId,
                    OrderId = order.OrderId,
                    Preco = item.Snack.Price
                };

                _appDbContext.OrderDetails.Add(orderDetail);
            }

            _appDbContext.SaveChanges();
        }
    }
}
