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
        public async Task<IActionResult> GetAll(int page)
        {
            var movie = await _movieService.GetAll(page);
            return Ok(movie);
        }

        [Route("/Movies/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAllNotWatched(int id, int page)
        {
            var movie = await _movieService.GetAllNotWatched(id, page);
            return Ok(movie);
        }

        [HttpGet("Collection/{collection}")]
        public async Task<IActionResult> GetByCollection(string collection, int page)
        {
            var list = await _movieService.GetByCollection(collection, page);
            return Ok(list);
        }

        [HttpGet("Lang/{lang}")]
        public async Task<IActionResult> GetByLanguage(string lang, int page)
        {
            var list = await _movieService.GetByLanguage(lang, page);
            return Ok(list);
        }

        [HttpGet("Title/{title}")]
        public async Task<IActionResult> GetByTitle(string title, int page)
        {
            var list = await _movieService.GetByTitle(title, page);
            return Ok(list);
        }

        [HttpGet("Date/{date}/Flag/{flag}")]
        public async Task<IActionResult> GetByDate(DateTime date, int flag, int page)
        {
            var list = await _movieService.GetByDate(date, flag, page);
            return Ok(list);
        }

        [HttpGet("Time/{runtime}/Flag/{flag}")]
        public async Task<IActionResult> GetByRuntime(int runtime, int flag, int page)
        {
            var list = await _movieService.GetByRuntime(runtime, flag, page);
            return Ok(list);
        }

        [HttpGet("Genre/{genre}")]
        public async Task<IActionResult> GetByGenre(string genre, int page)
        {
            var list = await _movieService.GetByGenre(genre, page);
            return Ok(list);
        }

        [HttpGet("Rating/{rating}/Flag/{flag}")]
        public async Task<IActionResult> GetByRating(int rating, int flag, int page)
        {
            var list = await _movieService.GetByRating(rating, flag, page);
            return Ok(list);
        }

        [HttpGet("Post/{post}")]
        public async Task<IActionResult> GetByPost(bool post, int page)
        {
            var movie = await _movieService.GetByPost(post, page);
            return Ok(movie);
        }
    }
}
