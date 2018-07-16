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
    public class CommentDao : ICommentDao
    {
        private readonly string _connectionString;

        public CommentDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Files"].ConnectionString;
        }

        public int CreateComment(int id, string comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "CreateComment";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var commentParam = new SqlParameter("@COMMENT", System.Data.SqlDbType.VarChar)
                {
                    Value = comment
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam, commentParam });

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public IEnumerable<Comment> ReadCommentByFile(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ReadCommentByFile";

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
                        yield return new Comment
                        {
                            Id = (int)reader["id_comment"],
                            Commenting = (string)reader["Comment"],
                        };
                    }
                }
            }
        }
    }
}
