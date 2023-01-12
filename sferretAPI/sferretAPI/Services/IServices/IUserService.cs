using sferretAPI.Models;
namespace sferretAPI.Services.IServices
{
    public interface IUserService
    {
        /// <summary>
        /// Add new user to DB
        /// </summary>
        /// <param name="user">User's details (User object)</param>
        /// <returns>User object with updated details</returns>
        public Task<User> Register(User user);

        /// <summary>
        /// Login to service with username and password
        /// </summary>
        /// <param name="user">User Object with details to check</param>
        /// <returns>If user and password are correct return User's Id, else null</returns>
        public Task<int?> Login(User user);

        /// <summary>
        /// Get details of given user by ID
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>User object</returns>
        public Task<User> Get(int id);

        /// <summary>
        /// Get name of given user by id
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>User's name</returns>
        public Task<string?> GetName(int id);

    }
}
