using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;
using MySql.Data.MySqlClient;

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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM WatchList WHERE UserId = @UserId AND MovieId = @MovieId";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
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
                                throw new Exception("user already added this movie to his list");
                        }
                    }
                    string addToListSql = @"INSERT INTO WatchList (UserId, MovieId)
                            VALUES(@UserId, @MovieId)";

                    using (MySqlCommand command1 = new MySqlCommand(addToListSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command1.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = movieId;
                        command1.Parameters.Add(param);
                        using (MySqlDataReader reader1 = command1.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                continue;
                            }
                        }
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
                List<WatchList> wl = new List<WatchList>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WatchList wlItem = new WatchList();
                                wlItem.Id = reader.GetInt32("Id");
                                wlItem.UserId = reader.GetInt32("UserId");
                                wlItem.MovieId = reader.GetInt32("MovieId");
                                wl.Add(wlItem);
                            }
                        }
                    }
                    return await ConvertMovies(wl, "none", true);
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
                List<WatchList> wl = new List<WatchList>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WatchList wlItem = new WatchList();
                                wlItem.Id = reader.GetInt32("Id");
                                wlItem.UserId = reader.GetInt32("UserId");
                                wlItem.MovieId = reader.GetInt32("MovieId");
                                wl.Add(wlItem);
                            }
                        }
                    }
                    return await ConvertMovies(wl, "AB", order);
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
                List<WatchList> wl = new List<WatchList>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WatchList wlItem = new WatchList();
                                wlItem.Id = reader.GetInt32("Id");
                                wlItem.UserId = reader.GetInt32("UserId");
                                wlItem.MovieId = reader.GetInt32("MovieId");
                                wl.Add(wlItem);
                            }
                        }
                    }
                    return await ConvertMovies(wl, "RD", order);
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
                List<WatchList> wl = new List<WatchList>();
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM WatchList WHERE UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                WatchList wlItem = new WatchList();
                                wlItem.Id = reader.GetInt32("Id");
                                wlItem.UserId = reader.GetInt32("UserId");
                                wlItem.MovieId = reader.GetInt32("MovieId");
                                wl.Add(wlItem);
                            }
                        }
                    }
                    return await ConvertMovies(wl, "RT", order);
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
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "DELETE FROM WatchList WHERE UserId = @UserId AND MovieId = @MovieId";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@MovieId";
                        param.Value = movieId;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@UserId";
                        param.Value = userId;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                throw new Exception("Delete Error");
                        }
                    }
                }

                return await Get(userId);
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
