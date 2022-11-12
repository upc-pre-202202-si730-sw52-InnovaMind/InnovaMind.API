using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class SchoolController : ControllerBase
{
    private readonly ISchoolService _SchoolService;
    private readonly IMapper _mapper;

    public SchoolController(ISchoolService SchoolService, IMapper mapper)
    {
        _SchoolService = SchoolService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<SchoolResource>> GetAllAsync()
    {
        var Schools = await _SchoolService.ListAsync();
        var resources = _mapper.Map<IEnumerable<School>, IEnumerable<SchoolResource>>(Schools);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSchoolResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var School = _mapper.Map<SaveSchoolResource, School>(resource);

        var result = await _SchoolService.SaveAsync(School);

        if (!result.Success)
            return BadRequest(result.Message);

        var SchoolResource = _mapper.Map<School, SchoolResource>(result.Resource);

        return Ok(School);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSchoolResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var School = _mapper.Map<SaveSchoolResource, School>(resource);

        var result = await _SchoolService.UpdateAsync(id, School);

        if (!result.Success)
            return BadRequest(result.Message);

        var SchoolResource = _mapper.Map<School, SchoolResource>(result.Resource);

        return Ok(SchoolResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _SchoolService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var SchoolResource = _mapper.Map<School, SchoolResource>(result.Resource);
        return Ok(SchoolResource);
    }
}
