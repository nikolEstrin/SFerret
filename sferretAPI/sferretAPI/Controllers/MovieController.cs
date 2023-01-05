using Microsoft.AspNetCore.Mvc;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace sferretAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IConfiguration _config;
        public MovieController(IConfiguration config, IMovieService movieService)
        {
            _config = config;
            _movieService = movieService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _movieService.Get(id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }

        [Route("/Movies")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movie = await _movieService.GetAll();
            return Ok(movie);
        }

        [HttpGet("Collection/{collection}")]
        public async Task<IActionResult> GetByCollection(string collection)
        {
            var list = await _movieService.GetByCollection(collection);
            return Ok(list);
        }

        [HttpGet("Lang/{lang}")]
        public async Task<IActionResult> GetByLanguage(string lang)
        {
            var list = await _movieService.GetByLanguage(lang);
            return Ok(list);
        }

        [HttpGet("Title/{title}")]
        public async Task<IActionResult> GetByTitle(string title)
        {
            var list = await _movieService.GetByTitle(title);
            return Ok(list);
        }

        [HttpGet("Date/{date}/Flag/{flag}")]
        public async Task<IActionResult> GetByDate(DateTime date, int flag)
        {
            var list = await _movieService.GetByDate(date, flag);
            return Ok(list);
        }

        [HttpGet("Time/{runtime}/Flag/{flag}")]
        public async Task<IActionResult> GetByRuntime(int runtime, int flag)
        {
            var list = await _movieService.GetByRuntime(runtime, flag);
            return Ok(list);
        }

        [HttpGet("Genre/{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            var list = await _movieService.GetByGenre(genre);
            return Ok(list);
        }

        [HttpGet("Rating/{rating}/Flag/{flag}")]
        public async Task<IActionResult> GetByRating(int rating, int flag)
        {
            var list = await _movieService.GetByRating(rating, flag);
            return Ok(list);
        }

        [HttpGet("Post/{post}")]
        public async Task<IActionResult> GetByPost(bool post)
        {
            var movie = await _movieService.GetByPost(post);
            return Ok(movie);
        }
    }
}
