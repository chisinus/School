using System.Data.SqlClient;

namespace Toolbox
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public static class Toolbox
    {
        public static SqlConnection OpenConnection()
        {
            string connectionString;
            try
            {
                connectionString = @"Data Source=Tiger\\Dev2012;initial catalog=Books;integrated security=True;";
            }
            catch
            {
                return null;
            }

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (SqlException)
            {
                connection = null;
            }

            return connection;
        }
    }
}
