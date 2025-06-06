namespace TestDapper.lib
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? DisplayName { get; set; }
        public string? UserLogin { get; set; }
        public string? EMail { get; set; }
        public string? InternalPhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? HomePhone { get; set; }
        public string? TravelPhone { get; set; }
        public int? DepartmentId { get; set; }
        public string? JobDescription { get; set; }
        public int? ManagerId { get; set; }
        public byte[]? Picture { get; set; }
        public bool IsHistorical { get; set; }
        public bool IsEnabled { get; set; }
    }
}
