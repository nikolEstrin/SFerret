using sferretAPI.Models;

namespace sferretAPI.Services.IServices
{
    public interface IWatchListService
    {
        /// <summary>
        /// Get movie watchlist of given user (entering order)
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> Get(int userId);

        /// <summary>
        /// Get movie watchlist of given user (AB order)
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <param name="order">true for A to Z, false otherwise</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByAB(int userId, bool order);

        /// <summary>
        /// Get movie watchlist of given user (release date order)
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <param name="order">true for earliest to latest, false oterwise</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByRD(int userId, bool order);

        /// <summary>
        /// Get movie watchlist of given user (rumtime order)
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <param name="order">true for shortest to longest, false otherwise</param>
        /// <returns>List of Movie objects</returns>
        public Task<List<Movie>> GetByRT(int userId, bool order);

        /// <summary>
        /// Add new movie to user's watchlist
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <param name="movieId">Movie's Id</param>
        /// <returns>User's updated watchlist (list of Movie objects)</returns>
        public Task<List<Movie>> AddToList(int userId, int movieId);

        /// <summary>
        /// Remove given movie from user's watchlist
        /// </summary>
        /// <param name="userId">User's Id</param>
        /// <param name="movieId">Movie's Id</param>
        /// <returns>User's updated watchlist (list of Movie objects)</returns>
        public Task<List<Movie>> RemoveFromList(int userId, int movieId);
    }
}
