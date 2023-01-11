using MySql.Data.MySqlClient;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;


namespace sferretAPI.Services
{
    public class PostService : IPostService
    {
        private readonly string _connectionstring;
        public PostService(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SFerretDB");
        }

        public async Task Create(Post post)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT * FROM Post WHERE MovieId = @MovieId AND UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = post.MovieId;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = post.UserId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                throw new Exception("user already post about this movie");
                        }
                    }
                    string addPostSql = @"INSERT INTO Post (UserId, MovieId, Rating, Comment, PublishedDate)
                            VALUES(@UserId, @MovieId, @Rating, @Comment, @PublishedDate)";

                    using (MySqlCommand command1 = new MySqlCommand(addPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = post.MovieId;
                        command1.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = post.UserId;
                        command1.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@Rating";
                        param.Value = post.Rating;
                        command1.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@Comment";
                        param.Value = post.Comment;
                        command1.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@PublishedDate";
                        param.Value = DateTime.Now;
                        command1.Parameters.Add(param);
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(Post post)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT * FROM Post WHERE MovieId = @MovieId AND UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = post.MovieId;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = post.UserId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                throw new Exception("user didnt post about this movie");
                        }
                    }
                    string addPostSql = @"UPDATE Post SET Rating= @Rating, Comment = @Comment, PublishedDate = @PublishedDate 
                            WHERE MovieId = @MovieId AND UserId = @UserId";

                    using (MySqlCommand command = new MySqlCommand(addPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = post.MovieId;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = post.UserId;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@Rating";
                        param.Value = post.Rating;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@Comment";
                        param.Value = post.Comment;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@PublishedDate";
                        param.Value = DateTime.Now;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                continue;
                            }
                        }
                    }
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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "DELETE FROM Post WHERE MovieId = @MovieId AND UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = movieId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                throw new Exception("Delete Error");
                        }
                    }
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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Id";
                        param.Value = id;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                post = new Post();
                                post.Id = reader.GetInt32("Id");
                                post.UserId = reader.GetInt32("UserId");
                                post.MovieId = reader.GetInt32("MovieId");
                                post.Comment = reader.GetString("Comment");
                                post.Rating = reader.GetInt32("Rating");
                                post.PublishedDate = reader.GetDateTime("PublishedDate");
                            }
                        }
                    }
                }
                return post;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Post> Get(int movieId, int userId)
        {

            //var dbUser = await con.QueryAsync<User>("SELECT * FROM User WHERE Id = @Id", new { Id = userId });
            //if (dbUser == null)
            //    throw new Exception("No such user " + userId);
            //var dbMovie = await con.QueryAsync<Movie>("SELECT * FROM Movie WHERE Id = @Id", new { Id = movieId });
            //if (dbMovie == null)
            //    throw new Exception("No such movie " + movieId);

            try
            {
                Post post = null;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post WHERE MovieId = @MovieId AND UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = movieId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                post = new Post();
                                post.Id = reader.GetInt32("Id");
                                post.UserId = reader.GetInt32("UserId");
                                post.MovieId = reader.GetInt32("MovieId");
                                post.Comment = reader.GetString("Comment");
                                post.Rating = reader.GetInt32("Rating");
                                post.PublishedDate = reader.GetDateTime("PublishedDate");
                            }
                        }
                    }
                }
                return post;
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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post ORDER BY MovieId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Post post = new Post();
                                post.Id = reader.GetInt32("Id");
                                post.UserId = reader.GetInt32("UserId");
                                post.MovieId = reader.GetInt32("MovieId");
                                post.Comment = reader.GetString("Comment");
                                post.Rating = reader.GetInt32("Rating");
                                post.PublishedDate = reader.GetDateTime("PublishedDate");
                                posts.Add(post);
                            }
                        }
                    }
                }
                return posts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Post>> GetByGenre(string genre)
        {

            //var dbGenre = await con.QueryAsync<Genre>("SELECT * FROM Genre WHERE Name = @Name", new { Name = genre });
            //if (dbGenre == null)
            //    throw new Exception("No such genre " + genre);

            try
            {
                List<Post> posts = new List<Post>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT Post.* FROM Post, MovieGenre, Genre
                    WHERE Post.MovieId = MovieGenre.MovieId AND MovieGenre.GenreId = Genre.Id AND Genre.GenreName = @Genre
                    ORDER BY Post.MovieId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Genre";
                        param.Value = genre;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Post post = new Post();
                                post.Id = reader.GetInt32("Id");
                                post.UserId = reader.GetInt32("UserId");
                                post.MovieId = reader.GetInt32("MovieId");
                                post.Comment = reader.GetString("Comment");
                                post.Rating = reader.GetInt32("Rating");
                                post.PublishedDate = reader.GetDateTime("PublishedDate");
                                posts.Add(post);
                            }
                        }
                    }
                }
                return posts;
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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post WHERE MovieId = @MovieId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = movieId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Post post = new Post();
                                post.Id = reader.GetInt32("Id");
                                post.UserId = reader.GetInt32("UserId");
                                post.MovieId = reader.GetInt32("MovieId");
                                post.Comment = reader.GetString("Comment");
                                post.Rating = reader.GetInt32("Rating");
                                post.PublishedDate = reader.GetDateTime("PublishedDate");
                                posts.Add(post);
                            }
                        }
                    }
                }
                return posts;
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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
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
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Rating";
                        param.Value = rating;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Post post = new Post();
                                post.Id = reader.GetInt32("Id");
                                post.UserId = reader.GetInt32("UserId");
                                post.MovieId = reader.GetInt32("MovieId");
                                post.Comment = reader.GetString("Comment");
                                post.Rating = reader.GetInt32("Rating");
                                post.PublishedDate = reader.GetDateTime("PublishedDate");
                                posts.Add(post);
                            }
                        }
                    }
                }
                return posts;
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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT * FROM Post WHERE UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Post post = new Post();
                                post.Id = reader.GetInt32("Id");
                                post.UserId = reader.GetInt32("UserId");
                                post.MovieId = reader.GetInt32("MovieId");
                                post.Comment = reader.GetString("Comment");
                                post.Rating = reader.GetInt32("Rating");
                                post.PublishedDate = reader.GetDateTime("PublishedDate");
                                posts.Add(post);
                            }
                        }
                    }
                }
                return posts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
