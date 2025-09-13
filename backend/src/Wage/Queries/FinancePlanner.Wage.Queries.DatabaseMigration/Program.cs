using Microsoft.Extensions.Configuration;

namespace FinancePlanner.Wage.Queries.DatabaseMigration;

public class Program
{
    public static int Main(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddUserSecrets<SecretKey>()
            .Build();

        var connectionString =
            args.FirstOrDefault()
            ?? config["Database:Wage"]
            ?? "ERROR CONNECTION STRING NOT FOUND";
        
        if (connectionString is null)
        {
            throw new NullReferenceException("Database connection string is null");
        }
        Migration.CheckMigration(connectionString);

        return 0;
    }
}