using Routine.Domain.Model.Employee;

namespace Routine.Domain.Model.Company;

public class CompanyCreateDto
{
    public string? Name { get; set; }
    public string? Introduction { get; set; }
    public ICollection<EmployeeCreateDto> Employees { get; set; } = new List<EmployeeCreateDto>();
}
