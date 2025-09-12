using System.Data;
using System.Data.Common;

namespace FinancePlanner.Wage.Commands.Repository;

public interface IDatabaseQuery
{
    public Task UpdateTable(string query, List<DbParameter> parameters = null);
    public Task<DataTable> GetTable(string query, List<DbParameter>? parameters = null);
}