using System.Data;
using System.Data.Common;

namespace FinancePlanner.Wage.Queries.Repository;

public interface IDatabaseQuery
{
    public Task<DataTable> GetTable(string query, List<DbParameter>? parameters = null);
}