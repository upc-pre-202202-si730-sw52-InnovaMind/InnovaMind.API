using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;
    
    public CompanyController(ICompanyService companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<CompanyResource>> GetAllAsync()
    {
        var companies = await _companyService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);
        return resources;
    }
    [HttpGet("id/{id}")]
    public async Task<IActionResult> GetById (int id)
    {
        var result = await _companyService.GetByIdAsync(id);
        var resource = _mapper.Map<Company, CompanyResource>(result);
        return Ok(resource); 
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCompanyResource resource)
    {
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var company = _mapper.Map<SaveCompanyResource, Company>(resource);
        var result = await _companyService.SaveAsync(company);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var companyResource = _mapper.Map<Company, SaveCompanyResource>(result.Resource);
        return Ok(companyResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        
        var company = _mapper.Map<SaveCompanyResource, Company>(resource);
        var result = await _companyService.UpdateAsync(id, company);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
        return Ok(companyResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _companyService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var companyResource = _mapper.Map<Company, CompanyResource>(result.Resource);
        return Ok(companyResource);
    }
}