using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class EducationController : ControllerBase
{
    private readonly IEducationService _EducationService;
    private readonly IMapper _mapper;

    public EducationController(IEducationService EducationService, IMapper mapper)
    {
        _EducationService = EducationService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<EducationResource>> GetAllAsync()
    {
        var Educations = await _EducationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Education>, IEnumerable<EducationResource>>(Educations);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveEducationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var Education = _mapper.Map<SaveEducationResource, Education>(resource);

        var result = await _EducationService.SaveAsync(Education);

        if (!result.Success)
            return BadRequest(result.Message);

        var EducationResource = _mapper.Map<Education, EducationResource>(result.Resource);

        return Ok(Education);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEducationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var Education = _mapper.Map<SaveEducationResource, Education>(resource);

        var result = await _EducationService.UpdateAsync(id, Education);

        if (!result.Success)
            return BadRequest(result.Message);

        var EducationResource = _mapper.Map<Education, EducationResource>(result.Resource);

        return Ok(EducationResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _EducationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var EducationResource = _mapper.Map<Education, EducationResource>(result.Resource);
        return Ok(EducationResource);
    }
}
