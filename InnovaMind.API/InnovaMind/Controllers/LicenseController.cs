using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[ApiController]
[Route("/api/v1/[Controller]")]
public class LicenseController : ControllerBase
{
    private readonly ILicenseService _LicenseService;
    private readonly IMapper _mapper;

    public LicenseController(ILicenseService LicenseService, IMapper mapper)
    {
        _LicenseService = LicenseService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<LicenseResource>> GetAllAsync()
    {
        var Licenses = await _LicenseService.ListAsync();
        var resources = _mapper.Map<IEnumerable<License>, IEnumerable<LicenseResource>>(Licenses);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveLicenseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());
        var License = _mapper.Map<SaveLicenseResource, License>(resource);

        var result = await _LicenseService.SaveAsync(License);

        if (!result.Success)
            return BadRequest(result.Message);

        var LicenseResource = _mapper.Map<License, LicenseResource>(result.Resource);

        return Ok(License);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLicenseResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var License = _mapper.Map<SaveLicenseResource, License>(resource);

        var result = await _LicenseService.UpdateAsync(id, License);

        if (!result.Success)
            return BadRequest(result.Message);

        var LicenseResource = _mapper.Map<License, LicenseResource>(result.Resource);

        return Ok(LicenseResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _LicenseService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var LicenseResource = _mapper.Map<License, LicenseResource>(result.Resource);
        return Ok(LicenseResource);
    }
}
