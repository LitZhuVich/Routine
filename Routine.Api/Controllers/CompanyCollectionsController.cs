using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Routine.Domain.Entities;
using Routine.Domain.Helpers;
using Routine.Domain.IRepository;
using Routine.Domain.Model.Company;

namespace Routine.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CompanyCollectionsController(ICompanyRepository _repository, IMapper _mapper) : ControllerBase
{
    [HttpGet("({ids})",Name = nameof(GetCompanyCollections))]
    public async Task<ActionResult<List<CompanyDto>>> GetCompanyCollections(
        [FromRoute]
        [ModelBinder(BinderType = typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids)
    {
        if (ids == null)
        {
            return BadRequest();
        }

        var entities = await _repository.GetCompaniesAsync(ids);
        if (ids.Count() != entities.Count())
        {
            return NotFound();
        }

        var dto = _mapper.Map<List<CompanyDto>>(entities);
        return dto;
    }

    [HttpPost]
    public async Task<ActionResult<List<CompanyDto>>> CreateCompanyCollection(List<CompanyCreateDto> companyCollection)
    {
        var entities = _mapper.Map<List<Company>>(companyCollection);
        foreach (var company in entities)
        {
            await _repository.CreateCompanyAsync(company);
        }
        await _repository.SaveAsync();

        var dto = _mapper.Map<List<CompanyDto>>(entities);
        var ids = string.Join(",", entities.Select(e => e.Id));
        return CreatedAtRoute(nameof(GetCompanyCollections), new
        {
            ids
        },dto);
    }
}
