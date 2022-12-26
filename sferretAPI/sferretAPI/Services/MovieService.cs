using Dapper;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;
using System.Data.SqlClient;

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
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Id = @Id";
                    var movies = await con.QueryAsync<Movie>(getMovieSql, new { Id = id });
                    if (movies != null && movies.Any())
                        movie = movies.FirstOrDefault();
                    return movie;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Movie> Get(string name)
        {
            try
            {
                Movie movie = null;
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Title = @Name";
                    var movies = await con.QueryAsync<Movie>(getMovieSql, new { Name = name });
                    if (movies != null && movies.Any())
                        movie = movies.FirstOrDefault();
                    return movie;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetAll()
        {
            try
            {
                List<Movie> movie = null;
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie";
                    var movies = await con.QueryAsync<Movie>(getMovieSql);
                    if (movies != null && movies.Any())
                        movie = movies.ToList();
                    return movie;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByCollection(string collection)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Collection LIKE '%@Collection%'";
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql, new { Collection = collection });
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByAdult(bool adult)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Adult = @Adult";
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql, new { Adult = adult });
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByDate(DateTime date, int flag)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
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
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql, new { ReleaseDate = date });
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByGenre(string genre)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var dbGenre = await con.QueryAsync<Genre>("SELECT * FROM Genre WHERE Name = @Name", new { Name = genre });

                    string getMovieSql = @"SELECT Movie.* FROM Movie, MovieGenre, Genre
                    WHERE Movie.Id = MovieGenre.MovieId AND MovieGenre.GenreId = Genre.Id AND Genre.Name = @Genre";
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql, new { Genre = genre });
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByLanguage(string lang)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Language = @Lang";
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql, new { Lang = lang });
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByPost(bool post)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "";
                    if (post) // Max num of posts
                        getMovieSql = @"SELECT *
                        FROM Movie
                        WHERE (SELECT COUNT(movieID)
                                FROM Post
                                WHERE Post.movieId=Movie.Id) = (SELECT MAX(c)
                                                                FROM (SELECT COUNT(movieID) AS c
                                                                       FROM Post
                                                                       GROUP BY movieID) AS countTable) ";
                    else //Min num of posts
                        getMovieSql = @"";
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql);
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByRating(int rating, int flag)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = @"";
                    if (flag == 1) // GREATER THAN
                        getMovieSql = @"SELECT *
                        FROM Movie
                        Where (SELECT AVG(Post.Rating)
                        FROM Post
                        WHERE Post.movieID=Movie.ID) > x";
                    else if (flag == 0) // EQUAL TO
                        getMovieSql = @"SELECT *
                        FROM Movie
                        Where (SELECT AVG(Post.Rating)
                        FROM Post
                        WHERE Post.movieID=Movie.ID) = x";
                    else if (flag == -1) // LESS THAN
                        getMovieSql = @""; 
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql); // ########  ADD VALUES HERE  ##########
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByRuntime(int runtime, int flag)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
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
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql, new { Runtime = runtime });
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByTitle(string title)
        {
            try
            {
                List<Movie> movies = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM Movie WHERE Title LIKE '%@Title%'";
                    var movies1 = await con.QueryAsync<Movie>(getMovieSql, new { Title = title });
                    if (movies1 != null && movies1.Any())
                        movies = movies1.ToList();
                    return movies;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
