using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[ApiController]
[Route("api/v1/{userid}/[controller]")]
public class NotificationController: ControllerBase
{
    private readonly INotificationService _notificationService;
    private readonly IMapper _mapper;
    
    public NotificationController(INotificationService notificationService, IMapper mapper)
    {
        _notificationService = notificationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<NotificationResource>> GetAllNotificationsAsync(int userid)
    {
        var notifications = await _notificationService.GetNotificationsAsync();
        var resources = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notifications);
        resources = resources.Where(x => (x.Receiver.Id == userid) ).ToList();
        return resources;
    }
    
    [HttpGet("recruiters")]
    public async Task<IEnumerable<NotificationResource>> GetLastNotificationRecruiter(int userid)
    {
        var notifications2 = await _notificationService.GetLastNotificationRecruiter(userid);
        var resources2 = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notifications2);
 
        return resources2;
    }
    
    [HttpGet("drivers")]
    public async Task<IEnumerable<NotificationResource>> GetLastNotificationDriver(int userid)
    {
        var notification3 = await _notificationService.GetLastNotificationDriver(userid);
        var resources3 = _mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationResource>>(notification3);
        return resources3;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> AddNotificationAsync([FromBody] SaveNotificationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var notification = _mapper.Map<SaveNotificationResource, Notification>(resource);

        var result = await _notificationService.AddNotificationAsync(notification);

        if (!result.Success)
            return BadRequest(result.Message);

        var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);

        return Ok(notificationResource);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _notificationService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var notificationResource = _mapper.Map<Notification, NotificationResource>(result.Resource);
        return Ok(notificationResource);
    }
    
}