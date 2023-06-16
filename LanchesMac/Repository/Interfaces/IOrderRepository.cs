using LanchesMac.Models;

namespace LanchesMac.Repository.Interfaces
{
    public interface IOrderRepository
    {
        void createOrder(Order order);
    }
}
