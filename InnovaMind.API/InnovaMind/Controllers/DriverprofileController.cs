using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class DriverprofileController : ControllerBase
{
    private readonly IDriverprofileService _DriverprofileService;
    private readonly IMapper _mapper;

    public DriverprofileController(IDriverprofileService DriverprofileService, IMapper mapper)
    {
        _DriverprofileService = DriverprofileService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DriverprofileResource>> GetAllAsync()
    {
        var Driverprofiles = await _DriverprofileService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Driverprofile>, IEnumerable<DriverprofileResource>>(Driverprofiles);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDriverprofileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var Driverprofile = _mapper.Map<SaveDriverprofileResource, Driverprofile>(resource);

        var result = await _DriverprofileService.SaveAsync(Driverprofile);

        if (!result.Success)
            return BadRequest(result.Message);

        var DriverprofileResource = _mapper.Map<Driverprofile, DriverprofileResource>(result.Resource);

        return Ok(Driverprofile);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDriverprofileResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var Driverprofile = _mapper.Map<SaveDriverprofileResource, Driverprofile>(resource);

        var result = await _DriverprofileService.UpdateAsync(id, Driverprofile);

        if (!result.Success)
            return BadRequest(result.Message);

        var DriverprofileResource = _mapper.Map<Driverprofile, DriverprofileResource>(result.Resource);

        return Ok(DriverprofileResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _DriverprofileService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var DriverprofileResource = _mapper.Map<Driverprofile, DriverprofileResource>(result.Resource);
        return Ok(DriverprofileResource);
    }
}
