namespace NMHDotNetCore.ConsoleApplication.ConnectionStrings;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class ConnectionString
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".\\SQL2022E",
        InitialCatalog = "Blog",
        UserID = "sa",
        Password = "p@ssw0rd",
        TrustServerCertificate = true
    };
}
