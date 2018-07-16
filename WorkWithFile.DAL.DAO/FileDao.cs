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
    public class FileDao : IFileDao
    {
        private readonly string _connectionString;

        public FileDao()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["Files"].ConnectionString;
        }

        public int CreateFile(int id, string name, string text)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "CreateFile";

                var nameParam = new SqlParameter("@NAME", System.Data.SqlDbType.VarChar)
                {
                    Value = name
                };

                var textParam = new SqlParameter("@TEXT", System.Data.SqlDbType.VarChar)
                {
                    Value = text
                };

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var markParam = new SqlParameter("@MARK", System.Data.SqlDbType.Int)
                {
                    Value = 0
                };

                command.Parameters.AddRange(new SqlParameter[] { nameParam, textParam, idParam, markParam});

                connection.Open();

                return (int)(decimal)command.ExecuteScalar();
            }
        }

        public IEnumerable<Files> ReadFiles()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ReadFile";

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Files
                        {
                            ID = (int)reader["id_file"],
                            Name = (string)reader["Name"],
                            Mark = (int)reader["Mark"],
                            Text = (string)reader["Text"],
                        };
                    }
                }
            }
        }

        public IEnumerable<Files> ReadFilesByUser(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "ReadFileByUser";

                var idPram = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.Add(idPram);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Files
                        {
                            ID = (int)reader["id_file"],
                            Name = (string)reader["Name"],
                            Mark = (int)reader["Mark"],
                            Text = (string)reader["Text"],
                        };
                    }
                }
            }
        }

        public Files GetFileById(int id)
        {
            return ReadFiles().FirstOrDefault(files => files.ID == id);
        }

        public int UpdateText(int id, string text)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateFileText";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var textParam = new SqlParameter("@TEXT", System.Data.SqlDbType.VarChar)
                {
                    Value = text
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam, textParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public int UpdateMark(int id, int mark)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "UpdateFileMark";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                var markParam = new SqlParameter("@MARK", System.Data.SqlDbType.Int)
                {
                    Value = mark
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam, markParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }

        public int DeleteFile(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = "DeleteFile";

                var idParam = new SqlParameter("@ID", System.Data.SqlDbType.Int)
                {
                    Value = id
                };

                command.Parameters.AddRange(new SqlParameter[] { idParam });

                connection.Open();

                return (int)(decimal)command.ExecuteNonQuery();
            }
        }
    }
}
