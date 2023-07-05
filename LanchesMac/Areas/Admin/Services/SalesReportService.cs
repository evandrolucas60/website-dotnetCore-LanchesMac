using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Areas.Admin.Services
{
    public class SalesReportService
    {
        private readonly AppDbContext _context;

        public SalesReportService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.Orders select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.OrderDispatched >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.OrderDispatched <= maxDate.Value);
            }

            return await result
                .Include(l => l.OrderItems)
                .ThenInclude(l => l.Snack)
                .OrderByDescending(x => x.OrderDispatched)
                .ToListAsync();
        }

    }
}
