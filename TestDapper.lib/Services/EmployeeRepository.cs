using Dapper;

namespace TestDapper.lib
{
    public class EmployeeRepository : BaseRepository
    {
        public async Task<IList<Employee>> GetTop3Employeees()
        {
            using var con = CreateConnection();
            var sql =
                """
                SELECT TOP(10)
                    EmployeeId, EmployeeName, StartDate, EndDate
                FROM Falcon.hr.Employees
                WHERE EmployeeId > 0 AND EndDate IS NULL 
                ORDER BY EmployeeName
                """;
            var cmd = CreateCommand(sql);
            var result = await con.QueryAsync<Employee>(cmd);
            return result.ToList();
        }
    }
}
