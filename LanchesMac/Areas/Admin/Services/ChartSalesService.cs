using LanchesMac.Context;
using LanchesMac.Models;

namespace LanchesMac.Areas.Admin.Services
{
    public class ChartSalesService
    {
        private readonly AppDbContext _context;

        public ChartSalesService(AppDbContext context)
        {
            _context = context;
        }

        public List<SnackChart> GetSnacksSales(int days = 360)
        { 
            var date = DateTime.Now.AddDays(-days);

            var snacks = (from pd in _context.OrderDetails
                          join l in _context.Snacks on pd.SnackId equals l.SnackId
                          where pd.Order.OrderDispatched >= date
                          group pd by new { pd.SnackId, l.SnackName, pd.Quantity }
                          into g
                          select new
                          {
                              SnackName = g.Key.SnackName,
                              SnackQuantity = g.Sum(q => q.Quantity),
                              SnackTotalValue = g.Sum(a => a.Preco * a.Quantity)
                          });

            var list = new List<SnackChart>();

            foreach (var item in snacks)
            {
                var snack = new SnackChart();
                snack.SnackName = item.SnackName;
                snack.SnackQuantity = item.SnackQuantity;
                snack.SnackTotalValue = item.SnackTotalValue;
                list.Add(snack);
            }

            return list;    
        }
    }
}
