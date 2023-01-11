using MySql.Data.MySqlClient;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;

namespace sferretAPI.Services
{
    public class UserService : IUserService
    {
        private readonly string _connectionstring;
        public UserService(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("SFerretDB");
        }

        public async Task<User> Get(int id)
        {
            try
            {
                User user = null;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM User WHERE Id = @Id";
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
                                user = new User();
                                user.Id = reader.GetInt32("Id");
                                user.FullName = reader.GetString("FullName");
                                user.Password = reader.GetString("Password");
                            }
                        }
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Get(string name)
        {
            try
            {
                User user = null;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM User WHERE FullName = @Name";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Name";
                        param.Value = name;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user = new User();
                                user.Id = reader.GetInt32("Id");
                                user.FullName = reader.GetString("FullName");
                                user.Password = reader.GetString("Password");
                            }
                        }
                    }
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int?> Login(User user)
        {
            try
            {
                User user1 = null;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = "SELECT * FROM User WHERE FullName = @Name";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@Name";
                        param.Value = user.FullName;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user1 = new User();
                                user1.Id = reader.GetInt32("Id");
                                user1.FullName = reader.GetString("FullName");
                                user1.Password = reader.GetString("Password");
                            }
                        }
                    }
                    if (user1 != null && user1.Password == user.Password)
                        return user1.Id;
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> Register(User user)
        {
            try
            {
                int id = 0;
                using (MySqlConnection con = new MySqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getMovieSql = @"INSERT INTO User (FullName, Password)
                    OUTPUT INSERTED.[Id]
                    VALUES(@FullName, @Password)";
                    using (MySqlCommand command = new MySqlCommand(getMovieSql, con))
                    {
                        MySqlParameter param = new MySqlParameter();
                        param.ParameterName = "@FullName";
                        param.Value = user.FullName;
                        command.Parameters.Add(param);
                        param = new MySqlParameter();
                        param.ParameterName = "@Password";
                        param.Value = user.Password;
                        command.Parameters.Add(param);
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                               id = Convert.ToInt32(reader.GetString("id"));
                            }
                        }
                    }
                    if (id > 0)
                        user.Id = id;
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
