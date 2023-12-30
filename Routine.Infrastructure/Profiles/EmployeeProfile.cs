using AutoMapper;
using Routine.Domain.Entities;
using Routine.Domain.Model.Employee;

namespace Routine.Infrastructure.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(d => d.Name, opt =>
            {
                opt.MapFrom(src => $"{src.FirstName} {src.LastName}");
            })
            .ForMember(d => d.GenderDisplay, opt =>
            {
                opt.MapFrom(src => src.Gender.ToString());
            })
            .ForMember(d => d.Age, opt =>
            {
                opt.MapFrom(src => DateTime.Now.Year - src.DateOfBirth.Year);
            });

        CreateMap<EmployeeCreateDto, Employee>();
    }
}
