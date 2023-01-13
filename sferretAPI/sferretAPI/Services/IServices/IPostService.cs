using sferretAPI.Models;

namespace sferretAPI.Services.IServices
{
    public interface IPostService
    {
        /// <summary>
        /// Get Post details by given Id
        /// </summary>
        /// <param name="id">Post's Id</param>
        /// <returns>Post object</returns>
        public Task<Post> Get(int id);

        /// <summary>
        /// Get Post details by given movie's and user's Ids
        /// </summary>
        /// <param name="movieId">Movie's Id</param>
        /// <param name="userId">User's Id</param>
        /// <returns>Post object</returns>
        public Task<Post> Get(int movieId, int userId);

        /// <summary>
        /// Delete post by user's and movie's Ids
        /// </summary>
        /// <param name="movieId">Movie's Id</param>
        /// <param name="userId">User's Id</param>
        /// <returns></returns>
        public Task Delete(int movieId, int userId);

        /// <summary>
        /// Update post's details
        /// </summary>
        /// <param name="post">Post object with details to update</param>
        /// <returns>Post object with updated details</returns>
        public Task Update(Post post);

        /// <summary>
        /// Add new post to DB
        /// </summary>
        /// <param name="post">Post object to add</param>
        /// <returns>Post object</returns>
        public Task Create(Post post);

        /// <summary>
        /// Retrive all posts from DB
        /// </summary>
        /// <returns>List of Post objects</returns>
        public Task<List<Post>> GetAll();

        /// <summary>
        /// Get all posts that are matching with given rating
        /// If flag equals 1, we get all posts with rating that is greater or equal to given value
        /// If flag equals 0, we get all posts with rating that is equal to given value
        /// If flag equals -1, we get all posts with rating that is less or equal to given value
        /// </summary>
        /// <param name="rating">Int value between 1-5/10</param>
        /// <param name="flag">"Boolean" value</param>
        /// <returns>List of Post objects</returns>
        public Task<List<Post>> GetByRating(int rating, int flag);

        /// <summary>
        /// Get all posts that are tagged as given genre
        /// </summary>
        /// <param name="genre">Genre name</param>
        /// <returns>List of Post objects</returns>
        public Task<List<Post>> GetByGenre(string genre);

        /// <summary>
        /// Get all posts about given movie
        /// </summary>
        /// <param name="movieId">Movie's Id</param>
        /// <returns>List of Post objects</returns>
        public Task<List<Post>> GetByMovie(int movieId);

        /// <summary>
        /// Get all posts that a given user wrote
        /// </summary>
        /// <param name="userId">User's id</param>
        /// <returns>List of Post objects</returns>
        public Task<List<Post>> GetByUser(int userId);

        /// <summary>
        /// Retrive all movies that have posts in DB
        /// </summary>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetAll_Movies();

        /// <summary>
        /// Get all movies that have posts in DB that are matching with given rating
        /// If flag equals 1, we get all posts with rating that is greater or equal to given value
        /// If flag equals 0, we get all posts with rating that is equal to given value
        /// If flag equals -1, we get all posts with rating that is less or equal to given value
        /// </summary>
        /// <param name="rating">Int value between 1-5/10</param>
        /// <param name="flag">"Boolean" value</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByRating_Movies(int rating, int flag);

        /// <summary>
        /// Get all movies that have posts in DB that are tagged as given genre
        /// </summary>
        /// <param name="genre">Genre name</param>
        /// <returns>List of movie id's</returns>
        public Task<List<Movie>> GetByGenre_Movies(string genre);

        /// <summary>
        /// Get all movies that have posts in DB that a given user wrote
        /// </summary>
        /// <param name="userId">User's id</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByUser_Movies(int userId);
    }
}
