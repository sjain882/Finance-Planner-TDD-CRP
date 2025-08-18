using System.Reflection;
using DbUp;
using DbUp.Engine;

namespace FinancePlanner.Commands.Wage.DatabaseMigration;

public class Migration
{
    public static DatabaseUpgradeResult CheckMigration(string connectionString)
    {
        var upgrader =
            DeployChanges
                .To
                .PostgresqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .LogScriptOutput()
                .Build();

        return upgrader.PerformUpgrade();
    }
}