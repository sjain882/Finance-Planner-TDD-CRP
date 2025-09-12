using System.Data;
using System.Data.Common;
using FinancePlanner.Shared.Common.Utilities.Result;
using FinancePlanner.Wage.Queries.Domain.Contracts.Response;
using Npgsql;

namespace FinancePlanner.Wage.Queries.Repository;

public class WageRepository : IWageRepository
{
    public const string connectionString =
        "User ID=root;Password=root;Host=postgres-master;Port=5432;DatabaseQuery=root;";

    private readonly IDatabaseQuery _databaseQuery;

    public WageRepository(IDatabaseQuery databaseQuery)
    {
        _databaseQuery = databaseQuery;
    }

    public async Task<ResultT<List<DayWageResponse>>> GetAllWages()
    {
        var query = """
                    SELECT datepaid, userid, value
                    FROM Wage
                    """;

        var x = await _databaseQuery.GetTable(query);

        var wages = new List<DayWageResponse>();

        foreach (DataRow row in x.Rows)
            wages.Add(new DayWageResponse
            {
                DatePaid = row.Field<DateTime>("datepaid"),
                UserID = row.Field<int>("userid"),
                Value = row.Field<decimal>("value")
            });

        return wages;
    }

    public async Task<ResultT<List<DayWageResponse>>> GetAllWages(int userid)
    {
        var query = """
                    SELECT datepaid, userid, value
                    FROM Wage
                    WHERE  userid = @userid
                    """;
        var parameters = new List<DbParameter>
        {
            new NpgsqlParameter("@userid", userid)
        };

        var x = await _databaseQuery.GetTable(query, parameters);

        var wages = new List<DayWageResponse>();

        foreach (DataRow row in x.Rows)
            wages.Add(new DayWageResponse
            {
                DatePaid = row.Field<DateTime>("datepaid"),
                UserID = row.Field<int>("userid"),
                Value = row.Field<decimal>("value")
            });

        return wages;
    }

    public async Task<ResultT<List<DayWageResponse>>> GetEmployeeWage(int userid)
    {
        var query = """
                    SELECT datepaid, userid, value
                    FROM Wage
                    WHERE userid = @userid
                    """;

        var parameters = new List<DbParameter>
        {
            new NpgsqlParameter("@userid", userid)
        };

        var x = await _databaseQuery.GetTable(query, parameters);

        var wages = new List<DayWageResponse>();

        foreach (DataRow row in x.Rows)
            wages.Add(new DayWageResponse
            {
                DatePaid = row.Field<DateTime>("datepaid"),
                UserID = row.Field<int>("userid"),
                Value = row.Field<decimal>("value")
            });

        return wages;
    }
}