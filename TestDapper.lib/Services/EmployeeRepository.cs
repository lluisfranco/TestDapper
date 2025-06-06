using Dapper;

namespace TestDapper.lib
{
    public class EmployeeRepository : BaseRepository
    {
        public async Task<IList<Employee>> GetEmployeees()
        {
            using var con = CreateConnection();
            var sql =
                """
                SELECT 
                    EmployeeId,
                    EmployeeName,
                    DisplayName,
                    UserLogin,
                    EMail,
                    InternalPhone,
                    MobilePhone,
                    HomePhone,
                    TravelPhone,
                    DepartmentId,
                    JobDescription,
                    StartDate,
                    EndDate,
                    ManagerId,
                    Picture,
                    IsHistorical,
                    IsEnabled
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
