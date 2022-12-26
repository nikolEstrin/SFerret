using Microsoft.AspNetCore.Mvc;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace sferretAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WatchListController : Controller
    {
        private readonly IWatchListService _watchListService;
        private readonly IConfiguration _config;
        public WatchListController(IConfiguration config, IWatchListService watchListService)
        {
            _config = config;
            _watchListService = watchListService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetWatchList(int userId)
        {
            var list = await _watchListService.Get(userId);
            return Ok(list);
        }

        [HttpPost("{userId}/Movie/{movieId}")]
        public async Task<IActionResult> AddToWatchList(int movieId, int userId)
        {
            var list = await _watchListService.AddToList(userId, movieId);
            return Ok(list);
        }

        [HttpDelete("{userId}/Movie/{movieId}")]
        public async Task<IActionResult> DeleteFromWatchList(int movieId, int userId)
        {
            var list = await _watchListService.RemoveFromList(userId, movieId);
            return Ok(list);
        }
    }
}
