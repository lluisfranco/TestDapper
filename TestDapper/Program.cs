using TestDapper.lib;

namespace TestDapper
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var empRepo = new EmployeeRepository()
            {
                ConnectionString =
                    """
                    Data Source=LOKI;
                    Initial Catalog=Falcon;
                    Integrated Security=True;
                    TrustServerCertificate=True
                    """
            };
            var result = await empRepo.GetTop3Employeees();
            foreach (var item in result)
            {
                Console.WriteLine($"Employee: {item.EmployeeName} ({item.EmployeeId})");
            }
        }
    }
}
