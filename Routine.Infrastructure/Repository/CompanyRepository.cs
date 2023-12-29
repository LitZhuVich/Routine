using Microsoft.EntityFrameworkCore;
using Routine.Domain.Entities;
using Routine.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Routine.Infrastructure.Repository;

public class CompanyRepository(RoutineDbContext db) : ICompanyRepository
{
    public async Task<bool> CompanyExistsAsync(Guid companyId)
    {
        return await db.Companies.AnyAsync(x => x.Id == companyId);
    }

    public async Task CreateCompanyAsync(Company company)
    {
        if (company.Employees != null)
        {
            foreach (var employee in company.Employees)
            {
                employee.CompanyId = Guid.NewGuid();
            }
        }
        await db.Companies.AddAsync(company);
    }

    public Task DeleteCompanyAsync(Company company)
    {
        db.Companies.Remove(company);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Company>> GetCompaniesAsync()
    {
        return await db.Companies.ToListAsync();
    }

    public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds)
    {
        return await db.Companies
            .Where(x => companyIds.Contains(x.Id))
            .OrderBy(x => x.Name)
            .ToListAsync();
    }

    public async Task<Company?> FindCompanyAsync(Guid companyId)
    {
        var company = await db.Companies.SingleOrDefaultAsync(x => x.Id == companyId);
        return company;
    }

    public async Task<bool> SaveAsync()
    {
        return await db.SaveChangesAsync() >= 0;
    }

    public Task UpdateCompanyAsync(Company company)
    {
        db.Companies.Update(company);
        return Task.CompletedTask;
    }

}
