using Dapper;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;
using System.Data.SqlClient;

namespace sferretAPI.Services
{
    public class PostService : IPostService
    {
        private readonly string _connectionstring;
        public PostService(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SFerretDB");
        }

        public async Task<Post> Create(Post post)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var dbPost = await con.QueryAsync<Post>("SELECT * FROM Post WHERE MovieId = @MovieId AND UserId = @UserId", new { MovieId = post.MovieId, UserId = post.UserId });
                    if (dbPost != null)
                        throw new Exception(String.Format("User {0} already created a post about Movie {1}", post.UserId, post.MovieId));

                    string addPostSql = @"INSERT INTO Post (UserId, MovieId, Rating, Comment, PublishedDate)
                    OUTPUT INSERTED.[Id]
                    VALUES(@UserId, @MovieId, @Rating, @Comment, @PublishedDate)";
                    int id = await con.QuerySingleAsync<int>(addPostSql,
                        new
                        {
                            UserId = post.UserId,
                            MovieId = post.MovieId,
                            Rating = post.Rating,
                            Comment = post.Comment,
                            PublishedDate = DateTime.Now
                        });
                    if (id > 0)
                    {
                        post.Id = id;
                        return post;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> Update(Post post)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var dbPost = await con.QueryAsync<Post>("SELECT * FROM Post WHERE MovieId = @MovieId AND UserId = @UserId", new
                    {
                        UserId = post.UserId,
                        MovieId = post.MovieId
                    });
                    if (dbPost == null)
                        throw new Exception(String.Format("User {0} didnt wrote a post about Movie {1}", post.UserId, post.MovieId));

                    string updatePostSql = @"UPDATE Post SET Rating= @Rating, Comment = @Comment, PublishedDate = @PublishedDate 
                    WHERE MovieId = @MovieId AND UserId = @UserId";
                    var updateValues = new
                    {
                        UserId = post.UserId,
                        MovieId = post.MovieId,
                        Rating = post.Rating,
                        Comment = post.Comment,
                        PublishedDate = DateTime.Now
                    };
                    var result = await con.QueryAsync(updatePostSql, updateValues);
                    Post post1 = await GetByIds(post.MovieId, post.UserId, con);
                    return post1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int movieId, int userId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    await con.QuerySingleAsync("DELETE FROM Post WHERE MovieId = @MovieId AND UserId = @UserId", new { MovieId = movieId, UserId = userId });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> Get(int id)
        {
            try
            {
                Post post = null;
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post WHERE Id = @Id";
                    var posts = await con.QueryAsync<Post>(getPostSql, new { Id = id });
                    if (posts != null && posts.Any())
                        post = posts.FirstOrDefault();
                    return post;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> Get(int movieId, int userId)
        {
            try
            {
                Post post = null;
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var dbUser = await con.QueryAsync<User>("SELECT * FROM User WHERE Id = @Id", new {Id = userId});
                    if (dbUser == null)
                        throw new Exception("No such user " + userId);
                    var dbMovie = await con.QueryAsync<Movie>("SELECT * FROM Movie WHERE Id = @Id", new { Id = movieId });
                    if (dbMovie == null)
                        throw new Exception("No such movie " + movieId);

                    string getPostSql = "SELECT * FROM Post WHERE MovieId = @MovieId AND UserId = @UserId";
                    var posts = await con.QueryAsync<Post>(getPostSql, new { MovieId = movieId, UserId = userId });
                    if (posts != null && posts.Any())
                        post = posts.FirstOrDefault();
                    return post;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> GetAll()
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post ORDER BY MovieId";
                    var posts1 = await con.QueryAsync<Post>(getPostSql);
                    if (posts1 != null && posts1.Any())
                        posts = posts1.ToList();
                    return posts;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> GetByGenre(string genre)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var dbGenre = await con.QueryAsync<Genre>("SELECT * FROM Genre WHERE Name = @Name", new { Name = genre });
                    if (dbGenre == null)
                        throw new Exception("No such genre " + genre);

                    string getPostSql = @"SELECT Post.* FROM Post, MovieGenre, Genre
                    WHERE Post.MovieId = MovieGenre.MovieId AND MovieGenre.GenreId = Genre.Id AND Genre.Name = @Genre
                    ORDER BY Post.MovieId";
                    var posts1 = await con.QueryAsync<Post>(getPostSql, new { Genre = genre });
                    if (posts1 != null && posts1.Any())
                        posts = posts1.ToList();
                    return posts;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> GetByMovie(int movieId)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var dbMovie = await con.QueryAsync<Movie>("SELECT * FROM Movie WHERE Id = @Id", new { Id = movieId });

                    string getPostSql = "SELECT * FROM Post WHERE MovieId = @MovieId";
                    var posts1 = await con.QueryAsync<Post>(getPostSql, new { MovieId = movieId });
                    if (posts1 != null && posts1.Any())
                        posts = posts1.ToList();
                    return posts;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> GetByRating(int rating, int flag)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    string getPostSql = "";
                    if (flag == 1) // GREATER THAN
                        getPostSql = @"SELECT * FROM Post WHERE Rating > @Rating ORDER BY MovieId";
                    else if (flag == 0) // EQUAL TO
                        getPostSql = @"SELECT * FROM Post WHERE Rating = @Rating ORDER BY MovieId";
                    else if (flag == -1) // LESS THAN
                        getPostSql = @"SELECT * FROM Post WHERE Rating < @Rating ORDER BY MovieId";
                    var posts1 = await con.QueryAsync<Post>(getPostSql, new { Rating = rating });
                    if (posts1 != null && posts1.Any())
                        posts = posts1.ToList();
                    return posts;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> GetByUser(int userId)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post WHERE UserId = @UserId";
                    var posts1 = await con.QueryAsync<Post>(getPostSql, new { UserId = userId });
                    if (posts1 != null && posts1.Any())
                        posts = posts1.ToList();
                    return posts;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get post by movie's and user's ids
        /// </summary>
        /// <param name="movieId">Movie's id</param>
        /// <param name="userId">User's id</param>
        /// <param name="con">DbConnection object</param>
        /// <returns>Post object</returns>
        private async Task<Post> GetByIds(int movieId, int userId, IDbConnection con)
        {
            try
            {
                Post post = null;
                var posts = await con.QueryAsync<Post>("SELECT * FROM Post WHERE MovieId = @MovieId AND UserId = @UserId", new { MovieId = movieId, UserId = userId });
                if (posts != null && posts.Any())
                    post = posts.FirstOrDefault();
                return post;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
