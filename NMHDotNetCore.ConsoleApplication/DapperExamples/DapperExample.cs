namespace NMHDotNetCore.ConsoleApplication.DapperExamples;


using Dapper;
using System.Data;
using System.Data.SqlClient;
using NMHDotNetCore.ConsoleApplication.BlogModels;
using NMHDotNetCore.ConsoleApplication.ConnectionStrings;

public class DapperExample
{
    public void Run()
    {
        //Read();
        //Edit(4);
        //Create("BlackShield", "NMH", "Let's drink");
        Delete(1006);
    }

    #region DAPPER_READ
    private void Read()
    {
        using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        List<BlogModel> Lst = db.Query<BlogModel>("SELECT * FROM Blog").ToList();

        foreach(BlogModel item in Lst)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
            Console.WriteLine("--------------------");
        }
    }
    #endregion

    #region DAPPER_EDIT
    private void Edit(int Id)
    {
        using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        var item = db.Query<BlogModel>("SELECT * FROM Blog WHERE Id = @Id", new BlogModel { Id = Id }).FirstOrDefault();
        
        if(item is null)
        {
            Console.WriteLine("No data found.");
            return;
        }
        Console.WriteLine(item.Id);
        Console.WriteLine(item.BlogTitle);
        Console.WriteLine(item.BlogAuthor);
        Console.WriteLine(item.BlogContent);
    }
    #endregion

    #region DAPPER_CREATE
    private void Create(string Title, string Author, string Content)
    {
        var item = new BlogModel()
        {
            BlogTitle = Title,
            BlogAuthor = Author,
            BlogContent = Content
        };

        string query = @"INSERT INTO Blog(BlogTitle, BlogAuthor, BlogContent) VALUES (@BlogTitle, @BlogAuthor, @BlogContent)";
        using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Create Successfully" : "Fail to create";
        Console.WriteLine(message);
    }
    #endregion

    #region DAPPER_DELETE
    private void Delete(int Id)
    {
        var item = new BlogModel()
        {
            Id = Id
        };

        string query = @"DELETE FROM Blog WHERE Id = @Id";
        using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(query, item);

        string message = result > 0 ? "Delete Successfully" : "Fail to delete";
        Console.WriteLine(message);
    }
    #endregion
}
