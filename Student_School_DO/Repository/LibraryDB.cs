using Microsoft.Data.SqlClient;

namespace Provider
{
    public class LibraryDB
    {
        private const string ConnectionString =
            @"Server=laptop-burou19s;Database=LibraryDB;Trusted_Connection=True;Encrypt=False;";

        public string GetQuery(string query, params string[] fields)
        {
            string result = "";

            try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);

                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                using var sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    foreach (var field in fields)
                    {
                        result += sqlDataReader[field];

                        result += " ";
                    }
                    result += "\n";
                }

                sqlConnection.Close();

                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private void Query(string query, params string?[] fields)
        {
            try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);

                var commandFormat = string.Format(query, fields);

                var sqlCommand = new SqlCommand(commandFormat, sqlConnection);

                sqlConnection.Open();

                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
            catch (SqlException sqlExc)
            {
                throw sqlExc;
            }
        }

        public void UpdateQuery(string query, params string?[] fields)
        {
            Query(query, fields);
        }

        public void AddQuery(string query, params string?[] fields)
        {
            Query(query, fields);
        }

        public void DeleteQuery(string query, params string?[] fields)
        {
            Query(query, fields);
        }

        public string GetConnection()
        {
            return ConnectionString;
        }
    }
}