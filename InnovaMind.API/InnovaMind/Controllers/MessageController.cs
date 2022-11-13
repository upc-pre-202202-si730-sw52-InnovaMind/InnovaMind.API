using AutoMapper;
using InnovaMind.API.InnovaMind.Domain.Models;
using InnovaMind.API.InnovaMind.Domain.Services;
using InnovaMind.API.InnovaMind.Resources;
using InnovaMind.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaMind.API.InnovaMind.Controllers;

[Route("/api/v1/[controller]")]
    
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;
    private readonly IMapper _mapper;
    
    public MessageController(IMessageService messageService, IMapper mapper)
    {
        _messageService = messageService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<MessageResource>> GetAllMessagesAsync()
    {
        var messages = await _messageService.GetMessagesAsync();
        var resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageResource>>(messages);

        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> AddMessageAsync([FromBody] SaveMessageResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var message = _mapper.Map<SaveMessageResource, Message>(resource);

        var result = await _messageService.AddMessageAsync(message);

        if (!result.Success)
            return BadRequest(result.Message);

        var messageResource = _mapper.Map<Message, MessageResource>(result.Resource);

        return Ok(messageResource);
    }
}

