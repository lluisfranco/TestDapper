using TestDapper.lib;

namespace TestDapper
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var smeService = new EmployeeService();
            smeService
                .SetRepository("EmployeeRepository")
                .InitializeRepository(30)
                .SetOptions("TrustServerCertificate=True")
                .GetEmployees(10);

            //smeService.SetRepository("EmployeeRepository");
            //smeService.InitializeRepository(30);
            //smeService.SetOptions("TrustServerCertificate=True");
            //var emps = smeService.GetEmployees(10);


            //var empRepo = new EmployeeRepository()
            //{
            //    ConnectionString =
            //        """
            //        Data Source=LOKI;
            //        Initial Catalog=Falcon;
            //        Integrated Security=True;
            //        TrustServerCertificate=True
            //        """
            //};
            //var result = await empRepo.GetEmployeees();

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Employee: {item.EmployeeName} ({item.EmployeeId})");
            //}

            //var fruitnames = new List<string> { "Apple", "Banana", "Cherry", "Pear" };

            //var notred = fruitnames
            //    .Where(p => p != "Cherry")
            //    .OrderByDescending(p => p)
            //    .Skip(1)
            //    .Take(2);

            //foreach (var item in notred)
            //{
            //    Console.WriteLine(item);
            //}

            //var names = result
            //    .Where(x => x.EndDate is null && x.IsEnabled)
            //    .OrderBy(x => x.EmployeeName)
            //    .Take(3)
            //    .ToList();

            //foreach (var item in names)
            //{
            //    Console.WriteLine($"Employee: {item.EmployeeName} ({item.EmployeeId})");
            //}


            Console.ReadLine();
        }
    }
}
