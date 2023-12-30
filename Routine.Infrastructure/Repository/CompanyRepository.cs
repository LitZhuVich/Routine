using Microsoft.EntityFrameworkCore;
using Routine.Domain.DtoParameters;
using Routine.Domain.Entities;
using Routine.Domain.IRepository;

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

    public async Task<IEnumerable<Company>> GetCompaniesAsync(CompanyDtoParameters? parameters)
    {
        if (parameters == null)
        {
            throw new ArgumentException(nameof(parameters));
        }
        if (string.IsNullOrWhiteSpace(parameters.CompanyName) && 
            string.IsNullOrWhiteSpace(parameters.SearchTerm))
        {
            return await db.Companies.ToListAsync();
        }

        var queryExpression = db.Companies as IQueryable<Company>;

        if (!string.IsNullOrWhiteSpace(parameters.CompanyName))
        {
            queryExpression = queryExpression.Where(x => x.Name == parameters.CompanyName); 
        }

        if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
        {
            queryExpression = queryExpression.Where(x => x.Name.Contains(parameters.SearchTerm) ||
                                                    x.Introduction.Contains(parameters.SearchTerm));
        }

        return await queryExpression.ToListAsync();
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
