namespace Demo.API.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public Gender Gender { get; set; } = default!;
        public string Department { get; set; } = default!;
        public decimal Salary { get; set; } = default!;
    }
}
