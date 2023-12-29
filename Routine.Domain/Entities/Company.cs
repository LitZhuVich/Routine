namespace Routine.Domain.Entities;

public class Company
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? Introduction { get; set; }
    public ICollection<Employee>? Employees { get; set; }
    public Company()
    {
        Id = Guid.NewGuid();
    }
}
