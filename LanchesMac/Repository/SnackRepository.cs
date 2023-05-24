using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repository
{
    public class SnackRepository : ISnackRepository
    {
        private readonly AppDbContext _context;

        public SnackRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Snack> Snacks => _context.Snacks
            .Include(c => c.Category);

        public IEnumerable<Snack> FavoriteSnacks => _context.Snacks
            .Where(s => s.IsFavoriteSnack)
            .Include(c => c.Category);

        public Snack GetSnackById(int id)
        {
            return _context.Snacks.FirstOrDefault(s => s.SnackId == id);
        }
    }
}
