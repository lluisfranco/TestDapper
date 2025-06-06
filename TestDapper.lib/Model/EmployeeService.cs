namespace TestDapper.lib
{
    public class EmployeeService
    {
        public EmployeeService SetRepository(string reponame)
        {
            //
            return this;
        }

        public EmployeeService InitializeRepository(int timeout)
        {
            //
            return this;
        }

        public EmployeeService SetOptions(string options)
        {
            //
            return this;
        }

        public IList<Employee> GetEmployees(int top = 10)
        {
            return new List<Employee>();
        }
    }
}
