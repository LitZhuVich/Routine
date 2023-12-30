using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Routine.Domain.Entities;
using System.Reflection.Emit;

namespace Routine.Infrastructure.Configs;

public class EmployeeConfig : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.HasOne(x => x.Company)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
        // 初始数据
        builder.HasData(
               new Employee
               {
                   Id = Guid.Parse("4b501cb3-d168-4cc0-b375-48fb33f318a4"),
                   CompanyId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                   DateOfBirth = new DateTime(1976, 1, 2),
                   EmployeeNo = "MSFT231",
                   FirstName = "Nick",
                   LastName = "Carter",
                   Gender = Gender.male
               },
               new Employee
               {
                   Id = Guid.Parse("7eaa532c-1be5-472c-a738-94fd26e5fad6"),
                   CompanyId = Guid.Parse("bbdee09c-089b-4d30-bece-44df5923716c"),
                   DateOfBirth = new DateTime(1981, 12, 5),
                   EmployeeNo = "MSFT245",
                   FirstName = "Vince",
                   LastName = "Carter",
                   Gender = Gender.male
               },
               new Employee
               {
                   Id = Guid.Parse("72457e73-ea34-4e02-b575-8d384e82a481"),
                   CompanyId = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                   DateOfBirth = new DateTime(1986, 11, 4),
                   EmployeeNo = "G003",
                   FirstName = "Mary",
                   LastName = "King",
                   Gender = Gender.female
               },
               new Employee
               {
                   Id = Guid.Parse("7644b71d-d74e-43e2-ac32-8cbadd7b1c3a"),
                   CompanyId = Guid.Parse("6fb600c1-9011-4fd7-9234-881379716440"),
                   DateOfBirth = new DateTime(1977, 4, 6),
                   EmployeeNo = "G097",
                   FirstName = "Kevin",
                   LastName = "Richardson",
                   Gender = Gender.male
               },
               new Employee
               {
                   Id = Guid.Parse("679dfd33-32e4-4393-b061-f7abb8956f53"),
                   CompanyId = Guid.Parse("5efc910b-2f45-43df-afae-620d40542853"),
                   DateOfBirth = new DateTime(1967, 1, 24),
                   EmployeeNo = "A009",
                   FirstName = "卡",
                   LastName = "里",
                   Gender = Gender.female
               },
               new Employee
               {
                   Id = Guid.Parse("1861341e-b42b-410c-ae21-cf11f36fc574"),
                   CompanyId = Guid.Parse("5efc910b-2f45-43df-afae-620d40542853"),
                   DateOfBirth = new DateTime(1957, 3, 8),
                   EmployeeNo = "A404",
                   FirstName = "Not",
                   LastName = "Man",
                   Gender = Gender.male
               });
    }
}
