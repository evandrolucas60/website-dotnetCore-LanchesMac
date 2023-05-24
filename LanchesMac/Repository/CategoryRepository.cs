using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;

namespace LanchesMac.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Categories => _context.Categories;

    }
}
