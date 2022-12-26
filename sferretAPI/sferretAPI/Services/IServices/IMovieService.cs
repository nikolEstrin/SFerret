using sferretAPI.Models;

namespace sferretAPI.Services.IServices
{
    public interface IMovieService
    {
        /// <summary>
        /// Get movie by id
        /// </summary>
        /// <param name="id">Movie's id</param>
        /// <returns>Movie object</returns>
        public Task<Movie> Get(int id);
        /// <summary>
        /// Get movie by name
        /// </summary>
        /// <param name="name">Movie's name</param>
        /// <returns>Movie object</returns>
        public Task<Movie> Get(string name);

        /// <summary>
        /// Retrive all movies from DB
        /// </summary>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetAll();

        /// <summary>
        /// Get all movies for adults/kids
        /// </summary>
        /// <param name="adult">Boolean value for adults or kids</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByAdult(bool adult);

        /// <summary>
        /// Get all movies from a given collection
        /// </summary>
        /// <param name="collection">Collection's name</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByCollection(string collection);

        /// <summary>
        /// Get all movies in a given language
        /// </summary>
        /// <param name="lang">Languge</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByLanguage(string lang);

        /// <summary>
        /// Get all movies that their title match given string
        /// </summary>
        /// <param name="title"(substring of) >Movie's title</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByTitle(string title);

        /// <summary>
        /// Get all movies that are matching with given release date
        /// If flag equals 1, we get all movies that were released on or after given date
        /// If flag equals 0, we get all movies that were released on given date
        /// If flag equals -1, we get all movies that were released in or before given date
        /// </summary>
        /// <param name="date">DateTime object</param>
        /// <param name="flag">"Boolean" value</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByDate(DateTime date, int flag);

        /// <summary>
        /// Get all movies that are matching with given runtime
        /// If flag equals 1, we get all movies with runtime that is greater or equal to given value
        /// If flag equals 0, we get all movies with runtime that is equal to given value
        /// If flag equals -1, we get all movies with runtime that is less or equal to given value
        /// </summary>
        /// <param name="runtime">Int runtime value</param>
        /// <param name="flag">"Boolean" value</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByRuntime(int runtime, int flag);

        /// <summary>
        /// Get all movies that are tagged as given genre
        /// </summary>
        /// <param name="genre">Genre's name</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByGenre(string genre);

        /// <summary>
        /// Get all movies that are matching with given rating
        /// If flag equals 1, we get all movies with average rating that is greater or equal to given value
        /// If flag equals 0, we get all movies with average rating that is equal to given value
        /// If flag equals -1, we get all movies with average rating that is less or equal to given value
        /// </summary>
        /// <param name="rating">Int value 1-5/10</param>
        /// <param name="flag">"Boolean" value</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByRating(int rating, int flag);

        /// <summary>
        /// Get all movies with most/least posts about
        /// </summary>
        /// <param name="post">Boolean value, True for most and False for least</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByPost(bool post);
    }
}
