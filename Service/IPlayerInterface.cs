using Pagination.Models;

namespace Pagination.Service
{
    public interface IPlayerInterface
    {
        Task<PaginatedList<Player>> GetPlayers(int pageIndex, int pageSize);
        Task<Player> AddPlayer(Player player);
    }
}
