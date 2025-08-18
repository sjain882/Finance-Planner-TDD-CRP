using System.Reflection;
using DbUp;

namespace FinancePlanner.Commands.Wage.DatabaseMigration;

public class Program
{
    public static int Main(string[] args)
    {
        var connectionString = "User ID=root;Password=root;Host=postgres-master;Port=5432;Database=root;";

        Migration.CheckMigration(connectionString);

        return 0;
    }
    
}