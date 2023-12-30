namespace Routine.Domain.Model.Company;

public class CompanyDto
{
    public Guid Id { get; init; }
    public string? Name { get; set; }
    public string? Introduction { get; set; }
}
