using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
