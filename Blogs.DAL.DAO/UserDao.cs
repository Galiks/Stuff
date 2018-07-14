using Blog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogs.DAL.DAO
{
    public class UserDao : IUserDao
    {
        private readonly string _connectionString;

        public UserDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["blogs"].ConnectionString;
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

                command.Parameters.AddRange(new SqlParameter[] { nameParam, passwordParam});

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public int CreateUserbyAdmin(string name, string password, int role)
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

        public int DeleteUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "DeleteUser";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public User GetUserById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetUserById";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(idParam);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return new User
                        {
                            UserId = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Role = (int)reader["Role"],
                        };
                    }
                }
            }

            return null;
        }

        public IEnumerable<User> ReadUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ReadUsers";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            UserId = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Role = (int)reader["Role"],
                        };
                    }
                }
            }
        }

        public IEnumerable<User> ReadUsersByAdmin()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ReadUsersByAdmin";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new User
                        {
                            UserId = (int)reader["id_user"],
                            Name = (string)reader["Name"],
                            Password = (string)reader["Password"],
                            Role = (int)reader["Role"],
                        };
                    }
                }
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

        public int UpdateUserByAdmin(int id, string name, string password, int role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateUserByAdmin";

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

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, passwordParam, roleParam, idParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }
    }
}
