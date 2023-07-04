using LanchesMac.Models;

namespace LanchesMac.ViewModels
{
    public class SnackOrderViewModel
    {
        public Order Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
