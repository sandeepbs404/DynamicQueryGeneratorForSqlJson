using DbUp;
using System;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace SqlJsonEXplorer
{
    class Program
    {
        static void Main(string[] args)
        {

            SetupDb(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString, true);

            var queryGenerator = new QueryGenerator();

            var schemaProvider = new SchemaProvider();
            var allschemas = schemaProvider.GetSchemas();


            var result = queryGenerator.GetQueryForTable(allschemas[0]);

            var test = schemaProvider.ExecuteQuery(result);

        }

        private static void SetupDb(object connectionString)
        {
            throw new NotImplementedException();
        }

        private static void SetupDb(string connectionString, bool createDatabase = false)
        {

            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Scripts");
            if (createDatabase)
                EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader =
                DeployChanges.To
            .SqlDatabase(connectionString)
            .WithScriptsFromFileSystem(path)
            .LogToConsole()
            .Build();
            var resultDeployment = upgrader.PerformUpgrade();
            if (!resultDeployment.Successful)
            {
                Console.WriteLine(resultDeployment.Error.Message);
            }
        }
    }
}
