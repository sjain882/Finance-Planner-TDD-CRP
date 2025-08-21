using System.Data.Common;

namespace FinancePlanner.Commands.Wage.Repository;

public interface IDatabaseQuery
{
    public Task UpdateTable(string query, List<DbParameter> parameters = null);
}