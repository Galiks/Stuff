using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;

namespace Blogs.DAL.DAO
{
    public class BlogDao : IBlogDao
    {
        private readonly string _connectionString;

        public BlogDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["blogs"].ConnectionString;
        }

        public int CreateBlog(int id, string name, string text)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "CreateBlog";

                var nameParam = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                var ratingParam = new SqlParameter("@RATING", System.Data.SqlDbType.Int)
                {
                    Value = 0
                };

                var textParam = new SqlParameter("@TEXT", System.Data.SqlDbType.VarChar)
                {
                    Value = text
                };

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, ratingParam, textParam, userId });

                connection.Open();

                //return (int)(decimal)command.ExecuteScalar();

                return (int)(decimal)command.ExecuteNonQuery();
            
            }
        }

        public int DeleteBlog(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "DeleteBlog";

                var idParam = new SqlParameter("@NAME", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam});

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public Blog.Models.Blog GetBlogById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetBlogById";

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
                        return new Blog.Models.Blog
                        {
                            BlogId = (int)reader["id_blog"],
                            Name = (string)reader["Name"],
                            Rating = (int)reader["Rating"],
                            Text = (string)reader["Text"],
                        };
                    }
                }
            }

            return null;
        }

        public IEnumerable<Blog.Models.Blog> GetBlogsByUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "GetBlogsByUser";

                var userId = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(userId);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Blog.Models.Blog
                        {
                            BlogId = (int)reader["id"],
                            Name = (string)reader["name"],
                            Rating = (int)reader["rating"],
                            Text = (string)reader["text"],
                        };
                    }
                }
            }
        }

        public IEnumerable<Blog.Models.Blog> ReadBlogs()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ReadBlogs";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Blog.Models.Blog
                        {
                            BlogId = (int)reader["id_blog"],
                            Name = (string)reader["Name"],
                            Rating = (int)reader["Rating"],
                            Text = (string)reader["Text"],
                        };
                    }
                }
            }
        }

        public int UpdateBlog(int id, int rating)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateBlog";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var ratingParam = new SqlParameter("@RATING", System.Data.SqlDbType.Int)
                {
                    Value = 0
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam, ratingParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public int UpdateBlogByAdmin(int id, string name, string text, int rating)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateBlogByAdmin";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var nameParam = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                var ratingParam = new SqlParameter("@RATING", System.Data.SqlDbType.Int)
                {
                    Value = rating
                };

                var textParam = new SqlParameter("@TEXT", System.Data.SqlDbType.VarChar)
                {
                    Value = text
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, ratingParam, textParam, idParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }
    }
}
