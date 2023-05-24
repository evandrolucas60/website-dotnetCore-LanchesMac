using LanchesMac.Models;

namespace LanchesMac.Repository.Interfaces
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> FavoriteSnacks { get; }
        Snack GetSnackById(int id);

    }
}
