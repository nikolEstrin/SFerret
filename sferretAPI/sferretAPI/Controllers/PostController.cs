using Microsoft.AspNetCore.Mvc;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace sferretAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IConfiguration _config;
        public PostController(IConfiguration config, IPostService postService)
        {
            _config = config;
            _postService = postService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post)
        {
            await _postService.Create(post);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Post post)
        {
            await _postService.Update(post);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int movieId, int userId)
        {
            await _postService.Delete(movieId, userId);
            return Ok();
        }

        [HttpGet]
        [Route("/Posts")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _postService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.Get(id);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpGet("{userId}/Movie/{movieId}")]
        public async Task<IActionResult> Get(int movieId, int userId)
        {
            var post = await _postService.Get(movieId, userId);
            if (post == null)
                return NotFound();
            return Ok(post);
        }

        [HttpGet("Rating/{rating}/Flag/{flag}")]
        public async Task<IActionResult> GetByRating(int rating, int flag)
        {
            var posts = await _postService.GetByRating(rating, flag);
            return Ok(posts);
        }

        [HttpGet("Genre/{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            var posts = await _postService.GetByGenre(genre);
            return Ok(posts);
        }

        [HttpGet("Movie/{movieId}")]
        public async Task<IActionResult> GetByMovie(int movieId)
        {
            var posts = await _postService.GetByMovie(movieId);
            return Ok(posts);
        }

        [HttpGet("Movie/Title/{title}")]
        public async Task<IActionResult> GetByMovieTitle(string title)
        {
            var posts = await _postService.GetByMovieTitle(title);
            return Ok(posts);
        }

        [HttpGet("User/{name}")]
        public async Task<IActionResult> GetByUser(string name)
        {
            var posts = await _postService.GetByUser(name);
            return Ok(posts);
        }

        [HttpGet("Rating/{rating}/Flag/{flag}/Movies")]
        public async Task<IActionResult> GetByRating_Movies(int rating, int flag)
        {
            var posts = await _postService.GetByRating_Movies(rating, flag);
            return Ok(posts);
        }

        [HttpGet("Genre/{genre}/Movies")]
        public async Task<IActionResult> GetByGenre_Movies(string genre)
        {
            var posts = await _postService.GetByGenre_Movies(genre);
            return Ok(posts);
        }

        [HttpGet]
        [Route("/Posts/Movies")]
        public async Task<IActionResult> GetAll_Movies()
        {
            var result = await _postService.GetAll_Movies();
            return Ok(result);
        }

        [HttpGet("User/{name}/Movies")]
        public async Task<IActionResult> GetByUser_Movies(string name)
        {
            var posts = await _postService.GetByUser_Movies(name);
            return Ok(posts);
        }

        [HttpGet("Movie/Title/{title}/Movies")]
        public async Task<IActionResult> GetByMovieTitle_Movies(string title)
        {
            var posts = await _postService.GetByMovieTitle_Movies(title);
            return Ok(posts);
        }
    }
}
