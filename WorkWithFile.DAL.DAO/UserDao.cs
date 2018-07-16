using Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkWithFile.DAL.DAO
{
    public class UserDao : IUserDao
    {
        private readonly string _connectionString;

        public UserDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Files"].ConnectionString;
        }

        public int CreateUser(string name, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "CreateUser";

                var nameParam = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                var passwordParam = new SqlParameter("@PASSWORD", System.Data.SqlDbType.VarChar)
                {
                    Value = password
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, passwordParam });

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public int CreateUserByAdmin(string name, string password, int role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "CreateUserByAdmin";

                var nameParam = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                var passwordParam = new SqlParameter("@PASSWORD", System.Data.SqlDbType.VarChar)
                {
                    Value = password
                };

                var roleParam = new SqlParameter("@ROLE", System.Data.SqlDbType.Int)
                {
                    Value = role
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, passwordParam, roleParam });

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public IEnumerable<User> ReadUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ReadUser";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            Id = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Password = (string)reader["Password"],
                            Role = (int)reader["Role"],
                        };
                    }
                }
            }
        }

        public User GetUserById(int id)
        {
            return ReadUsers().FirstOrDefault(user => user.Id == id);
        }

        public int DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "DeleteUser";

                var idParam = new SqlParameter("@PASSWORD", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public int UpdateUser(int id, string name, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateUser";

                var nameParam = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                var passwordParam = new SqlParameter("@PASSWORD", System.Data.SqlDbType.VarChar)
                {
                    Value = password
                };

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, passwordParam, idParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public int UpdateUserById(int id, int role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateUserByAdmin";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var roleParam = new SqlParameter("@ROLE", System.Data.SqlDbType.Int)
                {
                    Value = role
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam, roleParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }
    }
}
