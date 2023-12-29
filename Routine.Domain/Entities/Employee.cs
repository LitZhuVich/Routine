namespace Routine.Domain.Entities;

public class Employee
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public string? EmployeeNo { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Company? Company { get; set; }

    public Employee()
    {
        Id = Guid.NewGuid();
    }
}