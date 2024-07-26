using Microsoft.EntityFrameworkCore;
using Pagination.Data;
using Pagination.Models;

namespace Pagination.Service
{
    public class PlayerService : IPlayerInterface
    {
        public readonly AppDbContext _context;

        public PlayerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Player> AddPlayer(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task<PaginatedList<Player>> GetPlayers(int pageIndex, int pageSize)
        {
            var players = await _context.Players
                .OrderBy(x => x.Id)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var count = await _context.Players.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);

            return new PaginatedList<Player>(players, totalPages, pageSize);
        }
    }
}
