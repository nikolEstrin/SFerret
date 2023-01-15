using MySql.Data.MySqlClient;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;

namespace sferretAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly string _connectionstring;
        public MovieService(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SFerretDB");
            
        }

        public async Task<Movie> Get(int id)
        {
            try
            {
                Movie movie = null;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Id = @Id";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Id";
                        param.Value = id;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                            }
                        }
                    }
                    return movie;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetAll(int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetAllNotWatched(int id, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = @"SELECT * FROM Movie 
                                          WHERE Id NOT IN(SELECT MovieId FROM WatchList WHERE UserId=@Id)";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Id";
                        param.Value = id;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByCollection(string collection, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE REGEXP_LIKE (Collection, @Collection)";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Collection";
                        param.Value = collection;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByAdult(bool adult, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Adult = @Adult";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Adult";
                        param.Value = adult;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        //stupid date backwards
        public async Task<List<Movie>> GetByDate(DateTime date, int flag, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "";
                    if (flag == 1)
                        getMovieSql = "SELECT * FROM Movie WHERE DATEDIFF(ReleaseDate, @ReleaseDate) >= 0";
                    else if (flag == 0)
                        getMovieSql = "SELECT * FROM Movie WHERE DATEDIFF(ReleaseDate, @ReleaseDate) = 0";
                    else if (flag == -1)
                        getMovieSql = "SELECT * FROM Movie WHERE DATEDIFF(ReleaseDate, @ReleaseDate) <= 0";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@ReleaseDate";
                        param.Value = date;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByGenre(string genre, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = @"SELECT Movie.* FROM Movie, MovieGenre, Genre
                    WHERE Movie.Id = MovieGenre.MovieId AND MovieGenre.GenreId = Genre.Id AND Genre.GenreName = @Genre";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Genre";
                        param.Value = genre;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByLanguage(string lang, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Language = @Lang";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Lang";
                        param.Value = lang;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByPost(bool post, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "";
                    if (post) // Max num of posts
                        getMovieSql = @"SELECT *
                        FROM Movie
                        WHERE (SELECT COUNT(MovieId)
                                FROM Post
                                WHERE Post.MovieId=Movie.Id) = (SELECT MAX(c)
                                                                FROM (SELECT COUNT(MovieId) AS c
                                                                       FROM Post
                                                                       GROUP BY MovieId) AS countTable) ";
                    else //Min num of posts
                        getMovieSql = @"SELECT * 
                                        FROM movie, ((SELECT MovieId AS id, Count(*) as counter
												    FROM Post
												    GROUP BY MovieId) UNION ALL
												    (SELECT Id AS ID, 0 AS counter
												    FROM Movie
												    Where Movie.Id NOT IN(SELECT distinct MovieId From Post))) AS a
                                        WHERE movie.id=a.id and a.counter=(SELECT MIN(b.counter)
									                                        FROM ((SELECT MovieId AS ID, Count(*) as counter
												                                        FROM Post
												                                        GROUP BY MovieId) UNION ALL
												                                        (SELECT Id AS ID, 0 AS counter
												                                        FROM Movie
												                                        Where Movie.Id NOT IN(SELECT distinct MovieId From Post))) AS b)";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByRating(int rating, int flag, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = @"";
                    if (flag == 1) // GREATER THAN
                        getMovieSql = @"SELECT *
                        FROM Movie
                        Where (SELECT AVG(Post.Rating)
                                FROM Post
                                WHERE Post.MovieId=Movie.Id) > @X";
                    else if (flag == 0) // EQUAL TO
                        getMovieSql = @"SELECT *
                        FROM Movie
                        Where (SELECT AVG(Post.Rating)
                        FROM Post
                        WHERE Post.MovieId=Movie.Id) =@X";
                    else if (flag == -1) // LESS THAN
                        getMovieSql = @"SELECT Movie.*
                                        FROM Movie, ((SELECT MovieId AS ID, AVG(Rating) As avg
                                                    FROM Post
                                                    GROUP BY MovieId) UNION ALL
                                                    (SELECT Id AS ID , 0 AS avg
                                                    FROM Movie
                                                    WHERE Movie.Id NOT IN (SELECT distinct MovieId From Post))) AS a
                                        WHERE Movie.Id = a.ID AND a.avg < @X";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@X";
                        param.Value = rating;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByRuntime(int runtime, int flag, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "";
                    if (flag == 1)
                        getMovieSql = "SELECT * FROM Movie WHERE Runtime >= @Runtime";
                    else if (flag == 0)
                        getMovieSql = "SELECT * FROM Movie WHERE Runtime = @Runtime";
                    else if (flag == -1)
                        getMovieSql = "SELECT * FROM Movie WHERE Runtime <= @Runtime";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Runtime";
                        param.Value = runtime;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByTitle(string title, int page)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE REGEXP_LIKE (Title, @Title)";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Title";
                        param.Value = title;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Movie movie = new Movie();
                                movie.Id = reader.GetInt32("Id");
                                movie.Title = reader.GetString("Title");
                                movie.Adult = reader.GetBoolean("Adult");
                                movie.ReleaseDate = reader.GetDateTime("ReleaseDate");
                                movie.Runtime = reader.GetInt32("Runtime");
                                movie.PosterPath = reader.GetString("PosterPath");
                                movie.Overview = reader.GetString("Overview");
                                movie.Language = reader.GetString("Language");
                                movie.Collection = reader.GetString("Collection");
                                movies.Add(movie);
                            }
                        }
                    }
                    return movies.Skip((page - 1) * 50).Take(50).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
