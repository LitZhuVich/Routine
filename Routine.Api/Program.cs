using Microsoft.EntityFrameworkCore;
using Routine.Domain.IRepository;
using Routine.Infrastructure;
using Routine.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RoutineDbContext>(o =>
{
    o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Unexpected Error!");
        });
    });
}
// ×Ô¶¯Ö´ÐÐÇ¨ÒÆ
//using (var scope = app.Services.CreateScope())
//{
//    try
//    {
//        var dbContext = scope.ServiceProvider.GetService<RoutineDbContext>();

//        dbContext?.Database.EnsureCreated();
//        dbContext?.Database.Migrate();
//    }
//    catch (Exception e)
//    {
//        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
//        logger.LogError(e, "An error occurred while migrating the database.");
//    }
//}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
