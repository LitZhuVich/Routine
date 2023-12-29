using Microsoft.EntityFrameworkCore;
using Routine.Domain.Entities;
using Routine.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

    public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId)
    {
        return await db.Employees
            .Where(x => x.CompanyId == companyId)
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
