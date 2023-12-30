using Routine.Domain.Entities;

namespace Routine.Domain.Model.Employee;

public class EmployeeCreateDto
{
    public string? EmployeeNo { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
}
