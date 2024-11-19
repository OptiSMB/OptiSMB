using Microsoft.Data.Sqlite;
using System.Data;

namespace BusinessSoftware.DAL
{
    public static class SQLiteHelper
    {
        public static IDbConnection GetConnection(string databaseName = "")
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            var _dbPath = GetProjectRoot(currentDirectory)+".DAL\\data\\";
            if (string.IsNullOrWhiteSpace(_dbPath))
                throw new InvalidOperationException("Database not initialized. Call Initialize() first.");

            if (string.IsNullOrWhiteSpace(databaseName))
                throw new InvalidOperationException("Database name is invalid.");

            return new SqliteConnection($"Data Source={_dbPath+ databaseName};");
        }

        static string GetProjectRoot(string currentDirectory)
        {
            // Go up until we find the directory containing the .csproj file
            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null && !File.Exists(Path.Combine(directoryInfo.FullName, $"{directoryInfo.Name}.csproj")))
            {
                directoryInfo = directoryInfo.Parent;
            }

            // Return the root directory (where the .csproj file is found)
            return directoryInfo?.FullName;
        }
    }
}
