using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Routine.Domain.Entities;
using Routine.Domain.IRepository;
using Routine.Domain.Model.Employee;

namespace Routine.Api.Controllers;

[Route("api/[controller]/{companyId}/employees")]
[ApiController]
public class EmployeesController(IEmployeeRepository _repository,IMapper _mapper) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<EmployeeDto>>> 
        GetEmployeesForCompany(Guid companyId, [FromQuery(Name = "gender")] string? genderDisplay, string? q)
    {
        var employees = await _repository.GetEmployeesAsync(companyId, genderDisplay, q);
        var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);
        return employeesDto;
    } 

    [HttpGet("{employId}",Name = nameof(GetEmployeeForCompany))]
    public async Task<ActionResult<EmployeeDto>> GetEmployeeForCompany(Guid companyId, Guid employId)
    {
        var employee = await _repository.FindEmployeeAsync(companyId, employId);
        if (employee == null)
        {
            return NotFound();
        }
        var employeesDto = _mapper.Map<EmployeeDto>(employee);
        return employeesDto;
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeDto>> CreateEmployeeForCompany(Guid companyId, EmployeeCreateDto employee)
    {
        var entity = _mapper.Map<Employee>(employee);
        await _repository.CreateEmployeeAsync(companyId, entity);
        await _repository.SaveAsync();
        var dto = _mapper.Map<EmployeeDto>(entity);
        return CreatedAtRoute(nameof(GetEmployeeForCompany), new
        {
            companyId,
            employId = dto.Id
        },dto);
    }
}
