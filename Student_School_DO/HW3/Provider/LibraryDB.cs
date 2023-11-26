using Microsoft.Data.SqlClient;
using System.ComponentModel;
using System.Text;

namespace Provider
{
    public class LibraryDB
    {
        private const string ConnectionString =
            @"Server=DESKTOP-OGU2J56;Database=LibraryDB;Trusted_Connection=True;Encrypt=False;";

        public string GetQuery(string query, int countFields)
        {
            try
            {
                using var sqlConnection = new SqlConnection(ConnectionString);

                var sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                using var sqlDataReader = sqlCommand.ExecuteReader();

                StringBuilder sb = new StringBuilder();

                while (sqlDataReader.Read())
                {
                    for (int i = 0; i < countFields; i++)
                    {
                        sb.Append(sqlDataReader.GetValue(i).ToString());
                        sb.Append(" ");
                    }
                    sb.Append("\n");
                }

                sqlConnection.Close();

                return sb.ToString();
            }
            catch
            {
                throw;
            }
        }

        private void Query(string query, params string[] fields)
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
            catch
            {
                throw ;
            }
        }

        public void UpdateQuery(string query, params string[] fields)
        {
            Query(query, fields);
        }

        public void AddQuery(string query, params string[] fields)
        {
            Query(query, fields);
        }

        public void DeleteQuery(string query, params string[] fields)
        {
            Query(query, fields);
        }

        public string GetConnection()
        {
            return ConnectionString;
        }
    }
}