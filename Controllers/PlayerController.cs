using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination.Models;
using Pagination.Service;

namespace Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerInterface _playerInterface;

        public PlayerController(IPlayerInterface playerInterface)
        {
            _playerInterface = playerInterface;
        }
        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetPlayer(int pageIndex = 1, int pageSize = 10)
        {
            var players = await _playerInterface.GetPlayers(pageIndex, pageSize);
            return new ApiResponse(true, null, players);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> AddPlayer(Player player)
        {
            var newPlayer = await _playerInterface.AddPlayer(player);
            return new ApiResponse(true, null, newPlayer);
        }
    }
}
