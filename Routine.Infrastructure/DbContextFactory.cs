using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Routine.Infrastructure;

public class DbContextFactory : IDesignTimeDbContextFactory<RoutineDbContext>
{
    public RoutineDbContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<RoutineDbContext> optionsBuilder = new();
        //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DDDProject;Integrated Security=True;Trust Server Certificate=True");
        return new RoutineDbContext(optionsBuilder.Options);
    }
}
