using Dapper;
using sferretAPI.Models;
using sferretAPI.Services.IServices;
using System.Data;
using System.Data.SqlClient;



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
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getUserSql = "SELECT * FROM [User] WHERE Id = @Id";
                    var users = await con.QueryAsync<User>(getUserSql, new { Id = id });
                    if (users != null && users.Any())
                        user = users.FirstOrDefault();
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
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getUserSql = "SELECT * FROM [User] WHERE FullName = @Name";
                    var users = await con.QueryAsync<User>(getUserSql, new { Name = name });
                    if (users != null && users.Any())
                        user = users.FirstOrDefault();
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
                User A = null;
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string getUserSql = "SELECT * FROM [User] WHERE FullName = @Id";
                    var users = await con.QueryAsync<User>(getUserSql, new { Id = user.FullName });
                    if (users != null && users.Any())
                        A = users.FirstOrDefault();
                    if (A != null && A.Password == user.Password)
                        return A.Id;
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
                using (IDbConnection con = new SqlConnection(_connectionstring))
                {
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    string addUserSql = @"INSERT INTO [User] (FullName, Password)
                    OUTPUT INSERTED.[Id]
                    VALUES(@FullName, @Password)";
                    int id = await con.QuerySingleAsync<int>(addUserSql, new { FullName = user.FullName, Password = user.Password });
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
