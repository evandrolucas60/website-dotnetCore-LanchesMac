using LanchesMac.Models;

namespace LanchesMac.Repository.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
