using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class DriverController : ControllerBase
{
    private readonly IDriverService _DriverService;
    private readonly IMapper _mapper;

    public DriverController(IDriverService DriverService, IMapper mapper)
    {
        _DriverService = DriverService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<DriverResource>> GetAllAsync()
    {
        var Drivers = await _DriverService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverResource>>(Drivers);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDriverResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var Driver = _mapper.Map<SaveDriverResource, Driver>(resource);

        var result = await _DriverService.SaveAsync(Driver);

        if (!result.Success)
            return BadRequest(result.Message);

        var DriverResource = _mapper.Map<Driver, DriverResource>(result.Resource);

        return Ok(Driver);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDriverResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var Driver = _mapper.Map<SaveDriverResource, Driver>(resource);

        var result = await _DriverService.UpdateAsync(id, Driver);

        if (!result.Success)
            return BadRequest(result.Message);

        var DriverResource = _mapper.Map<Driver, DriverResource>(result.Resource);

        return Ok(DriverResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _DriverService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var DriverResource = _mapper.Map<Driver, DriverResource>(result.Resource);
        return Ok(DriverResource);
    }
}
