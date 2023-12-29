using Microsoft.EntityFrameworkCore;
using Routine.Domain.Entities;
using System.Reflection;

namespace Routine.Infrastructure;

public class RoutineDbContext : DbContext
{
    public DbSet<Company> Companies { get; set; }

    public DbSet<Employee> Employees { get; set; }

    public RoutineDbContext(DbContextOptions<RoutineDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=routine;Integrated Security=True;Trust Server Certificate=True");
    }
}
