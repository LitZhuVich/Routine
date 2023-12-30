using Microsoft.EntityFrameworkCore;
using Routine.Domain.Entities;
using Routine.Domain.IRepository;

namespace Routine.Infrastructure.Repository;

public class EmployeeRepository(RoutineDbContext db) : IEmployeeRepository
{
    public async Task CreateEmployeeAsync(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        await db.Employees.AddAsync(employee);
    }

    public Task DeleteEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public async Task<Employee?> FindEmployeeAsync(Guid companyId, Guid employeeId)
    {
        return await db.Employees
            .SingleOrDefaultAsync(x => x.CompanyId == companyId && x.Id == employeeId);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, string? genderDisplay, string? q)
    {
        if (string.IsNullOrWhiteSpace(genderDisplay) && string.IsNullOrWhiteSpace(q))
        {
            return await db.Employees
                .Where(x => x.CompanyId == companyId)
                .OrderBy(x => x.EmployeeNo)
                .ToListAsync();
        }

        var items = db.Employees.Where(x => x.CompanyId == companyId);

        if (!string.IsNullOrWhiteSpace(genderDisplay))
        {
            var gender = Enum.Parse<Gender>(genderDisplay);

            items = items.Where(x => x.Gender == gender);
        }

        if (!string.IsNullOrWhiteSpace(q))
        {
            items = items.Where(x => x.FirstName!.Contains(q) || x.LastName!.Contains(q) || x.EmployeeNo!.Contains(q));
        }

        return await items
               .OrderBy(x => x.EmployeeNo)
               .ToListAsync();
    }

    public async Task<bool> SaveAsync()
    {
        return await db.SaveChangesAsync() >= 0;
    }

    public Task UpdateEmployeeAsync(Employee employee)
    {
        db.Employees.Update(employee);
        return Task.CompletedTask;
    }
}
