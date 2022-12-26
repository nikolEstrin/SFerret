using Dapper;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;
using System.Data.SqlClient;

namespace sferretAPI.Services
{
    public class WatchListService : IWatchListService
    {
        private readonly string _connectionstring;
        private readonly IMovieService _movieService;
        public WatchListService(IConfiguration configuration, IMovieService movieService)
        {
            _connectionstring = configuration.GetConnectionString("SFerretDB");
            _movieService = movieService;
        }

        public async Task<List<Movie>> AddToList(int userId, int movieId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();

                    var dbWl = await con.QueryAsync<WatchList>("SELECT * FROM WatchList WHERE UserId = @UserId AND MovieId = @MovieId", new { UserId = userId, MovieId = movieId });
                    if (dbWl == null || dbWl.Count() == 0)
                    {
                        string addToListSql = @"INSERT INTO WatchList (UserId, MovieId)
                        OUTPUT INSERTED.[Id]
                        VALUES(@UserId, @MovieId)";
                        int id = await con.QuerySingleAsync<int>(addToListSql, new { UserId = userId, MovieId = movieId });
                    }
                    return await Get(userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> Get(int userId)
        {
            try
            {
                List<Movie> wl = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getListSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    var movies = await con.QueryAsync<WatchList>(getListSql, new { Id = userId });
                    if (movies != null && movies.Any())
                        wl = await ConvertMovies(movies, "none", true);
                    return wl;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByAB(int userId, bool order)
        {
            try
            {
                List<Movie> wl = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getListSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    var movies = await con.QueryAsync<WatchList>(getListSql, new { Id = userId });
                    if (movies != null && movies.Any())
                        wl = await ConvertMovies(movies, "AB", order);
                    return wl;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByRD(int userId, bool order)
        {
            try
            {
                List<Movie> wl = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getListSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    var movies = await con.QueryAsync<WatchList>(getListSql, new { Id = userId });
                    if (movies != null && movies.Any())
                        wl = await ConvertMovies(movies, "RD", order);
                    return wl;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> GetByRT(int userId, bool order)
        {
            try
            {
                List<Movie> wl = new List<Movie>();
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getListSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    var movies = await con.QueryAsync<WatchList>(getListSql, new { Id = userId });
                    if (movies != null && movies.Any())
                        wl = await ConvertMovies(movies, "RT", order);
                    return wl;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Movie>> RemoveFromList(int userId, int movieId)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string removeFromListSql = @"DELETE FROM WatchList WHERE UserId = @UserId AND MovieId = @MovieId";
                    await con.QuerySingleAsync(removeFromListSql, new { UserId = userId, MovieId = movieId });
                    return await Get(userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Convert from list of ids to list of Movie objects
        /// </summary>
        /// <param name="movies">List of movie ids</param>
        /// <param name="order">true - first to last, false otherwise</param>
        /// <param name="by">string that determines what to order by</param>
        /// <returns>List of Movie objects</returns>
        private async Task<List<Movie>> ConvertMovies(IEnumerable<WatchList> movies, string by, bool order)
        {
            try
            {
                List<Movie> MovieList = new List<Movie>();
                foreach (WatchList item in movies)
                {
                    Movie movie = await _movieService.Get(item.MovieId);
                    MovieList.Add(movie);
                }
                if (by != "none")
                {
                    if (by == "RD")
                    {
                        if (order)
                            MovieList.OrderBy(m => m.ReleaseDate);
                        else
                            MovieList.OrderByDescending(m => m.ReleaseDate);
                    }
                    else if (by == "RT")
                    {
                        if (order)
                            MovieList.OrderBy(m => m.Runtime);
                        else
                            MovieList.OrderByDescending(m => m.Runtime);
                    }
                    else
                    {
                        if (order)
                            MovieList.OrderBy(m => m.Title);
                        else
                            MovieList.OrderByDescending(m => m.Title);
                    }
                }
                else
                    MovieList.Reverse();
                return MovieList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
