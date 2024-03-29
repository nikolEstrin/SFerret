﻿using MySql.Data.MySqlClient;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;
using System.Security.Cryptography;


namespace sferretAPI.Services
{
    public class PostService : IPostService
    {
        private readonly string _connectionstring;
        private readonly IMovieService _movieService;
        public PostService(IConfiguration configuration, IMovieService movieService)
        {
            _connectionstring = configuration.GetConnectionString("SFerretDB");
            _movieService = movieService;
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
                            if (!reader.HasRows)
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

        public async Task<List<Post>> GetByMovieTitle(string title)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT Post.* FROM Post, Movie
                    WHERE Post.MovieId = Movie.Id AND REGEXP_LIKE (Movie.Title, @Title) ORDER BY Post.MovieId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Title";
                        param.Value = title;
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

        public async Task<List<Post>> GetByUser(string name)
        {
            try
            {
                List<Post> posts = new List<Post>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT Post.* FROM Post, User 
                    WHERE User.Id = Post.UserId AND REGEXP_LIKE (User.FullName, @Name) ORDER BY Post.MovieId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Name";
                        param.Value = name;
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

        public async Task<List<PostMovie>> GetAll_Movies()
        {
            try
            {
                List<int> posts = new List<int>();
                int mid;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "SELECT DISTINCT MovieId FROM Post ORDER BY MovieId";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mid = reader.GetInt32("MovieId");
                                posts.Add(mid);
                            }
                        }
                    }
                }
                return await ConvertMovies(posts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PostMovie>> GetByGenre_Movies(string genre)
        {

            //var dbGenre = await con.QueryAsync<Genre>("SELECT * FROM Genre WHERE Name = @Name", new { Name = genre });
            //if (dbGenre == null)
            //    throw new Exception("No such genre " + genre);

            try
            {
                List<int> posts = new List<int>();
                int mid;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT DISTINCT Post.MovieId FROM Post, MovieGenre, Genre
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
                                mid = reader.GetInt32("MovieId");
                                posts.Add(mid);
                            }
                        }
                    }
                }
                return await ConvertMovies(posts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PostMovie>> GetByRating_Movies(int rating, int flag)
        {
            try
            {
                List<int> posts = new List<int>();
                int mid;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = "";
                    if (flag == 1) // GREATER THAN
                        getPostSql = @"SELECT DISTINCT MovieId FROM Post WHERE Rating > @Rating ORDER BY MovieId";
                    else if (flag == 0) // EQUAL TO
                        getPostSql = @"SELECT DISTINCT MovieId FROM Post WHERE Rating = @Rating ORDER BY MovieId";
                    else if (flag == -1) // LESS THAN
                        getPostSql = @"SELECT DISTINCT MovieId FROM Post WHERE Rating < @Rating ORDER BY MovieId";
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
                                mid = reader.GetInt32("MovieId");
                                posts.Add(mid);
                            }
                        }
                    }
                }
                return await ConvertMovies(posts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PostMovie>> GetByUser_Movies(string name)
        {
            try
            {
                List<int> posts = new List<int>();
                int mid;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT DISTINCT Post.MovieId FROM Post, User 
                    WHERE User.Id = Post.UserId AND REGEXP_LIKE (User.FullName, @Name)";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Name";
                        param.Value = name;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mid = reader.GetInt32("MovieId");
                                posts.Add(mid);
                            }
                        }
                    }
                }
                return await ConvertMovies(posts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<PostMovie>> GetByMovieTitle_Movies(string title)
        {
            try
            {
                List<int> posts = new List<int>();
                int mid;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getPostSql = @"SELECT DISTINCT Post.MovieId FROM Post, Movie
                    WHERE Post.MovieId = Movie.Id AND REGEXP_LIKE (Movie.Title, @Title)";
                    using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Title";
                        param.Value = title;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                mid = reader.GetInt32("MovieId");
                                posts.Add(mid);
                            }
                        }
                    }
                }
                return await ConvertMovies(posts);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Convert from list of ids to list of PostMovie objects
        /// </summary>
        /// <param name="movies">List of movie ids</param>
        /// <returns>List of PostMovie objects</returns>
        private async Task<List<PostMovie>> ConvertMovies(IEnumerable<int> movies)
        {
            try
            {
                List<Movie> MovieList = new List<Movie>();
                foreach (int item in movies)
                {
                    Movie movie = await _movieService.Get(item);
                    MovieList.Add(movie);
                }
                List<PostMovie> PostMovieList = new List<PostMovie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    foreach (Movie movie in MovieList)
                    {
                        PostMovie pm = new PostMovie();
                        pm.Id = movie.Id;
                        pm.Title = movie.Title;
                        pm.Adult = movie.Adult;
                        pm.Overview = movie.Overview;
                        pm.PosterPath = movie.PosterPath;
                        pm.Collection = movie.Collection;
                        pm.Language = movie.Language;
                        pm.ReleaseDate = movie.ReleaseDate;
                        pm.Runtime = movie.Runtime;
                        string getPostSql = @"SELECT AVG(Post.Rating) AS avgRate FROM Post WHERE Post.MovieId=@MovieId";
                        using (MySqlCommand command = new MySqlCommand(getPostSql, con))
                        {
                            MySqlParameter param = new MySqlParameter();
                            param.ParameterName = "@MovieId";
                            param.Value = pm.Id;
                            command.Parameters.Add(param);
                            using (MySqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    pm.AvgRating = reader.GetFloat("avgRate");
                                }
                            }
                        }
                        PostMovieList.Add(pm);
                    }
                }
                return PostMovieList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
