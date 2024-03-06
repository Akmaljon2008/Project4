namespace Infrastracture;
using Dapper;
using Npgsql;
public class DapperContext
{
    private readonly string _connectionString = 
        "Host=localhos;Port=5432;Database=librarydb;User id=postgres;Password=akmaljon2008";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}