using AutoMapper;
using Routine.Domain.Entities;
using Routine.Domain.Model.Company;

namespace Routine.Infrastructure.Profiles;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyDto>();
        CreateMap<CompanyCreateDto, Company>();
    }
}
