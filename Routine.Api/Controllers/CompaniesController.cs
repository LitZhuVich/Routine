using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Routine.Domain.Entities;
using Routine.Domain.IRepository;
using Routine.Domain.DtoParameters;
using Routine.Domain.Model.Company;

namespace Routine.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompaniesController(ICompanyRepository _repository,IMapper _mapper) : ControllerBase
{
    [HttpGet, HttpHead]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanies([FromQuery] CompanyDtoParameters? parameters)
    {
        var companies = await _repository.GetCompaniesAsync(parameters);
        var companiesDto = _mapper.Map<List<CompanyDto>>(companies);
        return companiesDto;
    }

    [HttpGet("{companyId}",Name = nameof(GetCompany))]
    public async Task<ActionResult<CompanyDto>> GetCompany(Guid companyId)
    {
        var company = await _repository.FindCompanyAsync(companyId);
        if (company == null)
        {
            return NotFound();
        }
        var companyDto = _mapper.Map<CompanyDto>(company);
        return companyDto;
    }

    [HttpPost]
    public async Task<ActionResult<CompanyDto>> CreateCompany(CompanyCreateDto company)
    {
        var entity = _mapper.Map<Company>(company);
        await _repository.CreateCompanyAsync(entity);
        await _repository.SaveAsync();

        var dto = _mapper.Map<CompanyDto>(entity);
        return CreatedAtRoute(nameof(GetCompany), new
        {
            companyId = dto.Id
        },dto);
    }

   
}