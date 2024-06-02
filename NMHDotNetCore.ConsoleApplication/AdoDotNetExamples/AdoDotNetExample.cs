namespace NMHDotNetCore.ConsoleApplication.AdoDotNetExamples
{
    using System;    
    using System.Data;
    using System.Data.SqlClient;

    public class AdoDotNetExample
    {
        #region Create Database Connection String 
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".\\SQL2019E",
            InitialCatalog = "Blog",
            UserID = "sa",
            Password = "p@ssw0rd"
        };
        #endregion

        #region READ
        public void Read()
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            Console.WriteLine("Connection is open...");

            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "SELECT * FROM Blog (NOLOCK)",
                Connection = sqlConnection,
                CommandTimeout = 7200             
            };

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            adapter.Fill(DS);

            sqlConnection.Close();
            Console.WriteLine("Connection is close...");

            if(DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in DS.Tables[0].Rows)
                {
                    Console.WriteLine(row["Id"]);
                    Console.WriteLine(row["BlogTitle"]);
                    Console.WriteLine(row["BlogAuthor"]);
                    Console.WriteLine(row["BlogContent"]);
                }
            }
            else
            {
                Console.Write("No data found.");
            }
        }
        #endregion

        #region CREATE
        public void Create(string Title, string Author, string Content)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            Console.WriteLine("Connection is open...");

            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "INSERT INTO Blog(BlogTitle, BlogAuthor, BlogContent) VALUES (@Title, @Author, @Content)",
                Connection = sqlConnection
            };
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Author", Author);
            cmd.Parameters.AddWithValue("@Content", Content);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();
            Console.WriteLine("Connection is close...");

            String message = result > 0 ? "Create Successfully." : "Fail to create.";
            Console.WriteLine(message);
        }
        #endregion

        #region UPDATE
        public void Update(int Id, string Title, string Author, string Content)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();
            Console.WriteLine("Connection is open...");

            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "UPDATE Blog SET BlogTitle=@Title, BlogAuthor=@Author, BlogContent=@Content WHERE Id = @Id",
                Connection = sqlConnection
            };
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Title", Title);
            cmd.Parameters.AddWithValue("@Author", Author);
            cmd.Parameters.AddWithValue("@Content", Content);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();
            Console.WriteLine("Connection is close...");

            String message = result > 0 ? "Update Successfully." : "Fail to update.";
            Console.WriteLine(message);
        }
        #endregion

        #region DELETE
        public void Delete(int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "DELETE FROM Blog WHERE Id = @Id",
                Connection = sqlConnection
            };
            cmd.Parameters.AddWithValue("@Id", Id);
            int result = cmd.ExecuteNonQuery();

            sqlConnection.Close();

            String message = result > 0 ? "Delete Successfully." : "Fail to delete.";
            Console.WriteLine(message);
        }
        #endregion

        #region EDIT
        public void Edit(int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand()
            {
                CommandText = "SELECT * FROM Blog (NOLOCK) WHERE Id = @Id",
                Connection = sqlConnection,
                CommandTimeout = 7200
            };
            cmd.Parameters.AddWithValue("@Id", Id);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            sqlConnection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found.");
                return;
            }

            DataRow row = dt.Rows[0];
            Console.WriteLine(row["Id"]);
            Console.WriteLine(row["BlogTitle"]);
            Console.WriteLine(row["BlogAuthor"]);
            Console.WriteLine(row["BlogContent"]);

        }
        #endregion
    }
}
