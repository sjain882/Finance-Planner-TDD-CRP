using System.Data;
using System.Data.Common;
using FinancePlanner.Queries.Wage.Domain.Contracts.Response;
using FinancePlanner.Shared.Common.Result;
using Npgsql;

namespace FinancePlanner.Queries.Wage.Repository;

public class WageRepository : IWageRepository
{
    private readonly IDatabaseQuery _databaseQuery;
    public const string connectionString = "User ID=root;Password=root;Host=postgres-master;Port=5432;DatabaseQuery=root;";
    
    public WageRepository(IDatabaseQuery databaseQuery)
    {
        _databaseQuery = databaseQuery;
    }
    
    public async Task<ResultT<List<WageResponse>>> GetAllWages()
    {
        var query = """
                    SELECT datepaid, userid, value
                    FROM Wage
                    """;
        
        var x = await _databaseQuery.GetTable(query);

        List<WageResponse> wages = new List<WageResponse>();
        
        foreach (DataRow row in x.Rows)
        {
            wages.Add(new WageResponse
            {
                DatePaid = row.Field<DateTime>("datepaid"),
                UserID   = row.Field<int>("userid"),
                Value    = row.Field<decimal>("value")
            });
        }

        return wages;
    }

    public async Task<ResultT<List<WageResponse>>> GetEmployeeWage(int userid)
    {
        var query = """
                    SELECT datepaid, userid, value
                    FROM Wage
                    WHERE userid = @userid
                    """;
        
        var parameters = new List<DbParameter>()
        {
            new NpgsqlParameter("@userid", userid),
        };
        
        var x = await _databaseQuery.GetTable(query, parameters);
        
        List<WageResponse> wages = new List<WageResponse>();
        
        foreach (DataRow row in x.Rows)
        {
            wages.Add(new WageResponse
            {
                DatePaid = row.Field<DateTime>("datepaid"),
                UserID   = row.Field<int>("userid"),
                Value    = row.Field<decimal>("value")
            });
        }

        return wages;
    }
}